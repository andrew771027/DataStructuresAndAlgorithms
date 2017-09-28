using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms.App_Code.List
{
    internal class SinglyLinkedList<T> : LinkedList<T>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SinglyLinkedList()
        { 
        }
        
        internal override void AddFirst(T value)
        {
            Node<T> node = new Node<T>(value);

            if (Count == 0)
            {
                Last = node;
            }
            else 
            {
                node.Next = First;
            }
            First = node;
            Count++;
        }
        internal override void AddLast(T value)
        {
            Node<T> node = new Node<T>(value);

            if (Count == 0)
            {
                First = node;
            }
            else 
            {
                Last.Next = node;
            }
            Last = node;
            Count++;
        }
        internal override void AddAfter(Node<T> node, T value)
        {
            Node<T> addNode = new Node<T>(value);

            addNode.Next = node.Next;
            node.Next = addNode;

            if (node == Last)
            {
                Last = addNode;
            }
            
            Count++; 
            
        }
        internal override void AddBefore(Node<T> node, T value)
        {
            Node<T> addNode = new Node<T>(value);

            addNode.Previous = node.Previous;
            node.Previous = addNode;

            if (node == First)
            {
                First = addNode;
            }
            Count++;
        }
        internal override void RemoveFirst()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (Count ==1)
            {
                First = null;
               
                Last = null;
               
            }
            else
            {
                Node<T> node = First.Next;
                First.Next = null;
                First = node;
            }
            Count--;
            
        }
        internal override void RemoveLast()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (Count == 1)
            {
                Last = null;
                First = null;
            }
            else
            {
                Node<T> node = FindPreviousNode(Last);
                //node.Next = null;
                Last = node;
            }

            Count--;
        }
        internal override void RemoveNode(Node<T> node)
        {
            if (node == First)
            {
                RemoveFirst();
            }
            else if (node == Last)
            {
                RemoveLast();
            }
            else
            {
                Node<T> preNode = FindPreviousNode(node);

                if (preNode == null)
                {
                    throw new IndexOutOfRangeException();
                }

                preNode.Next = node.Next;
                node.Next = null;

                Count--;
            }

        }
        internal override void Clear()
        {
            Node<T> currentNode = First;

            while (currentNode == Last)
            {
                RemoveFirst();
                currentNode = First;
            }

        }
        internal override LinkedList<T> Reverse()
        {
            Node<T> currentNode = Last;

            SinglyLinkedList<T> reversedList = new SinglyLinkedList<T>();

            while (currentNode != First)
            {
                reversedList.AddLast(currentNode.Value);

                currentNode = FindPreviousNode(currentNode);
            }

            reversedList.AddLast(this.First.Value);

            return reversedList;

        }
        private Node<T> FindPreviousNode(Node<T> currentNode)
        {
            Node<T> preNode = First;
            while (preNode != null)
            {
                if (currentNode == preNode.Next)
                {
                    break;
                }
                preNode = preNode.Next;
            }
            return preNode;
        }
    }
}
