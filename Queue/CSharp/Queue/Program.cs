using System;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Test
            var queue = new CustomQueue<string>(10);
            queue.Enqueue("Hello");
            queue.Enqueue("World");
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue()); // Underflow

            #endregion Test
        }
    }

    public class CustomQueue<T> where T : class
    {
        T[] data;
        int front = -1;
        int rear = -1;

        public CustomQueue(int size)
        {
            data = new T[size];
        }

        public void Enqueue(T item)
        {
            if(IsFull()) { Console.WriteLine("[Queue] Overflow"); return; }

            data[++rear] = item;
        }

        public T Dequeue()
        {
            if(IsEmpty()) { Console.WriteLine("[Queue] Underflow"); return null; }

            return data[++front];
        }

        public bool IsFull() => rear + 1 >= data.Length;

        public bool IsEmpty() => rear <= front;
    }
}
