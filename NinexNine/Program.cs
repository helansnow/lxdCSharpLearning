using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinexNine.CSharpLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            string t = string.Empty; 
            for (int i = 1; i < 10; i++) 
            { 
                for (int j = 1; j <= i; j++) 
                { 
                    t = string.Format("{0}×{1}={2} ", j, i, (j * i));
                    Console.Write(t); 
                    ////if (j * i < 10)
                    ////    Console.Write(" "); 
                    
                    if (i == j)              
                        Console.Write("\n"); 
                }
            }
            Console.ReadKey();
        }
    }
}
