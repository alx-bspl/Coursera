using System.Collections.Generic;

namespace Algorithms1.Sorters
{
    public abstract class QuickSorter<T>: ISorter<T>
    {
        public IComparer<T> Comparer { get; }

        protected QuickSorter(IComparer<T> comparer)
        {
            Comparer = comparer;
        }

        protected QuickSorter(): this(Comparer<T>.Default)
        {
        }

        public void Sort(T[] array)
        {
            Sort(new ArrayRange<T>(array, 0, array.Length));
        }

        internal abstract int ChoosePivotIndex(ArrayRange<T> range);

        private void Swap(ArrayRange<T> range,
            int index1,
            int index2)
        {
            if (index1 != index2)
            {
                var temp = range[index1];
                range[index1] = range[index2];
                range[index2] = temp;
            }
        }


        private void Sort(ArrayRange<T> range)
        {
            if(range.Length <= 1)
                return;

            Swap(range, 0, ChoosePivotIndex(range));
            int pivotIndex = 0;
            T pivot = range[pivotIndex];

            int i = pivotIndex + 1;
            for (int j = pivotIndex + 1; j < range.Length; j++)
                if (Comparer.Compare(range[j], pivot) < 0)
                    Swap(range, j, i++);

            Swap(range, pivotIndex, i-1);
            pivotIndex = i-1;
            Sort(new ArrayRange<T>(range, 0, pivotIndex));
            Sort(new ArrayRange<T>(range, pivotIndex + 1, range.Length - pivotIndex - 1));
        }
    }
}