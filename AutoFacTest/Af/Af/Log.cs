using System;

namespace Af
{
    public interface ILog
    {
       
        void Write();
    }

    public class Log : ILog
    {
        string _LogString = "Log initial message";

        public Log(string customMessage)
        {
            _LogString = customMessage;
        }

        public Log()
        {
            _LogString = "Log initial message"; string s = ""; ;
        }
        public void Write()
        {
            Console.Write(_LogString);
        }
    }

    public interface IContext
    {
        void DataBase();
    }

    public class Context : IContext
    {
        public Context()
        {
            string s = "";
        }
        public Lazy<ILog> Log { get; set; }
        public void DataBase()
        {
            Log.Value.Write();
            Console.Write("database");
        }
    }

}
