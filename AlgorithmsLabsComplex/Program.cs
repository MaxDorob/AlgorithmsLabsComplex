using Collections;
using Lab2;
using System;

namespace AlgorithmsLabsComplex
{
    class Program
    {
        static string[] models = new string[] { "BMW", "Lada", "Jaguar" };
        static void Main(string[] args)
        {
            Random rnd = new Random(2);
            BinaryTree<Car> tree = new Collections.BinaryTree<Car>();
            tree.sortFunc = x =>
             {
                 if (double.TryParse(x.Number, out double r))
                     return r;
                 else
                     return 999999;
             };
            for (int i = 0; i < 6; i++)
            {
                tree.PutItem(new Car()
                {
                    Number = rnd.Next(1000).ToString(),
                    Model = models[rnd.Next(models.Length)]
                });
            }
            tree.ShowInDebug();
            Console.ReadLine();
            for (int i = 0; i < 6; i++)
            {
                tree.PutItem(new Car()
                {
                    Number = rnd.Next(1000).ToString(),
                    Model = models[rnd.Next(models.Length)]
                });
            }

            tree.ShowInDebug();
            Console.ReadLine();
            tree.SortByFunction(tree.sortFunc);
            //tree.OrderTreeBy(x =>
            //{
            //    if (double.TryParse(x.Number, out double r))
            //        return r;
            //    else 
            //        return 999999;
            //});
            tree.ShowInDebug();

            
        }
    }
}
