using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Collections
{
    internal class BinaryTreeNode<T>
    {
        T leaf;
        public T Item
        {
            get => leaf;
            set
            {
                ///TODO
                ///Дописать проверку на нулл и вызов перестройки дерева в случае нулла
                leaf = value;
            }
        }

        private BinaryTreeNode<T> leftNode, rightNode;
        internal uint MinDepth;
        internal BinaryTreeNode(T Item)
        {
            leaf = Item;
            MinDepth = 0;
        }

        internal void ShowInDebug(TreeViewItem parent)
        {
            var item = new TreeViewItem();
            item.IsExpanded = true;
            item.Header = leaf.ToString();
            leftNode?.ShowInDebug(item);
            rightNode?.ShowInDebug(item);
            parent.Items.Add(item);
        }

        public bool GetFirstT(Func<T, bool> func, ref T returend)
        {
            if (func.Invoke(leaf))
            {
                returend = leaf;
                return true;
            }

            if (leftNode?.GetFirstT(func, ref returend) ?? false)
                return true;
            if (rightNode?.GetFirstT(func, ref returend) ?? false)
                return true;
            return false;
        }
        public void GetAllChildItemsByFunc(MyLinkedList<T> list, Func<T, bool> func)
        {
            if (func.Invoke(leaf))
                list.Add(leaf);
            if (leftNode != null)
                leftNode.GetAllChildItemsByFunc(list, func);
            if (rightNode != null)
                rightNode.GetAllChildItemsByFunc(list, func);
        }

        public bool FirstItemByProperty(string name, object value, ref T toReturn)
        {

            object mainItem = typeof(T).GetProperty(name).GetValue(leaf);
            if (mainItem == value)
            {
                toReturn = leaf;
                return true;
            }
            if (leftNode != null)
                if (leftNode.FirstItemByProperty(name, value, ref toReturn))
                    return true;

            if (rightNode != null)
                if (rightNode.FirstItemByProperty(name, value, ref toReturn))
                    return true;
            return false;
        }

        internal int Fill(T[] orderedArray, int index)
        {
            index = leftNode?.Fill(orderedArray, index) ?? index;
            leaf = orderedArray[index];
            return rightNode?.Fill(orderedArray, index + 1) ?? index + 1;
        }

        public void PutItem(T item, Func<T, IComparable> func = null)
        {
            if (leftNode == null && (func == null || func.Invoke(item).CompareTo(func.Invoke(leaf)) <= 0))
            {
                leftNode = new BinaryTreeNode<T>(item);

            }
            else if (rightNode == null && (func == null || func.Invoke(item).CompareTo(func.Invoke(leaf)) > 0))
            {
                rightNode = new BinaryTreeNode<T>(item);
                MinDepth = 1;
            }
            else if ((leftNode.MinDepth <= (rightNode?.MinDepth ?? 0) && func == null) ||
                    (func != null && func.Invoke(item).CompareTo(func.Invoke(leaf)) <= 0))
            {
                leftNode.PutItem(item);
                MinDepth = Math.Min(leftNode.MinDepth, rightNode.MinDepth) + 1;
            }
            else
            {
                rightNode.PutItem(item);
                MinDepth = Math.Min(leftNode.MinDepth, rightNode.MinDepth) + 1;
            }
        }

        public void GetAllItems(MyLinkedList<T> list)
        {
            list.Add(leaf);
            if (leftNode != null)
            {
                leftNode.GetAllItems(list);
                if (rightNode != null)
                    rightNode.GetAllItems(list);
            }
        }

        internal bool RemoveFirst(T item)
        {
            throw new NotImplementedException();
        }
    }
}
