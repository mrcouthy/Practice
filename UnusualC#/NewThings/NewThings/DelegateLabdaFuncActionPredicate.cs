using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewThings
{
    ////Using delegete
    //class Program
    //{
    //    private delegate double CalAreaPointer(int r);

    //    private static CalAreaPointer cpointer = CalculateArea;
    //    private static double CalculateArea(int r)
    //    {
    //        return 3.14 * r * r;
    //    }
    //    static void Main()
    //    {
    //        double area = cpointer.Invoke(20);
    //    }
    //}

    ////Using anonymous function
    //class Program
    //{
    //    private delegate double CalAreaPointer(int r);
    //    static void Main()
    //    {
    //        CalAreaPointer cpointer = new CalAreaPointer(
    //            delegate(int r)
    //            {
    //                return 3.014 * r * r;
    //            }
    //            );
    //        double area = cpointer.Invoke(20);
    //    }
    //}

    ////using labda expression
    //class Program
    //{
    //    private delegate double CalAreaPointer(int r);
    //    static void Main()
    //    {
    //        CalAreaPointer cpointer = r => 3.14*r*r;
    //        double area = cpointer.Invoke(20);
    //    }
    //}

    ////Using generic readymade delegate
    ///Func => takes input and gives output
    ///Action => returns void
    ///Predicate => Extension to Func ,Only for check purpose output is always boolean
    class Program
    {
        static void Main()
        {
            Func<Double, Double> funcPointer = r => 3.14 * r * r;
            double area = funcPointer.Invoke(20);

            Action<string> actionPointer = r => Console.Write("Radius is " + r);
            actionPointer.Invoke("20");

            Predicate<string> CheckGeraterThan5 = x => x.Length > 5;
            bool b= CheckGeraterThan5("Dhiraj 132");

        }
    }



}
