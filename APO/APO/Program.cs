using Autofac;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy2;
using Autofac.Core;
namespace APO
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SimpleCalculator>()
                   .As<ICalculator>() 
                   .EnableInterfaceInterceptors()
                   .InterceptedBy (typeof(CallLogger));
            builder.Register(c => new CallLogger(Console.Out));
            var container = builder.Build();
            var willBeIntercepted = container.Resolve<ICalculator>();
            willBeIntercepted.Divide(1, 2);

            Console.ReadLine();
        }
    }

    public interface ICalculator
    {
        int Divide(int dividend, int divisor);
    }

    public class SimpleCalculator : ICalculator
    {
        public int Divide(int dividend, int divisor)
        {
            var result = dividend / divisor;
            Console.WriteLine(result);
            return result;
        }
    }

    public class CallLogger : IInterceptor
    {
        TextWriter _output;

        public CallLogger(TextWriter output)
        {
            _output = output;
        }

        public void Intercept(IInvocation invocation)
        {
            _output.Write("Calling method {0} with parameters {1}... ",
                invocation.Method.Name,
                string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray()));

            invocation.Proceed();
            _output.WriteLine("Done: result was {0}.", invocation.ReturnValue);
        }
    }

}
