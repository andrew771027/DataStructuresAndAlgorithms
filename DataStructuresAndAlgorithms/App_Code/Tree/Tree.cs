using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms.App_Code.Tree
{
    /// <summary>
    /// Action of Tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Tree<T> : Node<T>
    {
        private Node<T> root;
        /// <summary>
        /// Constructor
        /// </summary>
        public Tree()
        { 
        }
        /// <summary>
        /// Constructor, Initialize the root node.
        /// </summary>
        /// <param name="value"></param>
        public Tree(T value)
        {
            root = new Node<T>(value);
            root.Level = 1;
        }
        /// <summary>
        /// Add a child node under parent node which was searched through BFS of DFS.  
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        public void Add(Node<T> parent, Node<T> child)
        {
            if (parent.isRoot())
            {
                root.Childeren.Add(child);
                child.Parent = root;
                child.Level = parent.Level + 1;
            }
            else
            {
                parent.Childeren.Add(child);
                child.Parent = parent;
                child.Level = parent.Level + 1;
            }
        }
        /// <summary>
        /// Add child tree under the parent node.
        /// </summary>
        /// <param name="child"></param>
        public void Add(Node<T> parent, Tree<T> appendTree)
        {

            appendTree.root = parent;
            parent.Childeren.Add(appendTree.root);
            appendTree.root.Level = parent.Level + 1;
          
        }
        /// <summary>
        /// Get the number of the brunches
        /// </summary>
        /// <param name="currentNode"></param>
        /// <returns></returns>
        public int Degree(Node<T> currentNode)
        { 
            return currentNode.Count;
        }
        /// <summary>
        /// Delete the node
        /// </summary>
        /// <param name="currentNode"></param>
        public void Delete(Node<T> currentNode)
        {
            currentNode = null;
        }
        /// <summary>
        /// Compare wheather the currentNode is same as targetNode.
        /// </summary>
        /// <param name="currentNode"></param>
        /// <param name="targetNode"></param>
        /// <returns></returns>
        public Boolean ComparedNodes(Node<T> currentNode, Node<T> targetNode, out Node<T> findNode)
        {
            if (currentNode == targetNode)
            {
                findNode = currentNode;
                return true;
            }
            findNode = null;
            return false;
        }
        /// <summary>
        /// Depth First Search by in order
        /// </summary>
        /// <param name="parentNode">Start Node</param>
        /// <param name="targetNode">Target Node</param>
        /// /// <returns>Finded Node</returns>
        public Boolean DepthFirstSearch_InOrder(Node<T> parentNode, Node<T> targetNode, out Node<T> findNode)
        {
            foreach (Node<T> childNode in parentNode.Childeren.ToList())
            {
                if (childNode.Childeren.Count == 0)     //No child, the currentNode is leaf.
                {
                    //Visit
                    if (ComparedNodes(childNode, targetNode, out findNode) == true)
                    {
                        return true;
                    } 
                }
                else                                 //the currentNode is still a sub tree.
                {
                    DepthFirstSearch_InOrder(childNode, targetNode , out findNode);
                }
            }
            findNode = null;
            return false;
        }
        /// <summary>
        /// Depth First Search by pre order
        /// </summary>
        /// <param name="parentNode">Start Node</param>
        /// <param name="targetNode">TargetNode</param>
        /// <returns>Finded Node</returns>
        public Boolean DepthFirstSearch_PreOrder(Node<T> parentNode, Node<T> targetNode, out Node<T> findNode)
        {
            //Visit
            if (ComparedNodes(parentNode, targetNode, out findNode) == true)
            {
                return true;
            }

            if (parentNode.Childeren.Count == 0)       //No child, the currentNode is leaf.
            {
                //Visit
                if (ComparedNodes(parentNode, targetNode, out findNode) == true)
                {
                    return true;
                } 
            }
            else
            {
                foreach (Node<T> childNode in parentNode.Childeren.ToList())
                {
                    DepthFirstSearch_PreOrder(childNode, targetNode, out findNode);
                }
            }
            findNode = null;
            return false;
        }
        /// <summary>
        /// Depth First Search by post order
        /// </summary>
        /// <param name="parentNode">Start Node</param>
        /// <param name="targetNode">Target Node</param>
        /// <returns>Finded Node</returns>
        public Boolean DepthFirstSearch_Postorder(Node<T> parentNode, Node<T> targetNode, out Node<T> findNode)
        {
            foreach (Node<T> childNode in parentNode.Childeren.ToList())
            {
                if (childNode.Childeren.Count == 0)  //No child, the currentNode is leaf
                {
                    //Visit
                    if (ComparedNodes(childNode, targetNode, out findNode) == true)
                    {
                        return true;
                    } 
                }
                else
                {
                    DepthFirstSearch_Postorder(childNode, targetNode, out findNode);
                }

                //Visit
                if (ComparedNodes(childNode, targetNode, out findNode) == true)
                {
                    return true;
                } 
            }

            findNode = null;
            return false;
        }
    }
}
