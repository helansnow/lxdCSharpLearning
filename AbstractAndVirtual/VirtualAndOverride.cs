using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpLearning
{
    public class BaseClass
    {
        public virtual void Foo() 
        {
            Console.WriteLine("this is base class virtual foo");
        }
    }

    public class DerivedClassOverride : BaseClass
    {
        public override void Foo()
        {
            Console.WriteLine("this is derived class with override foo");
        }
    }

    public class DerivedClassNew : BaseClass
    {
        public new void Foo()
        {
            Console.WriteLine("this is derived class with new foo");
        }
    }

    public class VirtualAndOverride
    {
        public static void Run()
        {
            var bc = new BaseClass();
            bc.Foo();

            var dco =  new DerivedClassOverride();
            dco.Foo();
            BaseClass bco = (BaseClass)dco;
            //Override methods are not considered as declared on a derived class, they are new implementations of a method declared on a base class
            //can not see vitual Foo of base class for override
            bco.Foo();  //this is derived class with override foo

            var dcn = new  DerivedClassNew();
            dcn.Foo();
            BaseClass bcn = (BaseClass) dcn;
            //New just hide base virtual for derived class, we can force to call base virtual foo
            bcn.Foo();  //"this is base class virtual foo"

            var bc41 = new BaseClass();
            //Unable to cast object of type 'CSharpLearning.BaseClass' to type 'CSharpLearning.DerivedClassOverride'.
            var dco4 = (DerivedClassOverride)bc41; 
            dco4.Foo();

            var bc42 = new BaseClass();
            //Unable to cast object of type 'CSharpLearning.BaseClass' to type 'CSharpLearning.DerivedClassNew
            var dcn4 = (DerivedClassNew)bc42;
            dcn4.Foo();
        }
    }
}
