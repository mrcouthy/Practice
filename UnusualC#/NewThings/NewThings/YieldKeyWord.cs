using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewThings
{
    public class YieldKeyWord
    {
        private static List<int> Mylist = new List<int>();

        private static void FillValues()
        {
            Mylist.Add(1);
            Mylist.Add(2);
            Mylist.Add(4);
            Mylist.Add(5);
        }

        public static void Test()
        {
            FillValues();
            foreach (int i in Filter())
            {
                Console.WriteLine(i);
            }

            foreach (int i in RunningTotal())
            {
                Console.WriteLine(i);
            }

        }

        //Use of Yield keyword for filtering list without a temporary list
        private static IEnumerable<int> Filter()
        {
            foreach (int i in Mylist)
            {
                if (i > 3)
                {
                    yield return i;
                }
            }
        }

        //Statefull Iteration
        private static IEnumerable<int> RunningTotal()
        {
            int runningTotal = 0;
            foreach (int i in Mylist)
            {
                if (i > 3)
                {
                    runningTotal += i;
                    yield return (runningTotal );
                }
            }
        }
    }
}
