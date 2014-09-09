using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class StringManipulate
    {
        public static void Run()
        {
            var input = "asg34523asdfg 1234sg123";
            var str2 = "asg34523asdfg 1234321gs";

            var answ = isStringContainSameChar(input, str2);
            Console.WriteLine("Is the 2 strings \n{0} \n{1} have same chars:\n{2}", input,str2,answ);

            int[] numbs;
            if (ExtractNumbers(input, out numbs))
            foreach (int numb in numbs)
            {
                Console.WriteLine(numb);
            }

            int[] index;
            if( GetSubstringIndex(input, "sg'", out index))
            foreach (int i in index)
            {
                Console.WriteLine(i);
            }

            int[] index2;
            if(GetSubstringIndex("abc", "abc", out index2))
            foreach (int i in index2)
            {
                Console.WriteLine(i);
            }

            int[] index3;
            if(GetSubstringIndex("abc", "bca",out index3))
            foreach (int i in index2)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }

        static public bool ExtractNumbers(string input, out int[] results)
        {
            List<int> resultList = new List<int>();
            char[] temp = input.ToCharArray();
            List<char> number = new List<char>();
            bool start = false;

            for (int i = 0; i < temp.Length; i++)
            {
                var iChar = temp[i];
                if (!start)
                {
                    if (iChar >= '0' && iChar <= '9')
                    {
                        start = true;
                        number.Add(iChar);
                    }                                    
                }
                else
                {
                    if (iChar >= '0' && iChar <= '9')
                    {
                        number.Add(iChar);
                        if (i == temp.Length - 1)
                        {
                            var n = number.ToArray();
                            resultList.Add(int.Parse(new string(n)));
                        }
                    }
                    else
                    {
                        start = false;
                        //list<char> to char[];
                        var n = number.ToArray();
                        //char[] => string =>int
                        resultList.Add(int.Parse(new string(n)));
                        number.Clear();
                    }
                  
                }               
            }

            if (resultList.Count > 0)
            {
                results = resultList.ToArray();
                return true;
            }

            results = new int[0];
            return false;         
        }

        static public bool GetSubstringIndex(string src, string sub, out int[] indexs)
        {
            List<int> results = new List<int>();
            char[] cSrc = src.ToCharArray();
            char[] cSub = sub.ToCharArray();
            
            int i = 0;
            int j = 0;
            bool isSub = false;

            if (cSrc.Length < cSub.Length)
                throw new ArgumentException("asdf");

            while (i < cSrc.Length)
            {
                while (cSrc[i++] == cSub[j++])
                {
                    if (j == cSub.Length -1)
                    {
                        isSub = true;
                        break;
                    }
                }

                if (isSub) 
                    results.Add(i - (cSub.Length - 1));
                j = 0;
                isSub = false;
            }

            indexs = results.ToArray();

            return isSub;
        }

        //如果两个字符串含有相同的字母，并且相同字母的个数也相同，那么就称这2个字符串是相等的
        public static bool isStringContainSameChar(string aStr, string bStr)
        {
            var cStrA = aStr.ToCharArray();
            var bStrB = bStr.ToCharArray();
            var count = new int[256];

            foreach (char c in cStrA)
            {
                count[c]++;
            }

            foreach (char c in bStrB)
            {
                count[c]--;
            }

            foreach (int i in count)
            {
                if (i > 0)
                    return false;
            }

            return true;
        }
    }
}
