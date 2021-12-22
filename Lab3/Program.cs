using Collections;
using Lab3Visual;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Lab3
{
    class Program
    {
        const int N = 2000;
        const double center = 12000, dispersion = N * 1.3;
        static Stopwatch stopwatch = new Stopwatch();
        static long linq, bubble;
        static void Main(string[] args)
        {
            Console.WriteLine($"Frequnce: {Stopwatch.Frequency}");
            var rand = new ZRandom();
            var array = new int[N];
            InitUI();
            stopwatch.Restart();
            for (int i = 0; i < N; i++)
                array[i] = (int)rand.Next(center, dispersion);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedTicks);
            app.Dispatcher.Invoke(() =>
            window.Draw(array.Select(x => (double)x).ToArray())
            );
            Console.ReadLine();
            //Console.WriteLine(string.Join(", ", array.OrderBy(x => x)));
            Console.WriteLine("Linq");
            stopwatch.Restart();
            var linqOrder = array.OrderBy(x => x);
            stopwatch.Stop();
            Console.WriteLine("Время");
            Console.WriteLine(linq= stopwatch.ElapsedTicks);
            app.Dispatcher.Invoke(() =>
            window.Draw(linqOrder.Select(x=>(double)x).ToArray()));

            Console.ReadLine();
            //Console.WriteLine(string.Join(", ", array.OrderBy(x => x)));
            Console.WriteLine("parallel Linq");
            stopwatch.Restart();
            var linqParOrder = array.AsParallel().OrderBy(x => x);
            stopwatch.Stop();
            Console.WriteLine("Время");
            Console.WriteLine(linq = stopwatch.ElapsedTicks);
            app.Dispatcher.Invoke(() =>
            window.Draw(linqOrder.Select(x => (double)x).ToArray()));

            Console.ReadLine();
            Console.WriteLine("Пузырьком");
            stopwatch.Restart();
            var mas = array.BubbleSort();
            Console.WriteLine($"C/N: {Sorting.C / (double)N}, M/N {Sorting.M / (double)N}");
            stopwatch.Stop();
            Console.WriteLine("Время");
            Console.WriteLine(bubble= stopwatch.ElapsedTicks);
            app.Dispatcher.Invoke(() =>
            window.Draw(linqOrder.Select(x => (double)x).ToArray()));

            Console.ReadLine();
            Console.WriteLine("Вставкой");
            stopwatch.Restart();
            mas = array.InsertionSort();
            Console.WriteLine($"C/N: {Sorting.C / (double)N}, M/N {Sorting.M / (double)N}");
            stopwatch.Stop();
            Console.WriteLine("Время");
            Console.WriteLine(bubble = stopwatch.ElapsedTicks);
            app.Dispatcher.Invoke(() =>
            window.Draw(linqOrder.Select(x => (double)x).ToArray()));

            Console.ReadLine();
            Console.WriteLine("Быстрая");
            stopwatch.Restart();
            mas = array.QuickSort();
            Console.WriteLine($"C/N: {Sorting.C / (double)N}, M/N {Sorting.M / (double)N}");
            stopwatch.Stop();
            Console.WriteLine("Время");
            Console.WriteLine(bubble = stopwatch.ElapsedTicks);
            app.Dispatcher.Invoke(() =>
            window.Draw(linqOrder.Select(x => (double)x).ToArray()));

            Console.ReadLine();
            Console.WriteLine("Выборкой");
            stopwatch.Restart();
            mas = array.MergeSort();
            Console.WriteLine($"C/N: {Sorting.C / (double)N}, M/N {Sorting.M / (double)N}");
            stopwatch.Stop();
            Console.WriteLine("Время");
            Console.WriteLine(bubble = stopwatch.ElapsedTicks);
            app.Dispatcher.Invoke(() =>
            window.Draw(linqOrder.Select(x => (double)x).ToArray()));
        }
        static void InitUI()
        {
            uiThread = new Thread(() =>
             {
                 app = new App();
                 window = new MainWindow();
                 app.Run(window);
             });
            uiThread.ApartmentState = ApartmentState.STA;
            uiThread.Start();
            while (app == null) { }
        }
        static App app;
        static MainWindow window;
        static Thread uiThread;
    }
}
