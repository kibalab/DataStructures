using System;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Test
            var queue = new CustomCircularQueue<string>(3);
            queue.Enqueue("Hello");
            queue.Enqueue("World");
            queue.Enqueue("Hello");
            queue.Enqueue("World"); // Overflow
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue()); // Underflow

            #endregion Test
        }
    }

    public class CustomCircularQueue<T> where T : class
    {
        T[] data;
        int front = 0;
        int rear = 0;

        public CustomCircularQueue(int size)
        {
            data = new T[size + 1];
        }

        public void Enqueue(T item)
        {
            if (IsFull()) { Console.WriteLine("[Queue] Overflow"); return; }

            rear = Next(rear);
            data[rear] = item;
        }

        public T Dequeue()
        {
            if (IsEmpty()) { Console.WriteLine("[Queue] Underflow"); return null; }

            front = Next(front);
            return data[front];
        }

        private int Next(int index) => ++index % data.Length;

        public bool IsFull() => Next(rear) == front;

        public bool IsEmpty() => rear == front;
    }
}
