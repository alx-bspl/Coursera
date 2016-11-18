using System.Collections.Generic;

namespace Algorithms1.Heaps
{
    public interface IHeapMin<TElement> : ICollection<TElement>
    {
        TElement GetMin();
    }
}