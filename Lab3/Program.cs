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

            stopwatch.Restart();
            var linqOrder = array.OrderBy(x => x);
            stopwatch.Stop();
            Console.WriteLine(linq= stopwatch.ElapsedTicks);
            app.Dispatcher.Invoke(() =>
            window.Draw(linqOrder.Select(x=>(double)x).ToArray()));

            Console.ReadLine();

            stopwatch.Restart();
            var mas = array.BubbleSort();
            stopwatch.Stop();
            Console.WriteLine(bubble= stopwatch.ElapsedTicks);
            app.Dispatcher.Invoke(() =>
            window.Draw(linqOrder.Select(x => (double)x).ToArray()));

            Console.ReadLine();

            stopwatch.Restart();
            mas = array.InsertionSort();
            stopwatch.Stop();
            Console.WriteLine(bubble = stopwatch.ElapsedTicks);
            app.Dispatcher.Invoke(() =>
            window.Draw(linqOrder.Select(x => (double)x).ToArray()));

            Console.ReadLine();

            stopwatch.Restart();
            mas = array.QuickSort();
            stopwatch.Stop();
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
