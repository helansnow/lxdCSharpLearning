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

        //bad implementation
        public int ConvertToXBase2(int integer, int iBase)
        {
            int result = 0;
            var temp = integer;
            if (iBase <= 0 || integer < 0)
                throw new ArgumentException("bad parameter");

            while (integer > 0)
            {
                result = integer % iBase + result*10; //how to handle first mode remain is 0
                integer /= iBase;
            }

            Console.WriteLine("Convert integer {0} to {1} based number is {2} ", temp, iBase, result);
            return result;
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

            Console.Write("Convert integer {0} to {1} based number is ", temp, iBase);

            cResult.Reverse();
            foreach (int i in cResult)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }

        public void ConvertToXBaseRecursionWrapper(int integer, int iBase)
        {
            Console.Write("Convert integer {0} to {1} based number is ", integer, iBase);
            ConvertToXBaseRecursion(integer, iBase);
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
            //integerToXBase.ConvertToXBase2(10, 2);
            integerToXBase.ConvertToXBaseRecursionWrapper(10, 2);
            integerToXBase.ConvertToXBaseByArray(10, 2);
            Console.WriteLine();

            integerToXBase.ConvertToXBase(10, 8);
            //integerToXBase.ConvertToXBase2(10, 8);
            integerToXBase.ConvertToXBaseRecursionWrapper(10, 8);
            integerToXBase.ConvertToXBaseByArray(10, 8);
            Console.WriteLine();

            integerToXBase.ConvertToXBase(10, 10);
            integerToXBase.ConvertToXBaseRecursionWrapper(10, 10);
            integerToXBase.ConvertToXBaseByArray(10, 10);
            Console.WriteLine();

            integerToXBase.ConvertToXBase(36, 16);
            integerToXBase.ConvertToXBaseRecursionWrapper(36, 16);
            integerToXBase.ConvertToXBaseByArray(36, 16);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
