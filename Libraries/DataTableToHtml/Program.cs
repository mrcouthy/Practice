using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace DataTableToHtml
{
    using System.Xml;

    //using Newtonsoft.Json;
   // using Newtonsoft.Json.Serialization;

    //using Formatting = Newtonsoft.Json.Formatting;

    class Program
    {
        static void Main(string[] args)
        {
            DataTable customerTable = GetCustomers();
            DataTable accounTable = GetAccounts();
            var outputs = new List<string>();
            XmlDocument doc;
            string result;
            using (TextWriter writer = new StringWriter())
            {
                customerTable.WriteXml(writer);
                result = new XsltHelper().GetValue("Sample.xslt", writer.ToString());        
                outputs.Add(result);

                doc = new XmlDocument();
                doc.LoadXml(writer.ToString());
               // outputs.Add(JsonConvert.SerializeXmlNode(doc, Formatting.Indented));
                
            }
            
            using (TextWriter writer = new StringWriter())
            {
                accounTable.WriteXml(writer);
                result = new XsltHelper().GetValue("Sample.xslt", writer.ToString());
                outputs.Add(result);
                doc = new XmlDocument();
                doc.LoadXml(writer.ToString());
                //outputs.Add(JsonConvert.SerializeXmlNode(doc,Formatting.Indented));
                
            }

            foreach (var str in outputs)
            {
                Console.Write(str);
                Console.WriteLine("=============================================");
            }

            Console.Read();
        }

        private static DataTable GetCustomers()
        {
            DataTable table = new DataTable() { TableName = "Customer" };

            DataColumn keyColumn = table.Columns.Add("Id", typeof(System.Int32));
            table.Columns.Add("Name", typeof(System.String));
            table.Columns.Add("Address", typeof(System.String));

            table.PrimaryKey = new DataColumn[] { keyColumn };

            table.Rows.Add(new object[] { 1, "Customer 1", "Address1" });
            table.Rows.Add(new object[] { 2, "Customer 2", "Address2" });
            table.Rows.Add(new object[] { 3, "Customer 3", "Address3" });
            table.Rows.Add(new object[] { 4, "Customer 4", "Address4" });
            table.Rows.Add(new object[] { 5, "Customer 5", "Address5" });

            table.AcceptChanges();
            return table;
        }

        private static DataTable GetAccounts()
        {
            DataTable table = new DataTable() { TableName = "Account" };

            DataColumn keyColumn = table.Columns.Add("Id", typeof(System.Int32));
            table.Columns.Add("AccountName", typeof(System.String));
            table.Columns.Add("AccountType", typeof(System.String));
            table.Columns.Add("Address", typeof(System.String));

            table.PrimaryKey = new DataColumn[] { keyColumn };

            table.Rows.Add(new object[] { 1, "AccountName 1","Current", "Address1" });
            table.Rows.Add(new object[] { 2, "AccountName 2", "Fixed", "Address2" });
            table.Rows.Add(new object[] { 3, "AccountName 3", "Loan", "Address3" });
            table.Rows.Add(new object[] { 4, "AccountName 4", "Current", "Address4" });
            table.Rows.Add(new object[] { 5, "AccountName 5", "Fixed", "Address5" });

            table.AcceptChanges();
            return table;
        }

    }
}
