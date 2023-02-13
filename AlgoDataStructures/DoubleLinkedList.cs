using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDataStructures
{
    public class DoubleLinkedList<T> where T : IComparable
    {
        public int Count { get; set; }
        public DNode<T> Head = null;
        public void Add(T val)
        {
            if(Head == null)
            {
                Head = new DNode<T>(val);
                Count++;
            } else
            {
                DNode<T> Current = Head;
                while(Current.Next != null)
                {
                    Current = Current.Next;
                }
                DNode<T> NewNode = new DNode<T>(val);
                Current.Next = NewNode;
                NewNode.Previous = Current;
                Count++;
            }
        }

        public void Insert(T val, int index)
        {
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                int ct = 0;
                DNode<T> Current = Head;
                while(ct < index && Current.Next != null)
                {
                    Current = Current.Next;
                    ct++;
                }
                DNode<T> NewNode = new DNode<T>(val);
                NewNode.Next = Current;
                Current.Previous.Next = NewNode;
                NewNode.Previous = Current.Previous;
                Current.Previous = NewNode;
                Count++; 
            }
        }

        public T Get(int index)
        {
            DNode<T> Current;
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                int ct = 0;
                Current = Head;
                while (ct != index)
                {
                    ct++;
                    Current = Current.Next;
                }
            }
            return Current.Data;
        }

        public T Remove()
        {
            DNode<T> Current = Head;
            DNode<T> NextNode = Current.Next;
            Head = NextNode;
            Head.Previous = null;
            Count--;
            return Current.Data;
        }

        public T RemoveLast()
        {
            DNode<T> Current = Head;
            DNode<T> PrevNode = null;
            while (Current.Next != null)
            {
                PrevNode = Current;
                Current = Current.Next;
            }
            PrevNode.Next = null;
            Current.Previous = null;
            Count--;
            return Current.Data;
        }

        public override string ToString()
        {
            string ListString = "";
            DNode<T> Current = Head;
            ListString += Current.Data + ", ";
            while (Current.Next != null)
            {
                Current = Current.Next;
                ListString += Current.Data;
                ListString += ", ";
            }
            string FixedString = ListString.Trim().TrimEnd(',');
            return FixedString;
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        public int Search(T val)
        {
            DNode<T> Current = Head;
            int index = 0;
            while (Current.Next != null)
            {
                if (Current.Data.CompareTo(val) == 0)
                {
                    return index;
                }
                Current = Current.Next;
                index++;
            }
            return -1;
        }
    }

    public class DNode<T>
    {
        public DNode(T data)
        {
            this.Data = data;
        }
        public T Data { get; set; }
        public DNode<T> Previous { get; set; } = null;
        public DNode<T> Next { get; set; } = null;

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
