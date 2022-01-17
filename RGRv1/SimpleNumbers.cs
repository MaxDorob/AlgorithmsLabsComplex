
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
namespace RGRv1
{
    class SimpleNumbers
    {
        static int K = (int)Math.Pow(10, 7);
        #region Перебор потоками
        //public List<ulong> simpleNums = new List<ulong>(100000);
        //const int threadCounts = 20;
        //public List<Thread> threads = new List<Thread>();
        //public SimpleNumbers()
        //{
        //    simpleNums.Add(2);
        //    for (int i = 0; i < threadCounts*2; i+=2)
        //    {
        //        var par = new object[] { (ulong)(3 + i), threadCounts *2};
        //        threads.Add(
        //        new Thread((object ar)=>FillList(
        //            (ulong)(ar as object[])[0], (int)(ar as object[])[1] 
        //            ))
        //            );
        //        threads.Last().Start(par);
        //    }
        //}
        //void FillList(ulong start, int interval)
        //{
        //    for (ulong i = start; i < K; i += (ulong)interval)
        //    {
        //        if (IsSimple(i))
        //            simpleNums.Add(i);
        //    }
        //}
        //bool IsSimple(ulong value)
        //{
        //    for (ulong i = 2; i < value / 2 + 1; i++)
        //    {

        //        if (value % i == 0)
        //            return false;
        //        //return false;
        //    }
        //    return true;
        //} 
        #endregion
        public List<uint> nums = Enumerable.Range(2, K).Select(x => (uint)x).ToList();
        public SimpleNumbers()
        {
            uint curent = 2;
            uint max = (uint)Math.Sqrt(K);
            while (curent<=max)
            {
                for (int i = nums.Count - 1; i >= 0; i--)
                {
                    if (nums[i] == curent)
                        continue;
                    if (nums[i] % curent == 0)
                        nums[i]=uint.MaxValue;

                }
                nums = nums.Where(x => x != uint.MaxValue).ToList();
                curent = nums.First(x => x > curent);
            }
        }
        public int FirstSimpleInterval(int M,int N)
        {
            int index = 0;
            for (int i = 0; i < K; i++)
            {
                //if(M ==  nums.Count(x=>x>=i&&x<i+N))
                //    return i;
                if (index >= nums.Count)
                    return -1;
                if (nums[index] < i)
                    index++;
                int count = 0;
                
                
                for (int y = index; y < nums.Count; y++)
                {
                    if (nums[y] > i + N)
                    {
                        break;
                    }
                    count++;
                    if (count > M)
                        break;
                }
                if (count == M)
                {
                    Console.WriteLine("Список простых");
                    Console.WriteLine(string.Join(", ",nums.Where(x=>x>=i&&x<=i+N)));
                    return i;
                }
            }
            return -1;
        }
    }
}
