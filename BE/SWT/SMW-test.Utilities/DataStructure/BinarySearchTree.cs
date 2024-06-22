using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMW_test.Utilities.DataStructure
{
    public class BinarySearchTree
    {
        private class Node
        {
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int value)
            {
                this.Value = value;
            }
        }

        private Node root;

        public void Add(int value)
        {
            root = AddRecursively(root, value);
        }

        private Node AddRecursively(Node node, int value)
        {
            if (node == null)
            {
                return new Node(value);
            }

            if (value < node.Value)
            {
                node.Left = AddRecursively(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = AddRecursively(node.Right, value);
            }

            return node;
        }

        public int? GetMax()
        {
            if (root == null)
                return null;

            Node current = root;
            while (current.Right != null)
            {
                current = current.Right;
            }
            return current.Value;
        }

        public int? GetMin()
        {
            if (root == null)
                return null;

            Node current = root;
            while (current.Left != null)
            {
                current = current.Left;
            }
            return current.Value;
        }
    }
    public class DataStructureModel
    {
        public string DataStructure { get; set; }
    }
}
