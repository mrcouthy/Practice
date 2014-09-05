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
            ReportModel rm = s.Deserialize(xml);
            rm.Name = "a";
            CompareLogic compareLogic = new CompareLogic();
            ComparisonResult result = compareLogic.Compare(v, rm);
            bool b =result.AreEqual;
        }
    }
}
