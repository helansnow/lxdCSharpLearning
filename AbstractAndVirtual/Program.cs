using System;

namespace CSharpLearning
{
    class AA
    {
        public AA()
        {
            PrintFields();
        }

        public virtual void PrintFields() { }
    }

    class BB : AA
    {
        int x = 1;
        int y;
        public BB()
        {
            y = -1;
        }

        public override void PrintFields()
        {
            Console.WriteLine("x={0},y={1}", x, y);
        }
    }

    public abstract class C
    {
        public C()
        {
            Console.WriteLine("C");
        }

        public virtual void Func()
        {
            Console.WriteLine("C.Func()");
        }
    }

    public class D : C
    {
        public D()
        {
            Console.WriteLine("D");
        }

        public new void Func()
        {
            Console.WriteLine("D.Func()");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BB b = new BB();
            Console.ReadKey();

            C c = new D();
            c.Func();
            Console.ReadKey();

      
           // Contact ct = new Contact();
            Contact ct1 = new ClassWithOverrideMethod();
            Contact ct2 = new ClassWithNewMethod();

            ClassWithOverrideMethod ct3 = new ClassWithOverrideMethod();
            ClassWithNewMethod ct4 = new ClassWithNewMethod();

            ct1.Prinf();
            ct2.Prinf();

            ct3.Prinf();
            ct4.Prinf();

            ((Contact)ct3).Prinf();
            ((Contact)ct4).Prinf();

            //this is the override method in sub class
            //this is the virtual method in base class
            //this is the override method in sub class
            //the is the new method in sub class
            //this is the override method in sub class
            //this is the virtual method in base class

            AbsctractOverride.Run();

            VirtualAndOverride.Run();
            Console.ReadKey();
        }
    }
}