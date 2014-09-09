﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpLearning
{
    public class A
    {
        public virtual void Fun1(int i)
        {
            Console.WriteLine(i);
        }
        public void Fun2(A a)
        {
            a.Fun1(1);
            Fun1(5);
        }
    }

    public class B : A
    {
        public override void Fun1(int i)
        {
            base.Fun1(i + 1);
        }
    }

    public class AbsctractOverride
    {
         public static void Run()
        {
            B b = new B();
            A a = new A();
            a.Fun2(b);
            b.Fun2(a);

            Console.ReadKey();
        }
    }
}
