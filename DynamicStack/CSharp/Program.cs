using System;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Test
            var stack = new CustomDynamicStack<string>(2);

            stack.Push("Hello");
            Console.WriteLine(stack.Pop());
            stack.Push("World");
            stack.Push("!");
            stack.Push("Hello");
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop()); // UnderFlow
            #endregion Test
        }

        public class CustomDynamicStack<T> where T : class
        {
            T[] data = new T[1];
            private int top = -1;

            public CustomDynamicStack(int size)
            {
                this.data = new T[size];
            }

            // Using Linq's method Concat makes this simple
            // Remalloc(int size) => data.Concat(new T[size - data.Length]);
            private void Remalloc(int size) 
            {
                var newData = new T[size];

                var i = 0;
                foreach(var element in data)
                {
                    if(i < size) newData[i++] = element;
                }
                

                data = newData;
            }

            public void Push(T newData)
            {
                if (IsFull()) { Remalloc(data.Length + 1); }

                data[++top] = newData;
            }

            public T Pop()
            {
                if (IsEmpty()) { Console.WriteLine("[Stack] Underflow"); return null; }

                var element = data[top--];
                Remalloc(data.Length - 1);
                return element;
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
