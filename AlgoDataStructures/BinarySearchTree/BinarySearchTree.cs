using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDataStructures.BinarySearchTree
{
    public class BinarySearchTree<T> where T : IComparable
    {
        public int Count { get; set; } = 0;
        public BinaryTreeNode<T> Root = null;

        public void Add(T val)
        {
            if(Root == null)
            {
                Root = new BinaryTreeNode<T>(val, null);
            } else
            {
                Root.Add(val);
            }
            Count++;
        }
        public void Remove(T val)
        {
            if(Root != null && Contains(val))
            {
                Root.Remove(Root, val);
                Count--;
            }
        }

        public Boolean Contains(T val)
        {
            return Root != null ? Root.Contains(val) : false;
        }

        public int Height()
        {
            return Root != null ? Root.Height() : 0;
        }

        public void Clear()
        {
            Count = 0;
            Root = null;
        }

        public string InOrder()
        {
            if(Root != null)
            {
                string returnVal = Root.InOrder();
                //remove extra comma and space included
                return returnVal.Trim().TrimEnd(',');
            }
            return null;
        }

        public string PreOrder()
        {
            if(Root != null)
            {
                string returnVal = Root.PreOrder();
                //remove extra comma and space included
                return returnVal.Trim().TrimEnd(',');
            }
            return null;
        }

        public string PostOrder()
        {
            if(Root != null)
            {
                string returnVal = Root.PostOrder();
                //remove the extra comma and space included
                return returnVal.TrimStart(',').Trim();
            }
            return null;
        }

        public T[] ToArray()
        {
            T[] arr = new T[Count];
            if(Root != null) {
                Root.ToArray(arr, 0);
                return arr;
            }
            return null;
        }
    }
}
