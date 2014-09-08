using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    public class JsonDotNetSerialize<T> where T : class
    {
        /// <summary>
        /// Gives Xml string of any serializable object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetString(T obj)
        {

            var json = JsonConvert.SerializeObject(obj);
            return json;
        }
        /// <summary>
        /// Gives Object from xml String
        /// </summary>
        /// <param name="plainString"></param>
        /// <returns></returns>
        public static T GetObject(string plainString)
        {
            return  JsonConvert.DeserializeObject<T>(plainString);
        }


    }
  
}
