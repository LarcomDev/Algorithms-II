using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDataStructures.AVLTree
{
    public class AVLNode <T> where T : IComparable
    {
        public T Data { get; set; }
        public AVLNode<T> Left;
        public AVLNode<T> Right;
        public AVLNode<T> Parent;

        public AVLNode(T val, AVLNode<T> parent)
        {
            this.Data = val;
            this.Parent = parent;
        }

        public AVLNode<T> Add(T val)
        {
            if (val.CompareTo(Data) < 0)
            {
                if (Left == null)
                {
                    Left = new AVLNode<T>(val, this);
                }
                else
                {
                    Left = Left.Add(val);
                }
            }
            else if (val.CompareTo(Data) > 0 || val.CompareTo(Data) == 0)
            {
                if (Right == null)
                {
                    Right = new AVLNode<T>(val, this);
                }
                else
                {
                    Right = Right.Add(val);
                }
            }
            return Balance(this);
        }

        public AVLNode<T> Remove(AVLNode<T> node, T val)
        {
            if (node == null) return null;
            if (val.CompareTo(node.Data) < 0)
            {
                node.Left = Remove(node.Left, val);
            }
            else if (val.CompareTo(node.Data) > 0)
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
            return Balance(this);
        }

        public T MaxValue(AVLNode<T> node)
        {
            while (node.Right != null)
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
        public int GetBalanceFactor(AVLNode<T> node)
        {
            int leftH = 0;
            int rightH = 0;
            if(node.Left != null)
            {
                leftH = node.Left.Height();
            }
            if(node.Right != null)
            {
                rightH = node.Right.Height();
            }
            return leftH - rightH;
        }

        private AVLNode<T> Balance(AVLNode<T> node)
        {
             AVLNode<T> pivot;
            if(GetBalanceFactor(this) < -1)
            {
                if(GetBalanceFactor(Right) > 0)
                {
                    //LR
                    RightRotate(node.Right);
                    pivot = LeftRotate(node);
                } else
                {
                    //L
                    pivot = LeftRotate(node);
                }
                return pivot;
            } 
            else if(GetBalanceFactor(this) > 1)
            {
                if(GetBalanceFactor(Left) < 0)
                {
                    //RL
                    LeftRotate(node.Left);
                    pivot = RightRotate(node);
                } else
                {
                    //R
                    pivot = RightRotate(node);
                }
                return pivot;
            }
            return node;
        }


        private AVLNode<T> LeftRotate(AVLNode<T> node)
        {
            AVLNode<T> piv = node.Right;
            node.Right = piv.Left;
            piv.Left = node;
            piv.Parent = node.Parent;
            node.Parent = piv;
            return piv;
        }

        private AVLNode<T> RightRotate(AVLNode<T> node)
        {
            AVLNode<T> piv = node.Left;
            node.Left = piv.Right;
            piv.Right = node;
            piv.Parent = node.Parent;
            node.Parent = piv;
            return piv;
        }

        public List<T> ToArray(List<T> arr, int levelToAdd) 
        {
            if (levelToAdd == 0) arr.Add(Data);
            if(Left != null) arr = Left.ToArray(arr, levelToAdd - 1);
            if (Right != null) arr = Right.ToArray(arr, levelToAdd - 1);
            return arr;
        }
    }
}
