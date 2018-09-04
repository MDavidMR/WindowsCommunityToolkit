// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using WinCompData.Tools;

namespace WinCompData.CodeGen
{
    /// <summary>
    /// Optimizes a <see cref="Visual"/> tree by combining and removing containers.
    /// </summary>
    static class TreeReducer
    {
        internal static Visual OptimizeContainers(Visual root)
        {
            var graph = Graph.FromCompositionObject(root, includeVertices: true);
            RemoveRedundantCenterPoints(graph);
            CoalesceContainerShapes(graph);
            CoalesceContainerVisuals(graph);
            return root;
        }

        // Set the CenterPoint property to null on objects that have no Scale or Rotation set.
        static void RemoveRedundantCenterPoints(ObjectGraph<Graph.Node> graph)
        {
            foreach (var (_, obj) in graph.CompositionObjectNodes)
            {
                switch (obj.Type)
                {
                    case CompositionObjectType.ContainerVisual:
                    case CompositionObjectType.ShapeVisual:
                        RemoveRedundantCenterPoint((Visual)obj);
                        break;
                    case CompositionObjectType.CompositionContainerShape:
                    case CompositionObjectType.CompositionSpriteShape:
                        RemoveRedundantCenterPoint((CompositionShape)obj);
                        break;
                }
            }
        }

        // Set the CenterPoint property to null if the object has no Scale or Rotation set.
        static void RemoveRedundantCenterPoint(Visual obj)
        {
            if (obj.CenterPoint.HasValue &&
                !obj.Scale.HasValue &&
                !obj.RotationAngleInDegrees.HasValue &&
                !obj.Animators.Where(a => a.AnimatedProperty == nameof(obj.Scale) || a.AnimatedProperty == nameof(obj.RotationAngleInDegrees)).Any())
            {
                obj.CenterPoint = null;
            }
        }

        // Set the CenterPoint property to null if the object has no Scale or Rotation set.
        static void RemoveRedundantCenterPoint(CompositionShape obj)
        {
            if (obj.CenterPoint.HasValue &&
                !obj.Scale.HasValue &&
                !obj.RotationAngleInDegrees.HasValue &&
                !obj.Animators.Where(a => a.AnimatedProperty == nameof(obj.Scale) || a.AnimatedProperty == nameof(obj.RotationAngleInDegrees)).Any())
            {
                obj.CenterPoint = null;
            }
        }

        static void CoalesceContainerShapes(ObjectGraph<Graph.Node> graph)
        {
            var containerShapes = graph.CompositionObjectNodes.Where(n => n.Object.Type == CompositionObjectType.CompositionContainerShape).ToArray();

            // If a container sets just the translate properties (offset and centerpoint) and the child
            // also sets only the translate properties, the container's properties can be pushed down to
            // the child.
            var elidableContainers = containerShapes.Where(n =>
            {
                var container = (CompositionContainerShape)n.Object;
                if (container.Properties.PropertyNames.Any() ||
                    container.Animators.Any() ||
                    container.RotationAngleInDegrees != null ||
                    container.Scale != null ||
                    container.TransformMatrix != null ||
                    container.Shapes.Count != 1)
                {
                    return false;
                }
                // Container has only translate properties.
                var child = container.Shapes.Single();
                if (child.Properties.PropertyNames.Any() ||
                    child.Animators.Any() ||
                    child.RotationAngleInDegrees != null ||
                    child.Scale != null ||
                    child.TransformMatrix != null)
                {
                    return false;
                }
                // Child also has only translate properties.
                return true;
            });

            // Push the offset and centerpoint from the container down to the child and remove the container.
            foreach (var node in elidableContainers)
            {
                var container = (CompositionContainerShape)node.Object;
                var child = container.Shapes.Single();
                var parent = container.Parent;

                if (container.Offset != null)
                {
                    if (child.Offset != null)
                    {
                        child.Offset = child.Offset.Value + container.Offset.Value;
                    }
                    else
                    {
                        child.Offset = container.Offset;
                    }
                }

                if (container.CenterPoint != null)
                {
                    if (child.CenterPoint != null)
                    {
                        child.CenterPoint = child.CenterPoint.Value + container.CenterPoint.Value;
                    }
                    else
                    {
                        child.CenterPoint = container.CenterPoint;
                    }
                }
                // Remove the container. The child must be placed in the slot where the container was.
                var index = parent.Shapes.IndexOf(container);
                // Clear the container to unparent the child. This must be done before reparenting.
                container.Shapes.Clear();
                parent.Shapes[index] = child;
            }

            // If a container has no properties set, its children can be inserted into its parent.
            var containersWithNoPropertiesSet = containerShapes.Where(n =>
            {
                var container = (CompositionContainerShape)n.Object;
                if (container.Type != CompositionObjectType.CompositionContainerShape ||
                    container.CenterPoint != null ||
                    container.Offset != null ||
                    container.RotationAngleInDegrees != null ||
                    container.Scale != null ||
                    container.TransformMatrix != null ||
                    container.Animators.Any() ||
                    container.Properties.PropertyNames.Any())
                {
                    return false;
                }
                // Container has no properties set.
                return true;
            }).Select(n => (CompositionContainerShape)n.Object);

            foreach (var container in containersWithNoPropertiesSet)
            {
                // Insert the children into the parent.
                var parent = container.Parent;
                if (parent == null)
                {
                    // The container may have already been removed, or it might be a root.
                    continue;
                }

                // Find the index in the parent of the container.
                // If childCount is 1, just replace the the container in the parent.
                // If childCount is >1, insert into the parent.
                var index = parent.Shapes.IndexOf(container);
                // Get the children from the container.
                var children = container.Shapes.ToArray();
                // Remove the children from the container.
                container.Shapes.Clear();
                // Insert the first child where the container was.
                parent.Shapes[index] = children[0];

                // Insert the rest of the children.
                for (var i = 1; i < children.Length; i++)
                {
                    parent.Shapes.Insert(index + i, children[i]);
                }
            }
        }

        static void CoalesceContainerVisuals(ObjectGraph<Graph.Node> graph)
        {
            var containersWithNoPropertiesSet = graph.CompositionObjectNodes.Where(n =>
            {
                // Find the ContainerVisuals that have no properties set.
                return
                    n.Object is ContainerVisual container &&
                    container.CenterPoint == null &&
                    container.Clip == null &&
                    container.Offset == null &&
                    container.Opacity == null &&
                    container.RotationAngleInDegrees == null &&
                    container.Scale == null &&
                    container.Size == null &&
                    !container.Animators.Any() &&
                    !container.Properties.PropertyNames.Any();
            }).Select(n => (ContainerVisual)n.Object).ToArray();

            // Pull the children of the container into the parent of the container. Remove the unnecessary containers.
            foreach (var container in containersWithNoPropertiesSet)
            {
                // Insert the children into the parent.
                var parent = container.Parent;
                if (parent == null)
                {
                    // The container may have already been removed, or it might be a root.
                    continue;
                }

                // Find the index in the parent of the container.
                // If childCount is 1, just replace the the container in the parent.
                // If childCount is >1, insert into the parent.
                var index = parent.Children.IndexOf(container);

                // Get the children from the container.
                var children = container.Children.ToArray();
                if (children.Length == 0)
                {
                    // The container has no children. This is rare but can happen if
                    // the container is for a layer type that we don't support.
                    continue;
                }

                // Remove the children from the container.
                container.Children.Clear();
                // Insert the first child where the container was.
                parent.Children[index] = children[0];

                // Insert the rest of the children.
                for (var i = 1; i < children.Length; i++)
                {
                    parent.Children.Insert(index + i, children[i]);
                }
            }
        }
    }
}
