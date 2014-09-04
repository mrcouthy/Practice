using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfPractice
{
    class Program
    {
        static void Main(string[] args)
        {
                      SaveAndGetReports();
         //   SaveAndGetMetaData();
        }

        public static void SaveAndGetMetaData()
        {
            //var rb = new RBM_Columns { ColumnName = "CN" };
            //using (var db = new ReporModel())
            //{
            //    db.RBM_Columns.Add(rb);
            //    db.SaveChanges();
            //}

            //using (var db = new MetaDataModel())
            //{
            //    var rpts = db.RBM_Columns.ToList();
            //}
        }

        public static void SaveAndGetReports()
        {
            var rb = new RB_Report { Name = "a", CreatedById = 1 };
            using (var db = new ReporModel())
            {
                db.RB_Report.Add(rb);
                db.SaveChanges();
            }

            using (var db = new ReporModel())
            {
                var rpts = db.RB_Report.ToList();
            }

        }
    }
}
