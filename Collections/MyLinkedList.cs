using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    public class MyLinkedList<T> : IEnumerable<T>, IEnumerator<T>
    {
        public MyLinkedList()
        {
            
        }
        protected Node<T> FirstElement;
        protected Node<T> LastElement;//Используется для быстроты добавления дабы не перебирать все
        private Node<T> current;
        int count=0;
        //public T Current => current.Element;
        private bool firstIn;
        object IEnumerator.Current => current.Element;
        public int Count
        {
            get => count;
            private set => count = value;
        }
        public T Current => current.Element;
        public void RemoveAt(int pos)
        {
            var elem = FirstElement;
            int checkedElements= 0;
            if (pos == 0)
            {
                FirstElement = FirstElement.NextElement;
                
            }
            else
            {
                while(pos-1>checkedElements)
                {
                    elem = elem.NextElement;
                    checkedElements++;
                }
                if (count - 1 == pos)
                    LastElement = elem;
                elem.NextElement = elem.NextElement.NextElement;
            }
            count--;
            if (count == 0)
            {
                current = null;
                LastElement = null;
            }
            Reset();
        }
        public T GetAt(int pos)
        {
            int checkedElem = 0;
            var elem = FirstElement;
            while (pos!=checkedElem)
            {
                elem = elem.NextElement;
                checkedElem++;
            }
            return elem.Element;
        }
        public void Add(T ToAdd)
        {
            count++;
            if (FirstElement == null)
            {
                FirstElement = new Node<T>() { Element = ToAdd };
                LastElement = FirstElement;
                Reset();
                return;
            }
            LastElement.NextElement = new Node<T>() { Element = ToAdd };
            LastElement = LastElement.NextElement;
        }

        

        public IEnumerator<T> GetEnumerator()
        {

            return this;
        }

        public bool MoveNext()
        {
            //if (current?.NextElement == null)
            //{
            //    Reset();
            //    return false;
            //}
            //if(firstIn)
            //{
            //    firstIn = false;
            //    return true;
            //}
            //current = current.NextElement;
            //return true;
            if (current == null && firstIn)
            {
                current = FirstElement;
                if (current == null)
                {
                    Reset();
                    return false;
                }
                
                
                return true;
            }
            if (current.NextElement == null)
            {
                Reset();
                return false;
            }
            else
            {
                current = current.NextElement;
                return true;
            }
        }


        public void Reset()
        {
            current = null;
            firstIn = true;
        }

        public void Dispose()
        {
            
        }
        public T[] ToArray()
        {
            T[] toReturn = new T[count];
            int index = 0;
            foreach (var item in this as IEnumerable<T>)
            {
                toReturn[index] = item;
                index++;
            }
            return toReturn;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
    }
}
