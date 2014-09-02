using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentNHibernatePractice
{
    class OneToMany
    {
        public  static void Do()
        {

            Report rpt = new Report { Name = "report1", Description = "This is simply a report" };
          
            SelectedColumn stcln1 = new SelectedColumn { Columns = "asdf", Alias = "just a column" };
            SelectedColumn stcln2 = new SelectedColumn { Columns = "asdf", Alias = "just a column" };
            rpt.SelectedColumns = new List<SelectedColumn>();
            rpt.AddSelectedColumns(stcln1);
            rpt.AddSelectedColumns(stcln2);
            Helper.Create(rpt);
         
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
            public static bool Create(Report entity)
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

      
        public class Report
        {
            public Report()
            {
                SelectedColumns = new List<SelectedColumn>();
            }

            public virtual int RID { get; set; }
            public virtual string Name { get; set; }
            public virtual string Description { get; set; }
            public virtual IList<SelectedColumn> SelectedColumns { get; set; }
            public virtual void AddSelectedColumns(SelectedColumn selectedColumn)
            {
                selectedColumn.Report = this;
                SelectedColumns.Add(selectedColumn);
            }
        }

        public class SelectedColumn
        {
            public virtual int SID { get; set; }
            public virtual int RID { get; set; }
            public virtual string Columns { get; set; }
            public virtual string Alias { get; set; }
            public virtual Report Report { get; set; }
        }
        #endregion

        #region Maps
        public class ReportMap : ClassMap<Report>
        {
            public ReportMap()
            {
                Table("Reports");

                Id(x => x.RID).Column("RID").GeneratedBy.Identity();
                HasMany<SelectedColumn>(x => x.SelectedColumns).Cascade.All().Inverse().KeyColumns.Add("RID", mapping => mapping.Name("RID"));
                Map(x => x.Name).Column("Name");
                Map(x => x.Description).Column("Description").Nullable();
            }
        }

        public class SelectedColumnMap : ClassMap<SelectedColumn>
        {
            public SelectedColumnMap()
            {
                Table("SelectedColumns");

                Id(x => x.SID).Column("SID").GeneratedBy.Identity();
                References(x => x.Report).Class<Report>().Columns("RID");
                Map(x => x.Columns).Column("Columns").Not.Nullable();
                Map(x => x.Alias).Column("Alias").Nullable();
            }
        }
        #endregion

    }
}
