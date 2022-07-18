using System;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Test
            var stack = new CustomStack<string>(2);

            stack.Push("Hello");
            Console.WriteLine(stack.Pop());
            stack.Push("World");
            stack.Push("!");
            stack.Push("Hello"); // Overflow
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop()); // UnderFlow
            #endregion Test
        }

        public class CustomStack<T> where T : class
        {
            T[] data = new T[1];
            private int top = -1;

            public CustomStack(int size)
            {
                this.data = new T[size];
            }

            public void Push(T newData)
            {
                if (IsFull()) { Console.WriteLine("[Stack] Overflow"); return; }

                data[++top] = newData;
            }

            public T Pop()
            {
                if (IsEmpty()) { Console.WriteLine("[Stack] Underflow"); return null; }

                return data[top--];
            }

            public T Peek(int index)
            {
                if (index > top) { Console.WriteLine("[Stack] NullException"); return null; }

                return data[top--];
            }

            public T this[int index] => Peek(index); // Same the Peek()

            public bool IsFull() => top + 1 >= data.Length;

            public bool IsEmpty() => top < 0;
        }
    }
}
