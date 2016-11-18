using System.Collections.Generic;

namespace Algorithms1.Heaps
{
    public interface IHeapMax<TElement> : ICollection<TElement>
    {
        TElement GetMax();
    }
}