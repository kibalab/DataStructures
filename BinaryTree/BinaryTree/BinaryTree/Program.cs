using System;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    

    public class CustomTree<T> where T : class
    {
        enum direction { Left, Right }

        class node
        {
            public T data;
            public node left;
            public node right;

            public node(T data, node left, node right)
            {
                this.data = data;
                this.left = left;
                this.right = right;
            }
        }       
        
        public CustomTree()
        {  }

        public void Add(node parent, direction dir, T data)
        {
            switch(dir)
            {
                case direction.Left:
                    var newLeftNode = new node(data, null, null);
                    if (parent.left == null) parent.left = newLeftNode;
                    else Console.WriteLine("[BinaryTree] Left is already exist");
                    break;

                case direction.Right:
                    var newRightNode = new node(data, null, null);
                    if (parent.left == null) parent.right = newRightNode;
                    else Console.WriteLine("[BinaryTree] Right is already exist");
                    break;
            }
        }
    }
}
