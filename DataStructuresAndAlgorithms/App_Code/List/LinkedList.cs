using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms.App_Code.List
{
    internal abstract class LinkedList<T>
    {
        private int count = 0;
        private Node<T> first = null;
        private Node<T> last = null;

        internal Node<T> Last
        {
            get { return last; }
            set { last = value; }
        }

        internal Node<T> First
        {
            get { return first; }
            set { first = value; }
        }

        protected int Count
        {
            get { return count; }
            set { count = value; }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public LinkedList()
        { 
        }

        internal Node<T> GetFirst()
        {
            return First;
        }
        internal Node<T> GetLast()
        {
            return Last;
        }
        internal abstract void AddFirst(T value);
        internal abstract void AddLast(T value);
        internal abstract void AddBefore(Node<T> node, T value);
        internal abstract void AddAfter(Node<T> node, T value);
        internal abstract void RemoveFirst();
        internal abstract void RemoveLast();
        internal abstract void RemoveNode(Node<T> node);
        internal abstract void Clear();
        internal abstract LinkedList<T> Reverse();

    }

    

}
