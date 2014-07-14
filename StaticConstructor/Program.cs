using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaticConstructor.CSharpLearning
{
    class A
    {
        public static int X;
        static A(){
            X=B.Y+1;
        }
    }

    class B
    {
        public static int Y=A.X+1;
        static B(){}

        static void Main()
        {
            Console.WriteLine("X={0},Y={1}",A.X,B.Y);
            Console.ReadKey();

            var a = new StaticConstructor();
            var b = new StaticConstructor();
            Console.WriteLine(StaticConstructor.Count.ToString());

            StaticMethod.Run();
           
        }
    }
}
