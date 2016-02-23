using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace scrap
{
    public class Operation
    {
        public string RunSlowOperation()
        {
            Console.WriteLine("Slow operation running on thread id {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("Slow operation about to finish on thread id {0}", Thread.CurrentThread.ManagedThreadId);
            return "This is very slow...";
        }

        public void RunTrivialOperation()
        {
            string[] words = new string[] { "i", "love", "dot", "net", "four", "dot", "five" };
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }

        //edit
        public Task<string> RunSlowOperationTask()
        {
            return Task.Factory.StartNew<string>(RunSlowOperation);
        }

        public async Task<string> RunSlowOperationTaskAsync()
        {
            Console.WriteLine("Slow operation running on thread id {0}", Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(2000);
            Console.WriteLine("Slow operation about to finish on thread id {0}", Thread.CurrentThread.ManagedThreadId);
            return "This is very slow...";
        }

        public void SecondFoo()
        {
            Console.WriteLine("ho ho ho ho");
            Console.WriteLine(string.Format("I am on thread {0}", Thread.CurrentThread.ManagedThreadId));
            Thread.Sleep(2000);
            Console.WriteLine("eh eh eh eh ");
        }
    }

    public class Operation2
    {
        public Operation2()
        {
            Console.WriteLine("I can be in Constructor too");
            Thread.Sleep(5555);
            Console.WriteLine(string.Format("Did you see me in constructor at thread {0}?",Thread.CurrentThread.ManagedThreadId));

        }
    }
}
