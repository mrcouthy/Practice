using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace scrap
{
    class Program
    {
        static void Main(string[] args)
        {
            Operation operation = new Operation();

            //string result = operation.RunSlowOperation();
            //Task<string> result = operation.RunSlowOperationTask();
            Task<string> result = operation.RunSlowOperationTaskAsync();

            operation.RunTrivialOperation();

            Task.Factory.StartNew(() => operation.SecondFoo());
            Console.WriteLine("I am already here");

            //Console.WriteLine("Return value of slow operation: {0}", result);
            Console.WriteLine("Return value of slow operation: {0}", result.Result);
            Console.WriteLine("The main thread has run complete on thread number {0}", Thread.CurrentThread.ManagedThreadId);
            Console.ReadLine();

          

           

           

        }
    }
}
