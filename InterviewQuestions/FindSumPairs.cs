using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    internal class FindSumPairs
    {
        public static void Test()
        {
            int[] input = {20, 21, 23, 31, 32, 32, 80, 79, 76, 68,79};
            int sum = 100;

            Console.WriteLine(string.Join(" ", input));
            Hashtable result0 = GetSumPairs0(input, sum);
            foreach (DictionaryEntry result in result0)
            {
                Console.WriteLine("{0} + {1}", result.Key, result.Value);
            }
 
            Console.WriteLine(string.Join(" ", input));
            Hashtable results1 = GetSumPairs1(input, sum);
            foreach (DictionaryEntry result in results1)
            {
                Console.WriteLine("{0} + {1}", result.Key, result.Value);
            }

            Console.WriteLine(string.Join(" ", input));
            var results2 = GetSumPairs2(input, sum);
            foreach (Tuple<int, int> tuple in results2)
            {
                Console.WriteLine("{0} + {1}", tuple.Item1, tuple.Item2);
            }

            Console.WriteLine(string.Join(" ", input));
            Hashtable result3 = GetSumPairs3(input, sum);
            foreach (DictionaryEntry result in result3)
            {
                Console.WriteLine("{0} + {1}", result.Key, result.Value);
            }
            Console.ReadKey();
        }

        private static Hashtable GetSumPairs0(int[] input, int sum)
        {
            Hashtable result = new Hashtable();
            foreach (int val in input)
            {
                if (!result.Contains(val))
                {
                    result.Add(val, sum - val);
                }
            }

            for (int i = 0; i < input.Length - 1; i++)
            {
                int numb1 = input[i]; //how to remove dup key?
                int numb2 = sum - numb1;
                if (result.Contains(numb1) && result.Contains(numb2))
                {
                    result.Remove(numb2);
                    result[numb1] = numb2;
                }
                else if (result.Contains(numb1) && !result.Contains(numb2))
                {
                    result.Remove(numb1);
                }
            }

            return result;
        }

    
        private static Hashtable GetSumPairs1(int[] input, int sum)
        {
            List<int> numbList1 = new List<int>();
            Hashtable result = new Hashtable();
            foreach (int val in input)
            {
                if (!numbList1.Contains(val))
                {
                    numbList1.Add(val);
                }
            }

            for (int i = 0; i < input.Length - 1; i++)
            {
                int numb1 = input[i];
                int numb2 = sum - numb1;
                if (numbList1.Contains(numb1) && numbList1.Contains(numb2))
                {
                    numbList1.Remove(numb1);
                    numbList1.Remove(numb2);
                    result.Add(numb1,numb2);
                }
            }

            return result;
        }

        private static List<Tuple<int, int>> GetSumPairs2(int[] input, int sum)
        {
            List<int> inputList = input.ToList();
            var result = new List<Tuple<int, int>>();
            for (int i = 0; i < input.Length - 1; i++)
            {
                int numb1 = input[i];
                int numb2 = sum - numb1;

                if (inputList.Contains(numb1) && inputList.Contains(numb2))
                {
                    result.Add(new Tuple<int, int>(numb1, numb2));
                    inputList.Remove(numb1);
                    inputList.Remove(numb2);
                }
            }

            return result;
        }

        private static Hashtable GetSumPairs3(int[] input, int sum)
        {
            Hashtable result = new Hashtable();

            for (int i = 0; i < input.Length - 2; i++)
            {
                int numb1 = input[i]; 
                int numb2 = sum - numb1;
                for (int j = 1; j < input.Length - 1; j++)
                {
                    if (input[j] == numb2)
                    {
                        if (!result.Contains(numb1) && !result.Contains(numb2))
                        {
                            result.Add(numb1, numb2);
                        }
                    }
                }
            }

            return result;
        }

    }
}
