using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms.App_Code.Tree
{
    /// <summary>
    /// Property of Tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        private T value;

        private Node<T> parent = null;

        private List<Node<T>> childeren = new List<Node<T>>();

        public List<Node<T>> Childeren
        {
            get { return childeren; }
            set { childeren = value; }
        }

        public Node(T value)
        {
            this.value = value;
        }

        private int level;
        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        public Node()
        { 
        }
        public Node<T> Parent
        {
            get { return parent; }
            set { this.parent = value; }
        }

        private int count;
        public int Count
        {
            get { return count; }
            set { count = this.childeren.Count; }
        }

        public bool isRoot()
        {
            return (this.parent == null);
        }
    }
}
