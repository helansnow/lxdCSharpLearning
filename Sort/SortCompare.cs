using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace Sort.CSharpLearning
{
    class CompareSorters
    {  
        public static void SortCompare()
        {
            for (int x = 1; x <= 5; x++)
            {
                var length = 10000 * x;
                Console.WriteLine("-{0}-------------", length);

                int[] array = new int[length];
                var ran = new Random();

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = ran.Next();
                }

                Action<int[], Action<int[]>> sort = (arr, func) =>
                {
                    var watch = Stopwatch.StartNew();

                    if (func != null)
                        func(arr);
                    else
                        Array.Sort(arr);

                    watch.Stop();

                    Console.WriteLine("{0,15}: {1}",
                                      func != null ? func.Method.Name : "Array.Sort",
                                      watch.ElapsedMilliseconds);
                };

                var a1 = array.Clone() as int[];
                var a2 = array.Clone() as int[];

                sort(a1, QuickSorter.Quick_sort);
                sort(a2, null); //.net Array.Sort(arr);
                Console.ReadKey();
            }
        }
    }
}
