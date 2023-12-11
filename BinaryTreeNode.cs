using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeEnrolmentSystem
{
    public class BinaryTreeNode<T>
    {
        public T Data { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree<T>
    {
        private BinaryTreeNode<T> root;

        public void Add(T data)
        {
            root = AddRecursive(root, data);
        }

        private BinaryTreeNode<T> AddRecursive(BinaryTreeNode<T> node, T data)
        {
            if (node == null)
            {
                return new BinaryTreeNode<T>(data);
            }

            // Recursively insert into the left or right subtree
            if (Comparer<T>.Default.Compare(data, node.Data) < 0)
            {
                node.Left = AddRecursive(node.Left, data);
            }
            else
            {
                node.Right = AddRecursive(node.Right, data);
            }

            return node;
        }


        public void PreOrderTraversal()
        {
            PreOrderTraversal(root);
        }

        private void PreOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                Console.Write($"{node.Data} ");
                PreOrderTraversal(node.Left);
                PreOrderTraversal(node.Right);
            }
        }

        public void InOrderTraversal()
        {
            InOrderTraversal(root);
        }

        private void InOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left);
                Console.Write($"{node.Data} ");
                InOrderTraversal(node.Right);
            }
        }

        public void PostOrderTraversal()
        {
            PostOrderTraversal(root);
        }

        private void PostOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                PostOrderTraversal(node.Left);
                PostOrderTraversal(node.Right);
                Console.Write($"{node.Data} ");
            }
        }

    }
}