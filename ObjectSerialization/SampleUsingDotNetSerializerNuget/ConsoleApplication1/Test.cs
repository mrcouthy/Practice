using JDE.Common.Helper;
using JDE.Common.Tests;
using KellermanSoftware.CompareNetObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSerializer;

namespace ConsoleApplication1
{
    public class Test
    {
        public static void meth()
        {
            var v = DataGenerator.GetUserDataSets();
            XmlSerializer<ReportModel> s = new XmlSerializer<ReportModel>();
            string xml = s.Serialize(v);
            System.IO.File.WriteAllText("pa.txt",xml);

            string wxml = System.IO.File.ReadAllText("a.txt");

            ReportModel rm = s.Deserialize(wxml);
           // rm.Name = "a";
            CompareLogic compareLogic = new CompareLogic();
            ComparisonResult result = compareLogic.Compare(v, rm);
            bool b =result.AreEqual;
        }

        public static void methDotNet()
        {
            var v = DataGenerator.GetUserDataSets();
            XmlSerialization<ReportModel> s = new XmlSerialization<ReportModel>();
            string xml = XmlSerialization<ReportModel>.GetXml (v);
            System.IO.File.WriteAllText("pa.txt", xml);

            string wxml = System.IO.File.ReadAllText("pa.txt");

            ReportModel rm = XmlSerialization<ReportModel>.GetObject (wxml);
            // rm.Name = "a";
            CompareLogic compareLogic = new CompareLogic();
            ComparisonResult result = compareLogic.Compare(v, rm);
            bool b = result.AreEqual;
        }
    }
}
