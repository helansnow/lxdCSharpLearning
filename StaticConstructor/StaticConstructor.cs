using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaticConstructor.CSharpLearning
{
    public class StaticConstructor
    {
        public static int Count = 0;

        static  StaticConstructor()
        {
            Count++;
            Console.WriteLine("Static" + Count.ToString());
        }

        public StaticConstructor()
        {
            Count++;
            Console.WriteLine("Public" + Count.ToString());
        }
    }
}
