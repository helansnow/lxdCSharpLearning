using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sort.CSharpLearning
{
   static public class Fibonacci
    {
        //递归形式的斐波那契数列 
        public static int FibonacciRecursion(int n)
        {
            var result = 0;
            if (n == 1 || n == 2)
            {
                return 1;
            }
            if (n > 2)
            {
                result = FibonacciRecursion(n - 1) + FibonacciRecursion(n - 2);
            }

            Console.WriteLine(result);
            return result;
        }

        //非递归形式的斐波那契数列  
        public static int FibonacciNoRec(int n)  
        {  
            var t1 = 1;  
            var t2 = 1;

            if (n == 1 || n == 2)  
            {  
                return 1;  
            }  
            else  
            {  
                for (var i = 2; i < n; i ++)  
                {  
                    var tp = t1 + t2;  
                    t1 = t2;  
                    t2 = tp;

                    Console.WriteLine(t1);
                }

                return t1;  
            }  
        }  
    }
}
