using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    class CharsPermutation
    {
        public static void Run()
        {
            var chars1 = new char[]  { 'A'};
            var chars2 = new char[2] { 'A', 'B'};
            var chars3 = new char[3] { 'A', 'B', 'C'};
            var chars4 = new char[4] { 'A', 'B', 'C','D' };
            var chars5 = new char[3] { 'A', 'B', 'B' };
            Permutation(chars1);
            Permutation(chars2);
            Permutation(chars3);
            Permutation(chars4);
            Permutation(chars5);

            Console.ReadKey();
        }

        private static void Permutation(char[] chars)
        {
            Permutate(chars, 0);
            Console.WriteLine();
        }

        private static void Permutate(char[] chars, int start)
        {
            if (start == chars.Length - 1)
            {
                Console.WriteLine(chars);
            }
            else
            {               
                for (int i = start; i < chars.Length ; i++)
                {
                    if (IfCurrentCharNeedSwap(chars, start, i))
                    {
                        var temp = chars[i];
                        chars[i] = chars[start];
                        chars[start] = temp;

                        Permutate(chars, start + 1);

                        temp = chars[i];
                        chars[i] = chars[start];
                        chars[start] = temp;
                    }
                }
            }
        }

        private static bool IfCurrentCharNeedSwap(char[] chars,int start, int current)
        {
            for(int i = start; i<current; i++)
            {
                if (chars[i] == chars[current]) //if current char already appeared before, not need to swap it.
                    return false;
            }
            return true;
        }
    }
}
