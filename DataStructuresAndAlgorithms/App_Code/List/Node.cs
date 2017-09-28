using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms.App_Code.List
{
    internal class Node<T>
    {
        private T value;
        private Node<T> previous = null;
        private Node<T> next = null;

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        internal Node<T> Previous
        {
            get { return previous; }
            set { previous = value; }
        }

        internal Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        //Constructer
        internal Node(T value)
        {
            Value = value;
        }
    }
}
