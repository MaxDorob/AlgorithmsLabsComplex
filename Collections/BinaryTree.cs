using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using TreeViewOfBinaryTree;

namespace Collections
{
    public class BinaryTree<T>
    {
        T mainLeaf;
        BinaryTreeNode<T> leftNode, rightNode;
        bool containsMain = false;

        App app;
        MainWindow wind;
        TreeViewItem item;
        public Func<T, IComparable> sortFunc;
        public void ShowInDebug()
        {
            if (!System.Runtime.InteropServices.RuntimeInformation
                                               .IsOSPlatform(OSPlatform.Windows))
                return;

            if (app == null)
            {
                Thread wpfThread = new Thread(() =>
                {
                    app = new App();
                    wind = new MainWindow();

                    app.Run(wind);
                });
                wpfThread.SetApartmentState(ApartmentState.STA);
                wpfThread.Start();

            }
            while (app == null) ;
            app.Dispatcher.Invoke(() =>
            {
                item = new TreeViewItem();
                item.IsExpanded = true;
                wind.TreeView.Items.Clear();
                item.Header = mainLeaf.ToString();
                leftNode?.ShowInDebug(item);
                rightNode?.ShowInDebug(item);
                wind.TreeView.Items.Add(item);

            });

        }

        public void OrderTreeBy(Func<T, IComparable> func)
        {
            sortFunc = func;
            var allItems = this.MyWhere(x => true);



            // сортировка
            T temp;
            for (int i = 0; i < allItems.Length - 1; i++)
            {
                for (int j = i + 1; j < allItems.Length; j++)
                {
                    if (func.Invoke(allItems[i]).CompareTo(func.Invoke(allItems[j])) >= 0)
                    {
                        temp = allItems[i];
                        allItems[i] = allItems[j];
                        allItems[j] = temp;
                    }
                }
            }
            ReFillLeafs(allItems);

        }
        void ReFillLeafs(T[] orderedArray)
        {
            int index = leftNode?.Fill(orderedArray, 0) ?? 0;
            mainLeaf = orderedArray[index];
            rightNode?.Fill(orderedArray, index + 1);
        }
        public void PutItem(T item)
        {
            if (!containsMain)
            {
                mainLeaf = item;
                containsMain = true;
                return;
            }
            if (leftNode == null && (sortFunc == null || sortFunc.Invoke(item).CompareTo(sortFunc.Invoke(mainLeaf)) <= 0))
            {
                leftNode = new BinaryTreeNode<T>(item);
                return;
            }
            if (rightNode == null && (sortFunc == null || sortFunc.Invoke(item).CompareTo(sortFunc.Invoke(mainLeaf)) > 0))
            {
                rightNode = new BinaryTreeNode<T>(item);
                return;
            }
            if ((leftNode.MinDepth <= (rightNode?.MinDepth ?? 0) && sortFunc == null) ||
                    (sortFunc != null && sortFunc.Invoke(item).CompareTo(sortFunc.Invoke(mainLeaf)) <= 0))
            {
                leftNode.PutItem(item);
            }
            else
            {
                rightNode.PutItem(item);
            }
        }
        public T MyFirst(Func<T, bool> func)
        {
            if (func.Invoke(mainLeaf))
                return mainLeaf;
            T toReturn = default(T);
            if (leftNode?.GetFirstT(func, ref toReturn) ?? false)
                return toReturn;
            if (rightNode?.GetFirstT(func, ref toReturn) ?? false)
                return toReturn;
            throw new Exception("No such element in the tree");
        }
        public T[] MyWhere(Func<T, bool> func)
        {
            MyLinkedList<T> toReturn = new MyLinkedList<T>();
            if (func.Invoke(mainLeaf))
                toReturn.Add(mainLeaf);
            leftNode?.GetAllChildItemsByFunc(toReturn, func);
            rightNode?.GetAllChildItemsByFunc(toReturn, func);
            return toReturn.ToArray();

        }
        public T FirstItemByProperty(string name, object value)
        {
            var prop = typeof(T).GetProperty(name);
            if (prop == null)
                throw new ArgumentException("Invalid argument");
            if (prop.PropertyType != value.GetType())
                throw new ArgumentException("Type of value invalid");
            object mainItem = typeof(T).GetProperty(name).GetValue(mainLeaf);
            if (mainItem == value)
            {
                return mainLeaf;
            }
            T toReturn = default(T);
            if (leftNode != null)
                if (leftNode.FirstItemByProperty(name, value, ref toReturn))
                    return toReturn;
            if (rightNode != null)
                if (rightNode.FirstItemByProperty(name, value, ref toReturn))
                    return toReturn;
            if (Nullable.GetUnderlyingType(typeof(T)) != null)
                return default(T);
            throw new Exception("No such item in the tree");
        }
        public void RemoveFirst(T item)
        {
            if (item.Equals(mainLeaf))
            {

            }
            else if(leftNode?.RemoveFirst(item)??false)
            {
                
            }
            else if (!rightNode?.RemoveFirst(item) ?? true)
            {
                throw new Exception("No such element in the collection"); ;
            }
        }
    }
}
