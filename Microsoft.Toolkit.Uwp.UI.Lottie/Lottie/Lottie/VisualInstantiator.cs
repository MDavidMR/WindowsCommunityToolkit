﻿using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using Wc = Windows.UI.Composition;
using Wd = WinCompData;

namespace Lottie
{
    /// <summary>
    /// Creates instances of a <see cref="Windows.UI.Composition.Visual"/> tree from a description
    /// of the tree.
    /// </summary>
    sealed class VisualInstantiator
    {
        readonly Wc.Compositor _c;
        readonly CanvasDevice _canvasDevice;
        readonly Dictionary<object, object> _cache = new Dictionary<object, object>(new ReferenceEqualsComparer());

        VisualInstantiator(Wc.Compositor compositor)
        {
            _c = compositor;
            _canvasDevice = CanvasDevice.GetSharedDevice();
        }

        /// <summary>
        /// Creates a new instance of <see cref="Windows.UI.Composition.Visual"/>
        /// described by the given <see cref="WinCompData.Visual"/>.
        /// </summary>
        internal static Wc.Visual CreateVisual(Wc.Compositor compositor, Wd.Visual visual)
        {
            var converter = new VisualInstantiator(compositor);
            return converter.GetVisual(visual);
        }

        bool GetExisting<T>(object key, out T result)
        {
            if (_cache.TryGetValue(key, out object cached))
            {
                result = (T)cached;
                return true;
            }
            else
            {
                result = default(T);
                return false;
            }
        }

        T CacheAndInitialize<T>(Wd.CompositionObject key, T obj)
            where T : Wc.CompositionObject
        {
            _cache.Add(key, obj);
            SetProperties(key, obj);
            return obj;
        }

        T CacheAndInitializeShape<T>(Wd.CompositionShape source, T target)
            where T : Wc.CompositionShape
        {
            _cache.Add(source, target);
            SetProperties(source, target);
            if (source.CenterPoint.HasValue)
            {
                target.CenterPoint = Vector2(source.CenterPoint);
            }
            if (source.Offset.HasValue)
            {
                target.Offset = Vector2(source.Offset);
            }
            if (source.RotationAngleInDegrees.HasValue)
            {
                target.RotationAngleInDegrees = source.RotationAngleInDegrees.Value;
            }
            if (source.Scale.HasValue)
            {
                target.Scale = Vector2(source.Scale);
            }
            return target;
        }

        T CacheAndInitializeVisual<T>(Wd.Visual source, T target)
            where T : Wc.Visual
        {
            _cache.Add(source, target);
            SetProperties(source, target);
            if (source.Clip != null)
            {
                target.Clip = GetCompositionClip(source.Clip);
            }
            if (source.CenterPoint.HasValue)
            {
                target.CenterPoint = Vector3(source.CenterPoint);
            }
            if (source.Offset.HasValue)
            {
                target.Offset = Vector3(source.Offset);
            }
            if (source.RotationAngleInDegrees.HasValue)
            {
                target.RotationAngleInDegrees = source.RotationAngleInDegrees.Value;
            }
            if (source.Scale.HasValue)
            {
                target.Scale = Vector3(source.Scale);
            }
            if (source.Size.HasValue)
            {
                target.Size = Vector2(source.Size);
            }
            return target;
        }

        T CacheAndInitializeAnimation<T>(Wd.CompositionAnimation source, T target)
            where T : Wc.CompositionAnimation
        {
            _cache.Add(source, target);
            foreach (var parameter in source.ReferenceParameters)
            {
                target.SetReferenceParameter(parameter.Key, GetCompositionObject(parameter.Value));
            }
            SetProperties(source, target);
            if (source.Target != null)
            {
                target.Target = source.Target;
            }
            return target;
        }

        T CacheAndInitializeKeyframeAnimation<T>(Wd.KeyFrameAnimation_ source, T target)
            where T : Wc.KeyFrameAnimation
        {
            CacheAndInitializeAnimation(source, target);
            target.Duration = source.Duration;
            return target;
        }

        T Cache<T>(object key, T obj)
        {
            _cache.Add(key, obj);
            return obj;
        }

        Wc.ShapeVisual GetShapeVisual(Wd.ShapeVisual obj)
        {
            if (GetExisting(obj, out Wc.ShapeVisual result))
            {
                return result;
            }
           
            result = CacheAndInitializeVisual(obj, _c.CreateShapeVisual());

            if (obj.ViewBox != null)
            {
                result.ViewBox = GetCompositionViewBox(obj.ViewBox);
            }

            var shapesCollection = result.Shapes;
            foreach (var child in obj.Shapes)
            {
                shapesCollection.Add(GetCompositionShape(child));
            }

            InitializeContainerVisual(obj, result);
            StartAnimations(obj, result);
            return result;
        }

        Wc.ContainerVisual GetContainerVisual(Wd.ContainerVisual obj)
        {
            if (GetExisting(obj, out Wc.ContainerVisual result))
            {
                return result;
            }

            result = CacheAndInitializeVisual(obj, _c.CreateContainerVisual());
            InitializeContainerVisual(obj, result);
            StartAnimations(obj, result);
            return result;
        }

        void InitializeContainerVisual(Wd.ContainerVisual source, Wc.ContainerVisual target)
        {
            var children = target.Children;
            foreach (var child in source.Children)
            {
                children.InsertAtTop(GetVisual(child));
            }
        }


        void SetProperties(Wd.CompositionObject source, Wc.CompositionObject target)
        {
            var propertySet = target.Properties;
            foreach (var prop in source.Properties.ScalarProperties)
            {
                propertySet.InsertScalar(prop.Key, prop.Value);
            }
            foreach (var prop in source.Properties.Vector2Properties)
            {
                propertySet.InsertVector2(prop.Key, Vector2(prop.Value));
            }
            if (source.Comment != null)
            {
                target.Comment = source.Comment;
            }
        }

        void StartAnimations(Wd.CompositionObject source, Wc.CompositionObject target)
        {
            foreach (var animator in source.Animators)
            {
                var animation = GetCompositionAnimation(animator.Animation);
                target.StartAnimation(animator.Target, animation);
                var controller = animator.Controller;
                if (controller != null)
                {
                    var animationController = GetAnimationController(controller);
                    //// TODO - should only pause if the mock controller was paused, but
                    ////        for Lottie they're always paused, so this is good enough.
                    animationController.Pause();
                }
            }
        }



        Wc.AnimationController GetAnimationController(Wd.AnimationController obj)
        {
            if (GetExisting(obj, out Wc.AnimationController result))
            {
                return result;
            }
            var targetObject = GetCompositionObject(obj.TargetObject);

            result = CacheAndInitialize(obj, targetObject.TryGetAnimationController(obj.TargetProperty));
            StartAnimations(obj, result);
            return result;
        }

        Wc.CompositionObject GetCompositionObject(Wd.CompositionObject obj)
        {
            switch (obj.Type)
            {
                case Wd.CompositionObjectType.AnimationController:
                    return GetAnimationController((Wd.AnimationController)obj);
                case Wd.CompositionObjectType.ColorKeyFrameAnimation:
                    return GetColorKeyFrameAnimation((Wd.ColorKeyFrameAnimation)obj);
                case Wd.CompositionObjectType.CompositionColorBrush:
                    return GetCompositionColorBrush((Wd.CompositionColorBrush)obj);
                case Wd.CompositionObjectType.CompositionContainerShape:
                    return GetCompositionContainerShape((Wd.CompositionContainerShape)obj);
                case Wd.CompositionObjectType.CompositionEllipseGeometry:
                    return GetCompositionEllipseGeometry((Wd.CompositionEllipseGeometry)obj);
                case Wd.CompositionObjectType.CompositionPathGeometry:
                    return GetCompositionPathGeometry((Wd.CompositionPathGeometry)obj);
                case Wd.CompositionObjectType.CompositionRectangleGeometry:
                    return GetCompositionRectangleGeometry((Wd.CompositionRectangleGeometry)obj);
                case Wd.CompositionObjectType.CompositionRoundedRectangleGeometry:
                    return GetCompositionRoundedRectangleGeometry((Wd.CompositionRoundedRectangleGeometry)obj);
                case Wd.CompositionObjectType.CompositionSpriteShape:
                    return GetCompositionSpriteShape((Wd.CompositionSpriteShape)obj);
                case Wd.CompositionObjectType.CompositionViewBox:
                    return GetCompositionViewBox((Wd.CompositionViewBox)obj);
                case Wd.CompositionObjectType.ContainerVisual:
                    return GetContainerVisual((Wd.ContainerVisual)obj);
                case Wd.CompositionObjectType.CubicBezierEasingFunction:
                    return GetCubicBezierEasingFunction((Wd.CubicBezierEasingFunction)obj);
                case Wd.CompositionObjectType.ExpressionAnimation:
                    return GetExpressionAnimation((Wd.ExpressionAnimation)obj);
                case Wd.CompositionObjectType.InsetClip:
                    return GetInsetClip((Wd.InsetClip)obj);
                case Wd.CompositionObjectType.LinearEasingFunction:
                    return GetLinearEasingFunction((Wd.LinearEasingFunction)obj);
                case Wd.CompositionObjectType.PathKeyFrameAnimation:
                    return GetPathKeyFrameAnimation((Wd.PathKeyFrameAnimation)obj);
                case Wd.CompositionObjectType.ScalarKeyFrameAnimation:
                    return GetScalarKeyFrameAnimation((Wd.ScalarKeyFrameAnimation)obj);
                case Wd.CompositionObjectType.ShapeVisual:
                    return GetShapeVisual((Wd.ShapeVisual)obj);
                case Wd.CompositionObjectType.StepEasingFunction:
                    return GetStepEasingFunction((Wd.StepEasingFunction)obj);
                case Wd.CompositionObjectType.Vector2KeyFrameAnimation:
                    return GetVector2KeyFrameAnimation((Wd.Vector2KeyFrameAnimation)obj);
                case Wd.CompositionObjectType.Vector3KeyFrameAnimation:
                    return GetVector3KeyFrameAnimation((Wd.Vector3KeyFrameAnimation)obj);
                default:
                    throw new InvalidOperationException();
            }
        }

        Wc.Visual GetVisual(Wd.Visual obj)
        {
            switch (obj.Type)
            {
                case Wd.CompositionObjectType.ContainerVisual:
                    return GetContainerVisual((Wd.ContainerVisual)obj);
                case Wd.CompositionObjectType.ShapeVisual:
                    return GetShapeVisual((Wd.ShapeVisual)obj);
                default:
                    throw new InvalidOperationException();
            }
        }

        Wc.CompositionAnimation GetCompositionAnimation(Wd.CompositionAnimation obj)
        {
            switch (obj.Type)
            {
                case Wd.CompositionObjectType.ExpressionAnimation:
                    return GetExpressionAnimation((Wd.ExpressionAnimation)obj);
                case Wd.CompositionObjectType.ColorKeyFrameAnimation:
                    return GetColorKeyFrameAnimation((Wd.ColorKeyFrameAnimation)obj);
                case Wd.CompositionObjectType.PathKeyFrameAnimation:
                    return GetPathKeyFrameAnimation((Wd.PathKeyFrameAnimation)obj);
                case Wd.CompositionObjectType.ScalarKeyFrameAnimation:
                    return GetScalarKeyFrameAnimation((Wd.ScalarKeyFrameAnimation)obj);
                case Wd.CompositionObjectType.Vector2KeyFrameAnimation:
                    return GetVector2KeyFrameAnimation((Wd.Vector2KeyFrameAnimation)obj);
                case Wd.CompositionObjectType.Vector3KeyFrameAnimation:
                    return GetVector3KeyFrameAnimation((Wd.Vector3KeyFrameAnimation)obj);
                default:
                    throw new InvalidOperationException();
            }
        }

        Wc.ExpressionAnimation GetExpressionAnimation(Wd.ExpressionAnimation obj)
        {
            if (GetExisting(obj, out Wc.ExpressionAnimation result))
            {
                return result;
            }
            result = CacheAndInitializeAnimation(obj, _c.CreateExpressionAnimation(obj.Expression));
            StartAnimations(obj, result);
            return result;
        }

        Wc.ColorKeyFrameAnimation GetColorKeyFrameAnimation(Wd.ColorKeyFrameAnimation obj)
        {
            if (GetExisting(obj, out Wc.ColorKeyFrameAnimation result))
            {
                return result;
            }

            result = CacheAndInitializeKeyframeAnimation(obj, _c.CreateColorKeyFrameAnimation());
            foreach (var kf in obj.KeyFrames)
            {
                result.InsertKeyFrame(kf.Progress, Color(kf.Value), GetCompositionEasingFunction(kf.Easing));
            }
            StartAnimations(obj, result);
            return result;
        }

        Wc.ScalarKeyFrameAnimation GetScalarKeyFrameAnimation(Wd.ScalarKeyFrameAnimation obj)
        {
            if (GetExisting(obj, out Wc.ScalarKeyFrameAnimation result))
            {
                return result;
            }

            result = CacheAndInitializeKeyframeAnimation(obj, _c.CreateScalarKeyFrameAnimation());
            foreach (var kf in obj.KeyFrames)
            {
                result.InsertKeyFrame(kf.Progress, kf.Value, GetCompositionEasingFunction(kf.Easing));
            }
            StartAnimations(obj, result);
            return result;
        }

        Wc.Vector2KeyFrameAnimation GetVector2KeyFrameAnimation(Wd.Vector2KeyFrameAnimation obj)
        {
            if (GetExisting(obj, out Wc.Vector2KeyFrameAnimation result))
            {
                return result;
            }

            result = CacheAndInitializeKeyframeAnimation(obj, _c.CreateVector2KeyFrameAnimation());
            foreach (var kf in obj.KeyFrames)
            {
                result.InsertKeyFrame(kf.Progress, Vector2(kf.Value), GetCompositionEasingFunction(kf.Easing));
            }
            StartAnimations(obj, result);
            return result;
        }

        Wc.Vector3KeyFrameAnimation GetVector3KeyFrameAnimation(Wd.Vector3KeyFrameAnimation obj)
        {
            if (GetExisting(obj, out Wc.Vector3KeyFrameAnimation result))
            {
                return result;
            }

            result = CacheAndInitializeKeyframeAnimation(obj, _c.CreateVector3KeyFrameAnimation());
            foreach (var kf in obj.KeyFrames)
            {
                result.InsertKeyFrame(kf.Progress, Vector3(kf.Value), GetCompositionEasingFunction(kf.Easing));
            }
            StartAnimations(obj, result);
            return result;
        }

        Wc.PathKeyFrameAnimation GetPathKeyFrameAnimation(Wd.PathKeyFrameAnimation obj)
        {
            if (GetExisting(obj, out Wc.PathKeyFrameAnimation result))
            {
                return result;
            }

            result = CacheAndInitializeKeyframeAnimation(obj, _c.CreatePathKeyFrameAnimation());
            foreach (var kf in obj.KeyFrames)
            {
                result.InsertKeyFrame(kf.Progress, GetCompositionPath(kf.Value), GetCompositionEasingFunction(kf.Easing));
            }
            StartAnimations(obj, result);
            return result;
        }

        Wc.CompositionEasingFunction GetCompositionEasingFunction(Wd.CompositionEasingFunction obj)
        {
            switch (obj.Type)
            {
                case Wd.CompositionObjectType.LinearEasingFunction:
                    return GetLinearEasingFunction((Wd.LinearEasingFunction)obj);
                case Wd.CompositionObjectType.StepEasingFunction:
                    return GetStepEasingFunction((Wd.StepEasingFunction)obj);
                case Wd.CompositionObjectType.CubicBezierEasingFunction:
                    return GetCubicBezierEasingFunction((Wd.CubicBezierEasingFunction)obj);
                default:
                    throw new InvalidOperationException();
            }
        }

        Wc.CompositionClip GetCompositionClip(Wd.CompositionClip obj)
        {
            return GetInsetClip((Wd.InsetClip)obj);
        }

        Wc.InsetClip GetInsetClip(Wd.InsetClip obj)
        {
            if (GetExisting(obj, out Wc.InsetClip result))
            {
                return result;
            }

            result = CacheAndInitialize(obj, _c.CreateInsetClip());
            if (obj.LeftInset != null)
            {
                result.LeftInset = obj.LeftInset.Value;
            }
            if (obj.RightInset != null)
            {
                result.RightInset = obj.RightInset.Value;
            }
            if (obj.TopInset != null)
            {
                result.TopInset = obj.TopInset.Value;
            }
            if (obj.BottomInset != null)
            {
                result.BottomInset = obj.BottomInset.Value;
            }
            StartAnimations(obj, result);
            return result;

        }

        Wc.LinearEasingFunction GetLinearEasingFunction(Wd.LinearEasingFunction obj)
        {
            if (GetExisting(obj, out Wc.LinearEasingFunction result))
            {
                return result;
            }

            result = CacheAndInitialize(obj, _c.CreateLinearEasingFunction());
            StartAnimations(obj, result);
            return result;
        }

        Wc.StepEasingFunction GetStepEasingFunction(Wd.StepEasingFunction obj)
        {
            if (GetExisting(obj, out Wc.StepEasingFunction result))
            {
                return result;
            }

            result = CacheAndInitialize(obj, _c.CreateStepEasingFunction());
            result.FinalStep = obj.FinalStep;
            result.InitialStep = obj.InitialStep;
            result.IsFinalStepSingleFrame = obj.IsFinalStepSingleFrame;
            result.IsInitialStepSingleFrame = obj.IsInitialStepSingleFrame;
            result.StepCount = obj.StepCount;
            StartAnimations(obj, result);
            return result;
        }

        Wc.CubicBezierEasingFunction GetCubicBezierEasingFunction(Wd.CubicBezierEasingFunction obj)
        {
            if (GetExisting(obj, out Wc.CubicBezierEasingFunction result))
            {
                return result;
            }

            result = CacheAndInitialize(obj, _c.CreateCubicBezierEasingFunction(Vector2(obj.ControlPoint1), Vector2(obj.ControlPoint2)));
            StartAnimations(obj, result);
            return result;
        }
        Wc.CompositionViewBox GetCompositionViewBox(Wd.CompositionViewBox obj)
        {
            if (GetExisting(obj, out Wc.CompositionViewBox result))
            {
                return result;
            }

            result = CacheAndInitialize(obj, _c.CreateViewBox());
            result.Size = Vector2(obj.Size);
            StartAnimations(obj, result);
            return result;
        }

        Wc.CompositionShape GetCompositionShape(Wd.CompositionShape obj)
        {
            switch (obj.Type)
            {
                case Wd.CompositionObjectType.CompositionSpriteShape:
                    return GetCompositionSpriteShape((Wd.CompositionSpriteShape)obj);
                case Wd.CompositionObjectType.CompositionContainerShape:
                    return GetCompositionContainerShape((Wd.CompositionContainerShape)obj);
                default:
                    throw new InvalidOperationException();
            }
        }

        Wc.CompositionContainerShape GetCompositionContainerShape(Wd.CompositionContainerShape obj)
        {
            if (GetExisting(obj, out Wc.CompositionContainerShape result))
            {
                return result;
            }

            // If this container has only 1 child, it might be coalescable with its child.
            if (obj.Shapes.Count == 1)
            {
                var child = obj.Shapes[0];
                if (!obj.Animators.Any())
                {
                    // The container has no animations. It can be replaced with its child as
                    // long as the child doesn't animate any of the non-default properties and
                    // the container isn't referenced by an animation.

                }
                else if (!child.Animators.Any() && child.Type == Wd.CompositionObjectType.CompositionContainerShape)
                {
                    // The child has no animations. It can be replaced with its parent as long
                    // as the parent doesn't animate any of the child's non-default properties
                    // and the child isn't referenced by an animation.
                }
            }

            result = CacheAndInitializeShape(obj, _c.CreateContainerShape());
            var shapeCollection = result.Shapes;
            foreach (var child in obj.Shapes)
            {
                shapeCollection.Add(GetCompositionShape(child));
            }
            StartAnimations(obj, result);
            return result;
        }

        Wc.CompositionSpriteShape GetCompositionSpriteShape(Wd.CompositionSpriteShape obj)
        {
            if (GetExisting(obj, out Wc.CompositionSpriteShape result))
            {
                return result;
            }

            result = CacheAndInitializeShape(obj, _c.CreateSpriteShape());

            if (obj.StrokeBrush != null)
            {
                result.StrokeBrush = GetCompositionBrush(obj.StrokeBrush);
                if (obj.StrokeDashCap != Wd.CompositionStrokeCap.Flat)
                {
                    result.StrokeDashCap = StrokeCap(obj.StrokeDashCap);
                }
                if (obj.StrokeStartCap != Wd.CompositionStrokeCap.Flat)
                {
                    result.StrokeStartCap = StrokeCap(obj.StrokeStartCap);
                }
                if (obj.StrokeEndCap != Wd.CompositionStrokeCap.Flat)
                {
                    result.StrokeEndCap = StrokeCap(obj.StrokeEndCap);
                }
                if (obj.StrokeThickness != 1)
                {
                    result.StrokeThickness = obj.StrokeThickness;
                }
                if (obj.StrokeMiterLimit != 1)
                {
                    result.StrokeMiterLimit = obj.StrokeMiterLimit;
                }
                if (obj.StrokeLineJoin != Wd.CompositionStrokeLineJoin.Miter)
                {
                    result.StrokeLineJoin = StrokeLineJoin(obj.StrokeLineJoin);
                }
                if (obj.StrokeDashOffset != 0)
                {
                    result.StrokeDashOffset = obj.StrokeDashOffset;
                }
                if (obj.IsStrokeNonScaling)
                {
                    result.IsStrokeNonScaling = obj.IsStrokeNonScaling;
                }
                var strokeDashArray = result.StrokeDashArray;
                foreach (var strokeDash in obj.StrokeDashArray)
                {
                    strokeDashArray.Add(strokeDash);
                }
            }
            result.Geometry = GetCompositionGeometry(obj.Geometry);
            if (obj.FillBrush != null)
            {
                result.FillBrush = GetCompositionBrush(obj.FillBrush);
            }
            StartAnimations(obj, result);
            return result;
        }

        Wc.CompositionGeometry GetCompositionGeometry(Wd.CompositionGeometry obj)
        {
            switch (obj.Type)
            {
                case Wd.CompositionObjectType.CompositionPathGeometry:
                    return GetCompositionPathGeometry((Wd.CompositionPathGeometry)obj);

                case Wd.CompositionObjectType.CompositionEllipseGeometry:
                    return GetCompositionEllipseGeometry((Wd.CompositionEllipseGeometry)obj);

                case Wd.CompositionObjectType.CompositionRectangleGeometry:
                    return GetCompositionRectangleGeometry((Wd.CompositionRectangleGeometry)obj);

                case Wd.CompositionObjectType.CompositionRoundedRectangleGeometry:
                    return GetCompositionRoundedRectangleGeometry((Wd.CompositionRoundedRectangleGeometry)obj);

                default:
                    throw new InvalidOperationException();
            }
        }

        Wc.CompositionEllipseGeometry GetCompositionEllipseGeometry(Wd.CompositionEllipseGeometry obj)
        {
            if (GetExisting(obj, out Wc.CompositionEllipseGeometry result))
            {
                return result;
            }
            result = CacheAndInitialize(obj, _c.CreateEllipseGeometry());
            result.Radius = Vector2(obj.Radius);
            result.Center = Vector2(obj.Center);
            StartAnimations(obj, result);
            return result;
        }

        Wc.CompositionRectangleGeometry GetCompositionRectangleGeometry(Wd.CompositionRectangleGeometry obj)
        {
            if (GetExisting(obj, out Wc.CompositionRectangleGeometry result))
            {
                return result;
            }
            result = CacheAndInitialize(obj, _c.CreateRectangleGeometry());
            result.Size = Vector2(obj.Size);
            StartAnimations(obj, result);
            return result;
        }

        Wc.CompositionRoundedRectangleGeometry GetCompositionRoundedRectangleGeometry(Wd.CompositionRoundedRectangleGeometry obj)
        {
            if (GetExisting(obj, out Wc.CompositionRoundedRectangleGeometry result))
            {
                return result;
            }
            result = CacheAndInitialize(obj, _c.CreateRoundedRectangleGeometry());
            result.Size = Vector2(obj.Size);
            result.CornerRadius = Vector2(obj.CornerRadius);
            StartAnimations(obj, result);
            return result;
        }

        Wc.CompositionPathGeometry GetCompositionPathGeometry(Wd.CompositionPathGeometry obj)
        {
            if (GetExisting(obj, out Wc.CompositionPathGeometry result))
            {
                return result;
            }
            result = CacheAndInitialize(obj, _c.CreatePathGeometry(GetCompositionPath(obj.Path)));
            if (obj.TrimStart.HasValue)
            {
                result.TrimStart = obj.TrimStart.Value;
            }
            if (obj.TrimEnd.HasValue)
            {
                result.TrimEnd = obj.TrimEnd.Value;
            }
            if (obj.TrimOffset.HasValue)
            {
                result.TrimOffset = obj.TrimOffset.Value;
            }
            StartAnimations(obj, result);
            return result;
        }

        Wc.CompositionPath GetCompositionPath(Wd.CompositionPath obj)
        {
            if (GetExisting(obj, out Wc.CompositionPath result))
            {
                return result;
            }

            result = Cache(obj, new Wc.CompositionPath(GetCanvasGeometry(obj.Source)));
            return result;
        }

        CanvasGeometry GetCanvasGeometry(Wd.Wg.IGeometrySource2D obj)
        {
            if (GetExisting(obj, out CanvasGeometry result))
            {
                return result;
            }

            var canvasGeometry = (Wd.Mgcg.CanvasGeometry)obj;
            var content = canvasGeometry.Content;
            if (content is Wd.Mgcg.CanvasPathBuilder)
            {
                using (var builder = new CanvasPathBuilder(_canvasDevice))
                {
                    ConfigureBuilder(builder, (WinCompData.Mgcg.CanvasPathBuilder)content);
                    return Cache(obj, CanvasGeometry.CreatePath(builder));
                }
            }
            else if (content is Wd.Mgcg.CanvasGeometry.Combination)
            {
                var combination = (Wd.Mgcg.CanvasGeometry.Combination)content;

                return Cache(obj, GetCanvasGeometry(combination.A).CombineWith(
                    GetCanvasGeometry(combination.B),
                    Matrix3x2(combination.Matrix),
                    Combine(combination.CombineMode)));
            }
            else
            {
                // TODO
                throw new InvalidOperationException();
            }
        }

        static void ConfigureBuilder(CanvasPathBuilder builder, Wd.Mgcg.CanvasPathBuilder WinCompDataBuilder)
        {
            foreach (var command in WinCompDataBuilder.Commands)
            {
                switch (command.Type)
                {
                    case Wd.Mgcg.CanvasPathBuilder.CommandType.BeginFigure:
                        builder.BeginFigure(Vector2((Wd.Sn.Vector2)command.Args));
                        break;
                    case Wd.Mgcg.CanvasPathBuilder.CommandType.EndFigure:
                        builder.EndFigure(CanvasFigureLoop((Wd.Mgcg.CanvasFigureLoop)command.Args));
                        break;
                    case Wd.Mgcg.CanvasPathBuilder.CommandType.AddCubicBezier:
                        var vectors = (Wd.Sn.Vector2[])command.Args;
                        builder.AddCubicBezier(Vector2(vectors[0]), Vector2(vectors[1]), Vector2(vectors[2]));
                        break;
                    case Wd.Mgcg.CanvasPathBuilder.CommandType.SetFilledRegionDetermination:
                        builder.SetFilledRegionDetermination(FilledRegionDetermination((Wd.Mgcg.CanvasFilledRegionDetermination)command.Args));
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        Wc.CompositionBrush GetCompositionBrush(Wd.CompositionBrush obj)
        {
            return GetCompositionColorBrush((Wd.CompositionColorBrush)obj);
        }

        Wc.CompositionColorBrush GetCompositionColorBrush(Wd.CompositionColorBrush obj)
        {
            if (GetExisting(obj, out Wc.CompositionColorBrush result))
            {
                return result;
            }
            result = CacheAndInitialize(obj, _c.CreateColorBrush(Color(obj.Color)));
            StartAnimations(obj, result);
            return result;
        }

        static Wc.CompositionStrokeLineJoin StrokeLineJoin(Wd.CompositionStrokeLineJoin value)
        {
            switch (value)
            {
                case Wd.CompositionStrokeLineJoin.Miter:
                    return Wc.CompositionStrokeLineJoin.Miter;
                case Wd.CompositionStrokeLineJoin.Bevel:
                    return Wc.CompositionStrokeLineJoin.Bevel;
                case Wd.CompositionStrokeLineJoin.Round:
                    return Wc.CompositionStrokeLineJoin.Round;
                case Wd.CompositionStrokeLineJoin.MiterOrBevel:
                    return Wc.CompositionStrokeLineJoin.MiterOrBevel;
                default:
                    throw new InvalidOperationException();
            }
        }
        static Wc.CompositionStrokeCap StrokeCap(Wd.CompositionStrokeCap value)
        {
            switch (value)
            {
                case Wd.CompositionStrokeCap.Flat:
                    return Wc.CompositionStrokeCap.Flat;
                case Wd.CompositionStrokeCap.Square:
                    return Wc.CompositionStrokeCap.Square;
                case Wd.CompositionStrokeCap.Round:
                    return Wc.CompositionStrokeCap.Round;
                case Wd.CompositionStrokeCap.Triangle:
                    return Wc.CompositionStrokeCap.Triangle;
                default:
                    throw new InvalidOperationException();
            }
        }

        static System.Numerics.Vector2 Vector2(Wd.Sn.Vector2 value) => new System.Numerics.Vector2(value.X, value.Y);
        static System.Numerics.Vector2 Vector2(Wd.Sn.Vector2? value) => Vector2(value.Value);
        static System.Numerics.Vector3 Vector3(Wd.Sn.Vector3 value) => new System.Numerics.Vector3(value.X, value.Y, value.Z);
        static System.Numerics.Vector3 Vector3(Wd.Sn.Vector3? value) => Vector3(value.Value);

        static System.Numerics.Matrix3x2 Matrix3x2(Wd.Sn.Matrix3x2 value)
        {
            return new System.Numerics.Matrix3x2(
                value.M11,
                value.M12,
                value.M21,
                value.M22,
                value.M31,
                value.M32);
        }

        static Windows.UI.Color Color(Wd.Wui.Color color) =>
            Windows.UI.Color.FromArgb(color.A, color.R, color.G, color.B);

        static CanvasFilledRegionDetermination FilledRegionDetermination(
            Wd.Mgcg.CanvasFilledRegionDetermination value)
        {
            switch (value)
            {
                case Wd.Mgcg.CanvasFilledRegionDetermination.Alternate:
                    return CanvasFilledRegionDetermination.Alternate;
                case Wd.Mgcg.CanvasFilledRegionDetermination.Winding:
                    return CanvasFilledRegionDetermination.Winding;
                default:
                    throw new InvalidOperationException();
            }
        }

        static CanvasFigureLoop CanvasFigureLoop(Wd.Mgcg.CanvasFigureLoop value)
        {
            switch (value)
            {
                case Wd.Mgcg.CanvasFigureLoop.Open:
                    return Microsoft.Graphics.Canvas.Geometry.CanvasFigureLoop.Open;
                case Wd.Mgcg.CanvasFigureLoop.Closed:
                    return Microsoft.Graphics.Canvas.Geometry.CanvasFigureLoop.Closed;
                default:
                    throw new InvalidOperationException();
            }
        }

        static CanvasGeometryCombine Combine(Wd.Mgcg.CanvasGeometryCombine value)
        {
            switch (value)
            {
                case Wd.Mgcg.CanvasGeometryCombine.Union:
                    return CanvasGeometryCombine.Union;
                case Wd.Mgcg.CanvasGeometryCombine.Exclude:
                    return CanvasGeometryCombine.Exclude;
                case Wd.Mgcg.CanvasGeometryCombine.Intersect:
                    return CanvasGeometryCombine.Intersect;
                case Wd.Mgcg.CanvasGeometryCombine.Xor:
                    return CanvasGeometryCombine.Xor;
                default:
                    throw new InvalidOperationException();
            }
        }

        sealed class ReferenceEqualsComparer : IEqualityComparer<object>
        {
            bool IEqualityComparer<object>.Equals(object x, object y) => ReferenceEquals(x, y);
            int IEqualityComparer<object>.GetHashCode(object obj) => obj.GetHashCode();
        }
    }
}
