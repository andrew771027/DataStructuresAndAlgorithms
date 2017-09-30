using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms.App_Code.BinaryTree
{
    public class Node<T>
    {
        private Node<T> parent = null;
        internal Node<T> Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        private Node<T> right = null;
        internal Node<T> Right
        {
            get { return right; }
            set { right = value; }
        }

        private Node<T> left = null;
        internal Node<T> Left
        {
            get { return left; }
            set { left = value; }
        }

        private int level = 0;
        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        private T value;
        public T Value
        {
            get { return this.value; }
            
        }

        public Node()
        { 
        }
        public Node(T value)
        {
            this.value = value;
        }
    }
}
