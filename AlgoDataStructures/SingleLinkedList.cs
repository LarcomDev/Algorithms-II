using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDataStructures
{
    public class SingleLinkedList<T> where T : IComparable
    {
        public int Count { get; set; } = 0;
        public SNode<T> Head = null;

        public void Add(T val)
        {
           if(Head == null)
            {
                Head = new SNode<T>(val);
                Count++;
            } else
            {
                SNode<T> Current = Head;
                while(Current.Next !=  null)
                {
                    Current = Current.Next;
                }
                Current.Next = new SNode<T>(val);
                Count++;
            }
        }

        public void Insert(T val, int index)
        {
            if(index > Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            } else
            {
                //if list is empty, just insert it as the first item instead
                if (Head == null)
                {
                    Head = new SNode<T>(val);
                }
                else
                {
                    int ct = 0;
                    SNode<T> Current = Head;
                    SNode<T> NextNode;
                    while(ct < index)
                    {
                        Current = Current.Next;
                        ct++;
                    }
                    NextNode = Current.Next;
                    SNode<T> InsertNode = new SNode<T>(val);
                    InsertNode.Next = NextNode;
                    Current.Next = InsertNode;
                    Count++;
                }
            }
        }

        public T Get(int index)
        {
            SNode<T> Current;
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            } else
            {
                int ct = 0;
                Current = Head;
                while(ct != index)
                {
                    ct++;
                    Current = Current.Next;
                }
            }
            return Current.Data;
        }

        public T Remove()
        {
            SNode<T> Current = Head;
            SNode<T> NextNode = Current.Next;
            Head = NextNode;
            Count--;
            return Current.Data;
        }

        public T RemoveLast()
        {
            SNode<T> Current = Head;
            SNode<T> PrevNode = null;
            while (Current.Next != null)
            {
                PrevNode = Current;
                Current = Current.Next;
            }
            PrevNode.Next = null;
            Count--;
            return Current.Data;
        }

        public override string ToString()
        {
            string ListString = "";
            SNode<T> Current = Head;
            ListString += Current.Data + ", ";
            while(Current.Next!= null)
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
            SNode<T> Current = Head;
            int index = 0;
            while(Current.Next != null)
            {
                if(Current.Data.CompareTo(val) == 0)
                {
                    return index;
                }
                Current = Current.Next;
                index++;
            }
            return -1;
        }
    }

    public class SNode<T>
    {
        public SNode(T data){
            this.Data = data;
        }
        public T Data { get; set; }
        public SNode<T> Next { get; set; } = null;
        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
