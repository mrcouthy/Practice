using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.DoSomething("ping")).Returns(true);
            IFoo  f = mock.Object;
            bool b = f.DoSomething("");
            bool c = f.DoSomething("ping");
        }


       
    }

    class Foo : IFoo
    {
        public bool DoSomething(string p)
        {
            return true;
        }
    }

}
