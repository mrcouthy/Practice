using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentNHibernatePractice
{
    class dbcatalog
    {
        public static void Do()
        {

            var dbCatalog = new RbmDbCatalog();
            dbCatalog.DbCatalogName = "TestDb";
 

            var rbTable = new RbmTable();
            dbCatalog.Tables = new List<RbmTable>();   
            //  rbTable.TableId = 1;
            rbTable.TableSchema = "dbo";
 
            rbTable.DbCatalogId = 90;
            rbTable.DbCatalog = dbCatalog;
            
            dbCatalog.AddTables(rbTable);



            Helper.Create(dbCatalog);

            //f.Create<Report>(rpt);


            ///Delete many elements in one-to-may relationship

            //var obj1 = f.GetSelectedColumnsById(1);
            //Collection<SelectedColumn> selectedcolumns = new Collection<SelectedColumn>();

            //foreach(object[] item in obj1)
            //{
            //    selectedcolumns.Add(new SelectedColumn {SID=(int) item[0],Columns = (string) item[1], Alias = (string) item[2], SortType = (string) item[3], SortOrder = (string) item[4], RID = (int) item[5]   });
            //}

            //f.Delete<SelectedColumn>(selectedcolumns);
        }

        public static class Helper
        {
            public static bool Create(RbmDbCatalog entity)
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        try
                        {
                            var result = (int)session.Save(entity);
                            // session.Update(entity);
                            //session.Get<T>(id);
                            // session.Delete(entity);
                            transaction.Commit();
                            if (result > 0)
                            {
                                return true;
                            }
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
                return false;
            }
        }

        #region POCO


        public class RbmDbCatalog
        {
            public RbmDbCatalog()
            {
                Tables = new List<RbmTable>();
            }
            public virtual int DbCatalogId { get; set; }
            public virtual string DbCatalogName { get; set; }

            public virtual IList<RbmTable> Tables { get; set; }

            public virtual void AddTables(RbmTable table)
            {
                table.DbCatalog = this;
                Tables.Add(table);
            }
        }

        public class RbmTable
        {
            public virtual int TableId { get; set; }
            public virtual string TableSchema { get; set; }
            public virtual int DbCatalogId { get; set; }
            public virtual RbmDbCatalog DbCatalog { get; set; }
        }
        #endregion

        #region Maps
        public class RbmDbCatalogMap : ClassMap<RbmDbCatalog>
        {

            public RbmDbCatalogMap()
            {
                Table("RBM_DBCatalog");

                Id(x => x.DbCatalogId).Column("DBCatalogID").GeneratedBy.Identity();
                HasMany<RbmTable>(x => x.Tables).Cascade.All().Inverse().KeyColumns.Add("DBCatalogID", mapping => mapping.Name("DBCatalogID"));
                Map(x => x.DbCatalogName).Column("DBCatalogName");
            }
        }
        public class RbmTableMap : ClassMap<RbmTable>
        {

            public RbmTableMap()
            {
                Table("RBM_Tables");

                Id(x => x.TableId).Column("TableID").GeneratedBy.Identity();
                References(x => x.DbCatalog).Class<RbmDbCatalog>().Columns("DBCatalogID");
                Map(x => x.TableSchema).Column("TableSchema").Length(50);
                Map(x => x.DbCatalogId).Column("DBCatalogID").Precision(10);
            }
        }
        #endregion

    }
}
