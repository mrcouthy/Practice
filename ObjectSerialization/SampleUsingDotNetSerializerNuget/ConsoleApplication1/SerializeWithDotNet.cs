using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace JDE.Common.Helper
{
    public class XmlSerialization<T> where T : class
    {
        /// <summary>
        /// Gives Object from xml String
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T GetObject(string xml)
        {
            T result;
            byte[] byteArray = Encoding.UTF8.GetBytes(xml);

            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                result = (T)serializer.Deserialize(stream);
            }
            return result;
        }

        /// <summary>
        /// Gives Xml string of any serializable object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetXml<T>(T obj)
        {
            string xmlString = string.Empty;
            using (var stream = new MemoryStream())
            {
                using (var writer = XmlWriter.Create(stream))
                {
                    new XmlSerializer(obj.GetType()).Serialize(writer, obj);
                    xmlString = Encoding.UTF8.GetString(stream.ToArray());
                }
            }
            return xmlString;
        }
    }
}