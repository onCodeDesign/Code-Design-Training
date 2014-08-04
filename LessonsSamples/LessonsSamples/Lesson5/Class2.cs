using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsSamples.Lesson5
{
    class MyClass2
    {
        public void Boo()
        {
            var f = new Class2();

            D d = new D();
            f.Foo(d);
        }
    }

    class D : B
    {
    }

    class Class2
    {


        public void Foo(B b)
        {
            if (b is D)
            {
               // fix special case when b is D  
            }
        }


    }

    class B
    {
    }
}
