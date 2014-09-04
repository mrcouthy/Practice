using System.Linq;

namespace EfPractice
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SaveAndGetReports_CodeFirstFromDb();
            SaveAndGetMetaData_EfDesingFromDb();
        }

        public static void SaveAndGetMetaData_EfDesingFromDb()
        {
            var rb = new RBM_Columns { ColumnName = "CN" };
            var dbCat = new RBM_DBCatalogs { DBCatalogName = "Db" };

            using (var db = new Dhiraj_JDEPortalEntities2())
            {
                db.RBM_Columns.Add(rb);
                db.SaveChanges();

                db.RBM_DBCatalogs.Add(dbCat);
                db.SaveChanges();
            }

            using (var db = new Dhiraj_JDEPortalEntities2())
            {
                var cols = db.RBM_Columns.ToList();
                var dbs = db.RBM_DBCatalogs.ToList();
            }
        }

        public static void SaveAndGetReports_CodeFirstFromDb()
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