using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaticConstructor.CSharpLearning
{
    public class StaticMethod
    {
        private string str = "Class1.str";
        private int i = 0;
        static void StringConvert(string str)
        {
            str = "string being converted.";
        }

        static void StringConvert(StaticMethod c)
        {
            c.str = "string being converted.";
        }

        static void Add(int i)
        {
            i++;
        }

        static void AddWithRef(ref int i)
        {
            i++;
        }

        static public void Run()
        {
            int i1 = 10;
            int i2 = 20;
            string str = "str";
            StaticMethod c = new StaticMethod();
            Add(i1);
            AddWithRef(ref i2);
            Add(c.i);
            StringConvert(str);
            StringConvert(c);
            Console.WriteLine(i1);  //10
            Console.WriteLine(i2);  //21
            Console.WriteLine(c.i);  //0
            Console.WriteLine(str);  //str
            Console.WriteLine(c.str); 
        } 
    }
}
