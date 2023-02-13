using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDataStructures.AVLTree
{
    public class AVLTree <T> where T : IComparable 
    {
        public AVLNode<T> Root = null;
        public int Count { get; set; } = 0;

        public void Add(T val)
        {
            if (Root == null)
            {
                Root = new AVLNode<T>(val, null);
            }
            else
            {
                Root = Root.Add(val);
            }
            Count++;
        }
        public void Remove(T val)
        {
            if (Root != null && Contains(val))
            {
                Root = Root.Remove(Root, val);
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
            if (Root != null)
            {
                string returnVal = Root.InOrder();
                //remove extra comma and space included
                return returnVal.Trim().TrimEnd(',');
            }
            return null;
        }

        public string PreOrder()
        {
            if (Root != null)
            {
                string returnVal = Root.PreOrder();
                //remove extra comma and space included
                return returnVal.Trim().TrimEnd(',');
            }
            return null;
        }

        public string PostOrder()
        {
            if (Root != null)
            {
                string returnVal = Root.PostOrder();
                //remove the extra comma and space included
                return returnVal.TrimStart(',').Trim();
            }
            return null;
        }

        public T[] ToArray()
        {
            List<T> items = new List<T>();
            for(int level = 0; level < Root.Height(); level++)
            {
                Root.ToArray(items, level);
            }
            return items.ToArray();
        }
    }
}
