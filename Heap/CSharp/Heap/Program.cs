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

    }
}
