using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Xml.Serialization;

namespace DataTableToHtml
{
    public class XsltHelper
    {
        public string GetValue(string templatePath, string xmlString)
        {
            XDocument xmlObj = XDocument.Parse(xmlString);
            XDocument result = GetResultXml(templatePath, xmlObj);

            return (result == null) ? string.Empty : result.Document.ToString();
        }
        private XDocument GetResultXml(string templatePath, XDocument xmlObj)
        {
            XDocument result = new XDocument();
            using (XmlWriter writer = result.CreateWriter())
            {
                XslCompiledTransform xslt = new XslCompiledTransform();
                xslt.Load(templatePath);
                xslt.Transform(xmlObj.CreateReader(), writer);
            }
            return result;
        }
    }
}
