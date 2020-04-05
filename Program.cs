using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            List<int> read = new List<int> { };
            int[] wanted = new int[]
            {
                575154,
                182339,
                17132,
                773788,
                296934,
                991395,
                303270,
                45231,
                580,
                629822
            };

            using (StreamReader reader = new StreamReader("D:\\Joey\\School\\Repos\\Algorithms1\\unsorted_numbers.csv"))
            {
                while (!reader.EndOfStream)
                {
                    read.Add(int.Parse(reader.ReadLine()));
                }
            }

            int[] nums = read.ToArray();

            nums = Shell(nums);
            //nums = Insertion(nums);

            stopwatch.Reset();
            stopwatch.Start();

            for (int i = 0; i < 100000; i++)
            {
                foreach (int num in wanted)
                {
                    Linear(nums, num);
                }
            }

            stopwatch.Stop();
            long linear = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Linear x 1000000: {linear} ms");

            stopwatch.Reset();
            stopwatch.Start();

            for (int i = 0; i < 100000; i++)
            {
                foreach (int num in wanted)
                {
                    Binary(nums, num);
                }
            }

            stopwatch.Stop();
            long binary = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Binary x 1000000: {binary} ms");
        }

        static int[] Insertion(int[] list)
        {
            int i = 1;

            while (i < list.Length)
            {
                int num = list[i];
                int j = i - 1;

                while (j >= 0 && num < list[j])
                {
                    list[j + 1] = list[j];

                    j -= 1;
                }

                list[j + 1] = num;

                i += 1;
            }

            return list;
        }

        static int[] Shell(int[] list)
        {
            int gap = list.Length / 2;

            while (gap > 0)
            {
                int off = 0;

                while (off < gap)
                {
                    int i = off + gap;

                    while (i < list.Length)
                    {
                        int num = list[i];
                        int j = i - gap;

                        while (j >= 0 && num < list[j])
                        {
                            list[j + gap] = list[j];

                            j -= gap;
                        }

                        list[j + gap] = num;

                        i += gap;
                    }

                    off += 1;
                }

                gap /= 2;
            }

            return list;
        }

        static int Linear(int[] list, int num)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == num)
                {
                    return i;
                }
            }

            return -1;
        }

        static int Binary(int[] list, int num)
        {
            int left = 0;
            int right = list.Length - 1;

            while (left <= right)
            {
                int mid = (right + left) / 2;

                if (num == list[mid])
                {
                    return mid;
                }

                if (num > list[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }

        static void WriteList(int[] list)
        {
            foreach (int num in list)
            {
                Console.WriteLine(num);
            }
        }
    }
}
