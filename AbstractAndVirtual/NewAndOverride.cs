using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpLearning
{
    abstract public class Contact
    {
        public virtual void Prinf()
        {
            Console.WriteLine("this is the virtual method in base class");
        }
    }

    public class ClassWithOverrideMethod : Contact
    {
        public override void Prinf()
        {
            Console.WriteLine("this is the override method in sub class");
        }
    }

    public class ClassWithOverrideMethodButCallBase : Contact
    {
        public override void Prinf()
        {
            base.Prinf();
        }
    }

    public class ClassWithNewMethod : Contact
    {
        public new void Prinf()
        {
            Console.WriteLine("the is the new method in sub class");
        }
    }
}
