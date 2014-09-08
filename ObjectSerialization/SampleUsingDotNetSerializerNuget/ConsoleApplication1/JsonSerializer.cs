using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    [DataContract]
    class Spell
    {
        [DataMember]
        public String cast;

        [DataMember]
        public String cooldown;

        [DataMember]
        public String cost;

        [DataMember]
        public String description;

        [DataMember]
        public String icon;

        [DataMember]
        public Int16 id;

        [DataMember]
        public String name;

        [DataMember]
        public String range;
    }

    public class JsonSerialization<T> where T : class
    {
        /// <summary>
        /// Gives Xml string of any serializable object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetString(T obj)
        {
            DataContractJsonSerializer jSerializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream memoryStream = new MemoryStream();
            jSerializer.WriteObject(memoryStream, obj);
            memoryStream.Position = 0;
            StreamReader streamReader = new StreamReader(memoryStream);
            string json = streamReader.ReadToEnd();
            streamReader.Close();
            memoryStream.Close();
            return json;
        }
        /// <summary>
        /// Gives Object from xml String
        /// </summary>
        /// <param name="plainString"></param>
        /// <returns></returns>
        public static T GetObject(string plainString)
        {
            DataContractJsonSerializer jSerializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream memoryStream = new MemoryStream(System.Text.ASCIIEncoding.ASCII.GetBytes(plainString));
            T obj = (T)jSerializer.ReadObject(memoryStream);
            memoryStream.Close();
            return obj;
        }


    }
}
