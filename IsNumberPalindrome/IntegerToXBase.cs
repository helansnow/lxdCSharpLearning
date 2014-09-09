using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class IntegerToXBase
    {
        public void ConvertToXBase(int integer, int iBase)
        {
            string result = "";
            var temp = integer;
            if(iBase <= 0 ||integer < 0)
                throw new ArgumentException("bad parameter");
            while (integer > 0)
            {
                result =  integer%iBase + result;
                integer /= iBase;
            }

            Console.WriteLine("Convert integer {0} to {1} based number is {2} ", temp, iBase, result);
        }

        public void ConvertToXBaseByArray(int integer, int iBase)
        {
            List<int> cResult = new List<int>();
            var temp = integer;
            while (integer > 0)
            {
                cResult.Add(integer % iBase);
                integer /= iBase;
            }

            Console.WriteLine("Convert integer {0} to {1} based number is ", temp, iBase);

            cResult.Reverse();
            foreach (int i in cResult)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }

        public void ConvertToXBaseRecursion(int integer, int iBase)
        {
            if (iBase <= 0 || integer < 0)
                throw new ArgumentException("bad base");
            if (integer < iBase)
            {
                Console.Write(integer);
            }
            else
            {
                ConvertToXBaseRecursion(integer / iBase, iBase);
                Console.Write(integer % iBase);         
            }
        }


        static public void Test()
        {
            //Test for _integerToXBase
            var integerToXBase = new IntegerToXBase();
            integerToXBase.ConvertToXBase(10, 2);
            integerToXBase.ConvertToXBaseRecursion(10, 2);
            integerToXBase.ConvertToXBaseByArray(10, 2);
            Console.WriteLine();

            integerToXBase.ConvertToXBase(10, 8);
            integerToXBase.ConvertToXBaseRecursion(10, 8);
            Console.WriteLine();

            integerToXBase.ConvertToXBase(10, 10);
            integerToXBase.ConvertToXBaseRecursion(10, 10);
            Console.WriteLine();

            integerToXBase.ConvertToXBase(36, 16);
            integerToXBase.ConvertToXBaseRecursion(36, 16);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
