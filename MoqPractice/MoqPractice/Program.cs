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
            //Set up is important , here we are telling moq that if parameter of dosometing is ping then return true else return false(default value)
            mock.Setup(foo => foo.DoSomething("ping")).Returns(6);
            IFoo  f = mock.Object;
            int b = f.DoSomething("");
            int c = f.DoSomething("ping");
        }
    }

    

}
