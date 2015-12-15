using System;

namespace Af
{
    public interface ILog
    {
        void Write();
    }

    public class Log:ILog
    {
        public void Write()
        {
            Console.Write("write");
        }
    }

    public interface IContext
    {
        void DataBase();
    }

    public class Context : IContext
    {
      public  ILog Log { get; set; }
        public void DataBase()
        {
            Log.Write();
            Console.Write("database");
        }
    }

}
