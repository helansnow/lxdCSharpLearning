using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    class FindDupInArray
    {
        private static bool FindDupBySwap(int[] array )
        {
            bool result = false;
            int n = array.Length;
            //dups = new ArrayList();
            for (int i = 0; i < n; i++)
            {
                while (array[i] != i)
                {
                    if (array[i] == array[array[i]])
                    {
                        Console.WriteLine("Contains dup number {0}", array[i]);
                        result = true;
                        break;//break the while;
                    }
                    var temp = array[i];
                    array[i] = array[temp];
                    array[temp] = temp;

                }             
            }
            return result;
        }

        private static void FindDupByHashtable(int[] array)
        {
            bool result = false;
            var ht = new Hashtable();
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                var temp = array[i];
                if (!ht.Contains(temp))
                {
                    ht.Add(temp, 1);
                }
                else
                {
                    ht[temp] = (int)ht[temp] + 1;
                }
            }

            foreach (DictionaryEntry item in ht)
            {
                if((int)item.Value > 1)
                Console.WriteLine("Contains dup number {0} has count {1} ",item.Key, item.Value);
            }

        }

        public static void Run()
        {
            var array = new int[] {2, 3, 1, 0, 2, 5, 3};
            ////ArrayList dup;
            //if (FindDupBySwap(array, out dup))
            //{
            //    foreach (var d in dup)
            //    {
            //        Console.WriteLine(d);
            //    }
            //}
            FindDupBySwap(array);
            FindDupByHashtable(array);
        }
    }
}
