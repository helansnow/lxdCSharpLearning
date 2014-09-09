using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    class CharsCombination
    {
        public static void Test()
        {
            var input1 = "abc";
            var input2 = "123";
            var input3 = "a";
            var input4 = "ABCDE";

            //Combinate(input1);
            //Combinate(input2);
            //Combinate(input3);
            //Combinate(input4);

            //string[] specLength = Combinate(input4, 2);

            //foreach (string s in specLength)
            //{
            //    Console.WriteLine(s);
            //}

            var result = CombinationByPowerSet(input1);
            foreach (string str in result)
            {
                Console.WriteLine(str);
            }

            //CombinationDict(input1);

            Console.ReadKey();
        }

        private static void Combinate(string input)
        {
            for (int i = 1; i <= input.Length; i++)
            {
                string[] all = Combinate(input, i);

                foreach (string s in all)
                {
                    Console.WriteLine(s);
                }
            }

            Console.WriteLine();
            Console.ReadKey();
        }

        private static string[] Combinate(string input, int count)
        {
            if(count < 1|| input == null)
                throw new ArgumentException("bad parameter");

            if (count == 1)
            {
                char[] cInput = input.ToCharArray();

                List<string> orginal = new List<string>();

                foreach (char c in cInput)
                {
                    orginal.Add(new string(c, 1));
                }

                return orginal.ToArray();
            }

            List<string> result = new List<string>();

            if(input.Length > 0)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    var removedI = input.Remove(i, 1);
                    string[] subStrList = Combinate(removedI, count - 1);
                    foreach (string sub in subStrList)
                    {
                        result.Add(input.ElementAt(i) + sub);
                    }                
                }
            }

            return result.ToArray();
        }

        #region using dictionary
        static void CombinationDict(string input)
        {
            string [] mData = new string[input.Length];
            char[] cInput = input.ToCharArray();

            for (int i = 0; i < input.Length; i++)
            {
                mData[i] = new string(cInput[i], 1);
            }

            Dictionary<string, int> dic = new Dictionary<string, int>();
            for (int i = 0; i < mData.Length; i++)
            {
                Console.WriteLine(mData[i]);//如果不需要打印单元素的组合，将此句注释掉
                dic.Add(mData[i], i);
            }
            GetCombinationDict(dic, mData);
        }

        static void GetCombinationDict(Dictionary<string, int> dd, string[] mData)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (KeyValuePair<string, int> kv in dd)
            {
                for (int i = kv.Value + 1; i < mData.Length; i++)
                {
                    Console.WriteLine(kv.Key + mData[i]);
                    dic.Add(kv.Key + mData[i], i);
                }
            }

            if (dic.Count > 0)
                GetCombinationDict(dic,mData);
        }

        #endregion using dictionary

        #region using power set
        // Helper method to count set bits in an integer
        public static int CountBits(int n)
        {
            int count = 0;
            while (n != 0)
            {
                count++;
                n &= (n - 1);
            }
            return count;
        }

         private static string[] CombinationByPowerSet(string input)
         {
             var cInput = input.ToCharArray();
             var setSize = Math.Pow(2, cInput.Length);
             List<string> results = new List<string>();
             for (int i = 0; i < setSize; i++)
             {
                 var subSetSize = CountBits(i);

                 char[] set = new char[subSetSize];

                var temp = i;
                var srcIdx = 0;
                var dstIdx = 0;

                while(temp > 0)
                {
                    if((temp & 0x01) == 1)
                    {
                        set[dstIdx++] = cInput[srcIdx];
                    }
                    temp >>= 1;
                    srcIdx++;            
                }

                results.Add(new string(set));
             }
             return results.ToArray();
         }

        #endregion using power set
    }
}
