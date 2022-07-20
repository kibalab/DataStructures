using System;
using System.Collections.Generic;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public interface IComparable
    {
        public static bool operator >(IComparable a, IComparable b) => a > b;
        public static bool operator <(IComparable a, IComparable b) => a < b;
    }

    public class CustomHeap<T> where T : IComparable
    {
        public CustomHeap()
        {  }

        public List<IComparable> heap = new List<IComparable>(); //Use List<> instead of DynamicArray

        public void Add(IComparable data)
        {
            heap.Add(data);

            var lastIndex = heap.Count - 1;
            OrderFromEnd(lastIndex);
        }

        public IComparable Remove(int index)
        {
            var removedObject = heap[index];

            var lastIndex = heap.Count - 1;
            heap[index] = heap[lastIndex];
            heap.RemoveAt(lastIndex);

            OrderFromFirst(index);

            return removedObject;
        }

        public void OrderFromEnd(int lastIndex)
        {
            var parentIndex = lastIndex / 2;
            if (heap[lastIndex] > heap[parentIndex])
            {
                var tmp = heap[parentIndex];
                heap[parentIndex] = heap[lastIndex];
                heap[lastIndex] = tmp;
                OrderFromEnd(parentIndex);
            }
        }

        public void OrderFromFirst(int parentIndex)
        {
            var leftChildIndex = parentIndex / 2;
            var rightChildIndex = leftChildIndex + 1;

            var largestIndex = -1;
            if(heap[leftChildIndex] > heap[rightChildIndex])
            {
                if (heap[leftChildIndex] < heap[parentIndex]) return;
                largestIndex = leftChildIndex;
            }
            else
            {
                if (heap[rightChildIndex] < heap[parentIndex]) return;
                largestIndex = rightChildIndex;
            }

            var tmp = heap[largestIndex];
            heap[largestIndex] = heap[parentIndex];
            heap[parentIndex] = tmp;
            OrderFromFirst(largestIndex);
        }
    }
}
