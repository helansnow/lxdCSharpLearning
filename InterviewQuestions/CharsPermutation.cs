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
            var chars1 = new char[] { 'A'};
            var chars2 = new char[2]{'A', 'B'};
            var chars3 = new char[3]{'A', 'B', 'C'};
            var chars4 = new char[4] { 'A', 'B', 'C','D' };
            Permutation(chars1);
            Permutation(chars2);
            Permutation(chars3);
            Permutation(chars4);
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
                Console.WriteLine(string.Concat(chars));
            }
            else
            {               
                for (int i = start; i < chars.Length ; i++)
                {
                    var temp = chars[i];
                    chars[i] = chars[start];
                    chars[start] = temp;

                    Permutate(chars, start +1);

                    temp = chars[i];
                    chars[i] = chars[start];
                    chars[start] = temp;
                }
            }
        }
    }
}
