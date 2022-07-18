using System;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Test
            var queue = new CustomDeque<string>(4);
            queue.Add_Rear("Hello");
            queue.Add_Rear("World");

            queue.Add_Front("Hello");
            queue.Add_Front("World");
            Console.WriteLine(queue.Remove_Rear());
            Console.WriteLine(queue.Remove_Rear());
            Console.WriteLine(queue.Remove_Front());
            Console.WriteLine(queue.Remove_Front()); // Underflow

            #endregion Test
        }
    }

    public class CustomDeque<T> where T : class
    {
        T[] data;
        int front = 0;
        int rear = 0;

        public CustomDeque(int size)
        {
            data = new T[size + 1];
        }

        public void Add_Rear(T item)
        {
            if (IsFull()) { Console.WriteLine("[Queue] Overflow"); return; }

            rear = Next(rear);
            data[rear] = item;
        }

        public T Remove_Rear()
        {
            if (IsEmpty()) { Console.WriteLine("[Queue] Underflow"); return null; }

            front = Next(front);
            return data[front];
        }

        public void Add_Front(T item)
        {
            if (IsFull()) { Console.WriteLine("[Queue] Overflow"); return; }

            data[front] = item;
            front = Privious(front);
        }

        public T Remove_Front()
        {
            if (IsEmpty()) { Console.WriteLine("[Queue] Underflow"); return null; }
            var item = data[rear];
            rear = Privious(rear);
            return item;
        }

        private int Next(int index) => ++index % data.Length;

        private int Privious(int index) => (--index + data.Length) % data.Length;

        public bool IsFull() => Next(rear) == front;

        public bool IsEmpty() => rear == front;
    }
}
