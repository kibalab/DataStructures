using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Test
            var list = new CustomLinkedList<string>();

            list.Add("H");
            list.Add("L1");
            list.Add("L2");
            list.Add("O");
            list.Remove();
            list.Insert(1, "E");

            for (var i = 0;i < list.Count; i++)
            {
                Console.WriteLine(list.At(i));
            }
            #endregion Test
        }
    }


    public class CustomLinkedList<T> where T : class
    {
        element first = null;
        element last = null;
        public int Count = 0;

        class element
        {
            public T item;
            public element Next;

            public element(T item, element Next)
            {
                this.item = item;
                this.Next = Next;
            }

            public override string ToString()
            {
                return item.ToString();
            }
        }

        public CustomLinkedList()
        {  }

        public void Add(T item)
        {
            var newItem = new element(item, last);

            if (first == null) first = newItem;
            else last.Next = newItem;

            last = newItem;
            Count++;
        }

        public T Remove()
        {
            var item = last.item;

            Count--;
            GetElementByIndex(Count - 1).Next = null;

            return item;
        }

        public void Insert(int index, T item)
        {
            var insertTarget = GetElementByIndex(index - 1);
            insertTarget.Next = new element(item, insertTarget.Next);
            Count++;
        }

        public T At(int index) => GetElementByIndex(index).item;

        private element GetElementByIndex(int index)
        {
            var search = first;
            var c = 0;
            while (true)
            {
                if (c == index) return search;

                search = search.Next;
                c++;
            }
        }
    }
}
