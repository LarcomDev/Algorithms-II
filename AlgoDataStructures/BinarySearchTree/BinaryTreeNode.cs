using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDataStructures.BinarySearchTree
{
    public class BinaryTreeNode<T> where T : IComparable
    {
        public T Data { get; set; }
        public BinaryTreeNode<T> Left;
        public BinaryTreeNode<T> Right;
        public BinaryTreeNode<T> Parent;

        public BinaryTreeNode(T val, BinaryTreeNode<T> parent) {
            this.Data = val;
            this.Parent = parent;
        }

        public void Add(T val)
        {
            if(val.CompareTo(Data) < 0)
            {
                if(Left == null)
                {
                    Left = new BinaryTreeNode<T>(val, this);
                } else
                {
                    Left.Add(val);
                }
            } else if(val.CompareTo(Data) > 0 || val.CompareTo(Data) == 0)
            {
                if(Right == null)
                {
                    Right = new BinaryTreeNode<T>(val, this);
                } else
                {
                    Right.Add(val);
                }
            }
        }

        public BinaryTreeNode<T> Remove(BinaryTreeNode<T> node, T val)
        {
            if (node == null) return node;
            if(val.CompareTo(node.Data) < 0)
            {
                node.Left = Remove(node.Left, val);
            } 
            else if(val.CompareTo(node.Data) > 0)
            {
                node.Right = Remove(node.Right, val);
            } 
            else
            {
                //one or zero children
                if (node.Left == null)
                {
                    return node.Right;
                }
                else if (node.Right == null)
                {
                    return node.Left;
                }
                node.Data = MaxValue(node.Left);
                node.Left = Remove(node.Left, node.Data);
            }
            return node;
        }

        public T MaxValue(BinaryTreeNode<T> node)
        {
            while(node.Right != null)
            {
                node = node.Right;
            }
            return node.Data;
        }

        public int Height()
        {
            if (Left == null && Right == null) return 1;
            int leftMax = 0;
            int rightMax = 0;
            if (Left != null) leftMax = Left.Height();
            if (Right != null) rightMax = Right.Height();
            return Math.Max(leftMax, rightMax) + 1;
        }

        // Left Root Right
        public string InOrder()
        {
            string leftSide = "";
            string rightSide = "";

            if (Left != null) leftSide = Left.InOrder();
            if (Right != null) rightSide = Right.InOrder();
            return leftSide + Data + ", " + rightSide;

        }

        //Root Left Right
        //TODO: Fix
        public string PreOrder()
        {
            string leftSide = "";
            string rightSide = "";

            if (Left != null) leftSide = Left.PreOrder();
            if (Right != null) rightSide = Right.PreOrder();

            //Need to fix return to account for empty strings
            return Data + ", " + leftSide + rightSide;
        }

        //Left Right Root
        public string PostOrder()
        {
            string leftSide = "";
            string rightSide = "";

            if (Left != null) leftSide = Left.PostOrder();
            if (Right != null) rightSide = Right.PostOrder();

            return leftSide + rightSide + ", " + Data;
        }

        public int ToArray(T[] arr, int curIndex)
        {
            if(Left != null)
            {
                curIndex = Left.ToArray(arr, curIndex);
            }
            arr[curIndex++] = Data;
            if(Right != null)
            {
                curIndex = Right.ToArray(arr, curIndex);
            }
            return curIndex;
        }

        public bool Contains(T val)
        {
            //return true if value is found
            if (val.CompareTo(Data) == 0) return true;

            //recursively call contains down the tree to find a value
            if (val.CompareTo(Data) < 0 && Left.Contains(val)) return true;
            if (val.CompareTo(Data) > 0 && Right.Contains(val)) return true;

            //return false if its not found
            return false;
        }
    }
}
