using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms1.Sorters
{
    [DebuggerDisplay("{\"[\" + string.Join(\", \", this) + \"]\"}")]
    internal struct ArrayRange<TElement>: IList<TElement>
    {
        private readonly TElement[] _array;
        private readonly int _startIndex;
        private readonly int _length;

        [DebuggerStepThrough]
        public ArrayRange(TElement[] array, int startIndex, int length)
        {
            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            if (startIndex + length > array.Length)
                throw new ArgumentOutOfRangeException();

            _array = array;
            _startIndex = startIndex;
            _length = length;
        }

        [DebuggerStepThrough]
        public ArrayRange(ArrayRange<TElement> array, int startIndex, int length)
        {
            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            if (startIndex + length > array.Length)
                throw new ArgumentOutOfRangeException();

            _array = array._array;
            _startIndex = startIndex + array._startIndex;
            _length = length;
        }

        public int Length => _length;

        public int Count => _length;

        public bool IsReadOnly => true;

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= _length)
                throw new ArgumentOutOfRangeException(nameof(index));
        }

        public int IndexOf(TElement item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index,
            TElement item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public TElement this[int index]
        {
            get
            {
                ValidateIndex(index);
                return _array[_startIndex + index];
            }
            set
            {
                ValidateIndex(index);
                _array[_startIndex + index] = value;
            }
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            for (int i = 0; i < _length; i++)
                yield return this[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        void ICollection<TElement>.Add(TElement item)
        {
            throw new InvalidOperationException("Collection was of a fixed size.");
        }

        void ICollection<TElement>.Clear()
        {
            throw new NotSupportedException("Collection is read-only.");
        }

        bool ICollection<TElement>.Contains(TElement item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(ArrayRange<TElement> range,
            int arrayIndex)
        {
            Array.Copy(_array, _startIndex, range._array, range._startIndex + arrayIndex, _length);
        }

        public void CopyTo(TElement[] array,
            int arrayIndex)
        {
            Array.Copy(_array, _startIndex, array, arrayIndex, _length);
        }

        bool ICollection<TElement>.Remove(TElement item)
        {
            throw new NotImplementedException();
        }

        public bool UsesSameArrayAs(ArrayRange<TElement> range)
        {
            return ReferenceEquals(_array, range._array);
        }
    }
}