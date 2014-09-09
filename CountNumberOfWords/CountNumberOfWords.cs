using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    class CountNumberOfWords
    {
        static void Test()
        {
            var test1 = " Hello, my name is John.";
            Console.WriteLine(CountNumWords(test1));
            Console.WriteLine(CountNumWords2(test1));
            Console.ReadKey();
        }

        private static int CountNumWords(string input)
        {
            var chars = input.ToCharArray();
            bool inWord = false;
            int wordCount = 0;
            foreach (var c in chars)
            {
                if (!inWord &&  Char.IsLetter(c))
                {
                    inWord = true;
                    wordCount++;
                }
                else if (inWord && c == ' ')
                {
                    inWord = false;
                }
            }
          
          return wordCount;
        }

        private static int CountNumWords2(string input)
        {
            var chars = input.ToCharArray();
            int n = chars.Length;
            int i = 0;
            int j = 0;
            int wordCount = 0;

            while (j < n)
            {
                if (chars[i] != ' ')
                {
                    i++;
                    j++;
                }
                if (chars[j] == ' ')
                {
                    wordCount++;
                    i = j + 1;
                }
                else
                {
                    j++;
                }
            }

            return wordCount;
        }
    }
}
