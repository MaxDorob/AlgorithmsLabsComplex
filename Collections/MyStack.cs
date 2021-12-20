using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    public class MyStack<T> :MyLinkedList<T>
    {
        public void Push(T item)
        {
            this.Add(item);
        }

        public T Pop()
        {
            T toReturn = this.LastElement.Element;
            this.RemoveAt(Count - 1);
            return toReturn;

        }
        public T Peek()
        {
            return this.LastElement.Element;
        }
        #region Old
        //private int count=0;
        //public int Count
        //{
        //    get=>count;
        //    private set => count=value;
        //}
        //Node<T> LastNode;

        //public void Push(T item)
        //{
        //    Count++;
        //    if(LastNode==null)
        //        LastNode = new Node<T>() { Element = item };
        //    else
        //    {
        //        var newNode = new Node<T>() { Element = item, NextElement = LastNode };
        //        LastNode = newNode;
        //    }
        //}
        //public T Pop()
        //{
        //    if (LastNode == null)
        //        throw new ArgumentOutOfRangeException("Sequnce doenst contains elements");
        //    T toReturn = LastNode.Element;
        //    LastNode=LastNode.NextElement;
        //    count--;
        //    return toReturn;
        //}
        //public T Peek()=>LastNode.Element; 
        #endregion

    }
}
