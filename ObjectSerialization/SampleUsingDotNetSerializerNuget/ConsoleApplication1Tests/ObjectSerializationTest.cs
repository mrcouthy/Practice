//using JDE.Common.Helper;
//using KellermanSoftware.CompareNetObjects;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace JDE.Common.Tests
//{
//    class ObjectSerializationTest
//    {
//        [Test]
//        public void TestIfSerializationAndDesirializationOfIntegerListAreEqual()
//        {
//            var inputList = new List<int>() { 1, 2, 3 };
//            string outputXML = JsonSerialization<List<int>>.GetString(inputList);
//            var outPutList = JsonSerialization<List<int>>.GetObject(outputXML);
//            Assert.AreEqual(inputList, outPutList);
//        }

//        [Test]
//        public void TestIfSerializationAndDesrializationOfReportModelAreEqual()
//        {
//            var reportModel = DataGenerator.GetUserDataSets();
//            string outputXML = JsonSerialization<ReportModel>.GetString(reportModel);
//            var outputReportModel = JsonSerialization<ReportModel>.GetObject(outputXML);
//            CompareLogic compareLogic = new CompareLogic();
//            ComparisonResult result = compareLogic.Compare(reportModel, outputReportModel);
//         //  result.Differences 
//            Assert.That(result.AreEqual,Is.EqualTo (true));
//        }

//        [Test]
//        public void TestIfSerializationAndDesrializationOfReportModelAreNotEqual()
//        {
//            var reportModel = DataGenerator.GetUserDataSets();
//            string outputXML = JsonSerialization<ReportModel>.GetString(reportModel);
//            var outputReportModel = JsonSerialization<ReportModel>.GetObject(outputXML);
//            outputReportModel.Name = "NewName";
//            CompareLogic compareLogic = new CompareLogic();
//            ComparisonResult result = compareLogic.Compare(reportModel, outputReportModel);
//            Assert.That(result.AreEqual, Is.EqualTo(false));
//        }
//    }
//}
