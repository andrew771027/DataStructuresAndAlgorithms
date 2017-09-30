using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms.App_Code.BinaryTree
{
    public class BinaryTree<T> : Node<T>
    {
        private Node<T> root;
        
        public BinaryTree()
        { 
        }
        

        internal void Add(T value)
        {
            if (this.root == null)
            {
                this.root = new Node<T>(value);
                this.Level = 1;
            }
            else 
            { 
                Node<T> child = new Node<T>(value);
                InsertNode(this.root, child);
            }
        }
        private void InsertNode(Node<T> parent, Node<T> child)
        {
            if (parent.Left == null)
            {
                parent.Left = child;
                child.Parent = parent;
                child.Level = parent.Level + 1;
            }
            else if (parent.Right == null)
            {
                parent.Right = child;
                child.Parent = parent;
                child.Level = parent.Level + 1;
            }
            else 
            {
                
                if ((parent.Left).Left == null || (parent.Left).Right == null)
                {
                    InsertNode(parent.Left, child);
                }
                else
                {
                    InsertNode(parent.Right, child);
                }

            }
        }
        /// <summary>
        /// PreOrder: VLR InOrder:LVR PostOrder:LRV
        /// </summary>
        /// <param name="order"></param>
        internal void Traverse( string order)
        {
            if (this.root != null)
            {
               switch (order)
               {
                   case "VLR":
                       PreOrderTraverse(root);
                       break;
                   case "LVR":
                       InOrderTraverse(root);
                       break;
                   case "LRV":
                       PostOrderTraverse(root);
                       break;
                   default:
                       break;
               }
                 

            }
        }
        private void PreOrderTraverse(Node<T> currentNode)
        {
            if (currentNode != null)
            {
                System.Console.WriteLine(string.Format("Level:{0},Value{1}", currentNode.Level ,currentNode.Value));
                PreOrderTraverse(currentNode.Left);
                PreOrderTraverse(currentNode.Right);
            }
        }
        private void InOrderTraverse(Node<T> currentNode)
        {
            if (currentNode != null)
            {
                InOrderTraverse(currentNode.Left);
                System.Console.WriteLine(string.Format("Level:{0},Value{1}", currentNode.Level ,currentNode.Value));
                InOrderTraverse(currentNode.Right);
            }
        }
        private void PostOrderTraverse(Node<T> currentNode)
        {
            if (currentNode != null)
            {
                PostOrderTraverse(currentNode.Left);
                PostOrderTraverse(currentNode.Right);
                System.Console.WriteLine(string.Format("Level:{0},Value{1}", currentNode.Level, currentNode.Value));
                
                
                
            }
        }

        internal Node<T> GetSilbings(Node<T> currentNode)
        {
            if (currentNode.Parent == null)
            { 
                return null;
            }

            if ((currentNode.Parent).Right != null)
            {
                return (currentNode.Parent).Right;
            }
            else if ((currentNode.Parent).Left != null)
            {
                return (currentNode.Parent).Left;
            }
            else
                return null;
        }
    }
}
