using System;

namespace PriorityQ
{
    public class PriorityQueue
    {
        private HeapClass.Heap NewHeap { get; set; }
        public PriorityQueue(int size=10)
        {
            NewHeap = new HeapClass.Heap(size);
        }
        public void AddItem(int item)
        {
            NewHeap.AddItem(item);
        }

        public int GetItem()
        {
            return NewHeap.GetItem();
        }
    }
}
