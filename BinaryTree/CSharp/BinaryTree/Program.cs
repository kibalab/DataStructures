using System;
using System.Collections.Generic;

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
        public enum direction { Left, Right }

        public class node
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

            public override string ToString()
            {
                return $"(Node|{data})";
            }
        }       
        
        public CustomTree(node Root)
        { this.Root = Root; }

        public node Root;

        public node Add(node parent, direction dir, T data)
        {
            switch(dir)
            {
                case direction.Left:
                    var newLeftNode = new node(data, null, null);
                    if (parent.left == null) parent.left = newLeftNode;
                    else Console.WriteLine("[BinaryTree] Left is already exist");
                    return newLeftNode;

                case direction.Right:
                    var newRightNode = new node(data, null, null);
                    if (parent.right == null) parent.right = newRightNode;
                    else Console.WriteLine("[BinaryTree] Right is already exist");
                    return newRightNode;
            }

            return null;
        }

        public void Remove(node parent, direction dir, T data)
        {
            switch (dir)
            {
                case direction.Left:
                    parent.left = null;
                    break;

                case direction.Right:
                    parent.right = null;
                    break;
            }
        }

        public List<node> GetNodesInOrder()
        {
            var treeNodes = new List<node>();

            _InOrder(Root, treeNodes);

            return treeNodes;
        }

        public List<node> GetNodesPreOrder()
        {
            var treeNodes = new List<node>();

            _PreOrder(Root, treeNodes);

            return treeNodes;
        }

        public List<node> GetNodesPostOrder()
        {
            var treeNodes = new List<node>();

            _PostOrder(Root, treeNodes);

            return treeNodes;
        }

        private void _InOrder(node? parent, List<node> list)
        {
            if (parent == null) return;
            _InOrder(parent.left, list);
            list.Add(parent);
            _InOrder(parent.right, list);
        }

        private void _PreOrder(node? parent, List<node> list)
        {
            if (parent == null) return;
            list.Add(parent);
            _InOrder(parent.left, list);
            _InOrder(parent.right, list);
        }

        private void _PostOrder(node? parent, List<node> list)
        {
            if (parent == null) return;
            _InOrder(parent.left, list);
            _InOrder(parent.right, list);
            list.Add(parent);
        }
    }
}
