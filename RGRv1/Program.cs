using System;
using System.Linq;
using System.Threading;

namespace RGRv1
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleNumbers numbers = new SimpleNumbers();
            Console.WriteLine("Hello World!");
            while (true)
            {
                Console.WriteLine("Enter M:");
                int M = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter N:");
                int N = int.Parse(Console.ReadLine());

                Console.WriteLine(numbers.FirstSimpleInterval(M, N));
                Console.WriteLine();
                Console.WriteLine();
                //var l = numbers.simpleNums.OrderBy(x => x);
                //var max = numbers.simpleNums.ToList().Max();


            }
        }
    }
}
