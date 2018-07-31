// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;

namespace WinCompData.Tools
{
#if !WINDOWS_UWP
    public
#endif
    sealed class ListOfNeverNull<T> : IList<T>
    {
        readonly List<T> _wrapped = new List<T>();
        readonly IListOfNeverNullOwner _owner;

        internal ListOfNeverNull(IListOfNeverNullOwner owner)
        {
            _owner = owner;
        }

        public T this[int index]
        {
            get => _wrapped[index];

            set => _wrapped[index] = AssertNotNull(value);
        }

        public int Count => _wrapped.Count;

        bool ICollection<T>.IsReadOnly => ((IList<T>)_wrapped).IsReadOnly;

        public void Add(T item)
        {
            _wrapped.Add(AssertNotNull(item));
            if (_owner != null)
            {
                _owner.ItemAdded(item);
            }
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public void Clear()
        {
            var oldContents = _wrapped.ToArray();
            _wrapped.Clear();
            if (_owner != null)
            {
                foreach (var item in oldContents)
                {
                    _owner.ItemRemoved(item);
                }
            }
        }

        bool ICollection<T>.Contains(T item)
        {
            return _wrapped.Contains(item);
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            _wrapped.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IList<T>)_wrapped).GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return _wrapped.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _wrapped.Insert(index, AssertNotNull(item));
            if (_owner != null)
            {
                _owner.ItemAdded(item);
            }
        }

        public bool Remove(T item)
        {
            var result = _wrapped.Remove(item);
            if (result && _owner != null)
            {
                _owner.ItemRemoved(item);
            }
            return result;
        }

        public void RemoveAt(int index)
        {
            if (_owner != null)
            {
                _owner.ItemRemoved(_wrapped[index]);
            }
            _wrapped.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<T>)_wrapped).GetEnumerator();
        }

        static T AssertNotNull(T item)
        {
            if (item == null)
            {
                throw new ArgumentException();
            }
            return item;
        }

        public override string ToString()
        {
            var tName = typeof(T).Name;
            switch(Count)
            {
                case 0:
                    return $"Empty List<{tName}>";
                case 1:
                    return $"List<{tName}> with 1 item";
                default:
                    return $"List<{tName}> with {Count} items";
            }
        }

        internal interface IListOfNeverNullOwner
        {
            void ItemAdded(T item);
            void ItemRemoved(T item);
        }
    }
}
