using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms.App_Code.List
{
    internal class DoublyLinkedList<T> : LinkedList<T>
    {
        internal override void AddAfter(Node<T> node, T value)
        {
            Node<T> AddNode = new Node<T>(value);

            if (node == Last)
            {
                AddLast(value);
                return;
            }

            AddNode.Next = node.Next;
            AddNode.Previous = node;
            node.Next = AddNode;

            Count++;

        }
        internal override void AddBefore(Node<T> node, T value)
        {
            Node<T> AddNode = new Node<T>(value);

            if (node == First)
            {
                AddFirst(value);
                return;
            }

            AddNode.Previous = node.Previous;
            AddNode.Next = node;
            node.Previous = AddNode;

            Count++;
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
                First.Previous = node;
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
                node.Previous = Last;
            }
            Last = node;
            Count++;
        }
        internal override void RemoveFirst()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (Count == 1)
            {
                First = null;
                Last = null;
            }
            else
            {
                Node<T> node = First.Next;
                First = null;
                node.Previous = null;
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
                First = null;
                Last = null;
            }
            else
            {
                Node<T> node = Last.Previous;
                Last = null;
                node.Next = null;
                Last = node;
            }
            Count--;
        }
        internal override void RemoveNode(Node<T> node)
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (Count == 1)
            {
                RemoveFirst();
            }
            else
            {
                Node<T> preNode = node.Previous;
                Node<T> postNode = node.Next;

                preNode.Next = postNode;
                postNode.Previous = preNode;
                node = null;
            }
            Count--;
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

            DoublyLinkedList<T> reversedList = new DoublyLinkedList<T>();

            while (currentNode.Previous != null)
            {
                reversedList.AddLast(currentNode.Value);

                currentNode = currentNode.Previous;
            }
            reversedList.AddLast(this.First.Value);

            return reversedList;
        }
    }
}
