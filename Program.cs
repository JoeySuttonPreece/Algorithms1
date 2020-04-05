using System;
using System.Collections.Generic;
using System.IO;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> read = new List<int> { };

            using (StreamReader reader = new StreamReader("D:\\OneDrive - Swinburne University\\Sem3\\Programming\\week6\\Sorting\\unsorted_numbers.csv"))
            {
                while (!reader.EndOfStream)
                {
                    read.Add(int.Parse(reader.ReadLine()));
                }
            }

            int[] nums = read.ToArray();

            nums = Shell(nums);

            Console.WriteLine(Linear(nums, 575154));
            Console.WriteLine(Binary(nums, 575154));

            Console.WriteLine(Linear(nums, 182339));
            Console.WriteLine(Binary(nums, 182339));

            Console.WriteLine(Linear(nums, 17132));
            Console.WriteLine(Binary(nums, 17132));

            Console.WriteLine(Linear(nums, 773788));
            Console.WriteLine(Binary(nums, 773788));

            Console.WriteLine(Linear(nums, 296934));
            Console.WriteLine(Binary(nums, 296934));

            Console.WriteLine(Linear(nums, 991395));
            Console.WriteLine(Binary(nums, 991395));

            Console.WriteLine(Linear(nums, 303270));
            Console.WriteLine(Binary(nums, 303270));

            Console.WriteLine(Linear(nums, 45231));
            Console.WriteLine(Binary(nums, 45231));

            Console.WriteLine(Linear(nums, 580));
            Console.WriteLine(Binary(nums, 580));

            Console.WriteLine(Linear(nums, 629822));
            Console.WriteLine(Binary(nums, 629822));


            Console.WriteLine(Linear(nums, 1));
            Console.WriteLine(Binary(nums, 1));


            //WriteList(Insertion(nums));
            //WriteList(Shell(nums));
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
