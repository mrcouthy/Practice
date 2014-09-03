using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;


namespace FluentNHibernatePracticeOneToManyToMany
{
 
        class OneToManyToMany
        {
            public static void Do()
            {

                GrandParent rpt = new GrandParent { Name = "report1", Description = "This is simply a report" };

                ParentOne stcln1 = new ParentOne { Columns = "asdf", Alias = "just a column" };
                ParentOne stcln2 = new ParentOne { Columns = "asdf", Alias = "just a column" };
                rpt.ParentList = new List<ParentOne>();
                rpt.AddSelectedColumns(stcln1);
                rpt.AddSelectedColumns(stcln2);
                Helper.Create(rpt);

                Helper.Select();

                //f.Create<Report>(rpt);


                ///Delete many elements in one-to-may relationship

                //var obj1 = f.GetSelectedColumnsById(1);
                //Collection<SelectedColumn> selectedcolumns = new Collection<SelectedColumn>();

                //foreach(object[] item in obj1)
                //{
                //    selectedcolumns.Add(new SelectedColumn {ParentId=(int) item[0],Columns = (string) item[1], Alias = (string) item[2], SortType = (string) item[3], SortOrder = (string) item[4], GrandParentId = (int) item[5]   });
                //}

                //f.Delete<SelectedColumn>(selectedcolumns);
            }

            public static class Helper
            {
                public static bool Create(GrandParent entity)
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


                public static bool Select()
                {
                    using (var session = NHibernateHelper.OpenSession())
                    {
                        using (var transaction = session.BeginTransaction())
                        {
                            try
                            {
                                var result =  session.Query<GrandParent>( ).ToList();
                                // session.Update(entity);
                                //session.Get<T>(id);
                                // session.Delete(entity);
                                transaction.Commit();
                                
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


            public class GrandParent
            {
                public GrandParent()
                {
                    ParentList = new List<ParentOne>();
                }

                public virtual int GrandParentId { get; set; }
                public virtual string Name { get; set; }
                public virtual string Description { get; set; }

                public virtual IList<ParentOne> ParentList { get; set; }
                public virtual void AddSelectedColumns(ParentOne parent)
                {
                    parent.GrandParent = this;
                    ParentList.Add(parent);
                }
            }

            public class ParentOne
            {
                public virtual int ParentId { get; set; }
                public virtual int GrandParentIdInParenta { get; set; }
                public virtual string Columns { get; set; }
                public virtual string Alias { get; set; }
                public virtual GrandParent GrandParent { get; set; }
            }

            public class ChildOne
            {
                public virtual int ChildId { get; set; }
                public virtual int ParentIDInChild { get; set; }
                public virtual string Name { get; set; }
                public virtual ParentOne MyParent { get; set; }
            }
            #endregion

            #region Maps
            public class GrandParentMap : ClassMap<GrandParent>
            {
                public GrandParentMap()
                {
                    Table("GrandParent");

                    Id(x => x.GrandParentId).Column("GrandParentId").GeneratedBy.Identity();
                    HasMany<ParentOne>(x => x.ParentList).Cascade.All().Inverse().KeyColumn("GrandParentIdInParent");
                    Map(x => x.Name).Column("Name");
                    Map(x => x.Description).Column("Description").Nullable();
                }
                /* Generated SQL
                create table GrandParent
                  (
                     GrandParentId INT IDENTITY NOT NULL,
                     Name          NVARCHAR(255) null,
                     Description   NVARCHAR(255) null,
                     primary key (GrandParentId)
                  )
                 * 
                 * alter table ParentOne
  add constraint FK5B7AD3A99714153A foreign key (GrandParentIdInParenta) references GrandParent
                 * */
            }

            public class ParentOneMap : ClassMap<ParentOne>
            {
                public ParentOneMap()
                {
                    Table("ParentOne");

                    Id(x => x.ParentId).Column("ParentId").GeneratedBy.Identity();
                    References(x => x.GrandParent).Class<GrandParent>().Columns("GrandParentIdInParent");
                    Map(x => x.Columns).Column("Columns").Not.Nullable();
                    Map(x => x.Alias).Column("Alias").Nullable();
                  

                }
                /* Generated SQL
              create table ParentOne
                  (
                     ParentId INT IDENTITY NOT NULL,
                     Columns  NVARCHAR(255) not null,
                     Alias    NVARCHAR(255) null,
                     cdhiraj  INT null,
                     bdhiraj  INT null,
                     primary key (ParentId)
                  )
                 * 
 
alter table ParentOne
  add constraint FK5B7AD3A99719153A foreign key (GrandParentIdInParentb) references GrandParent
                 * insert into .. grandparentidinparentsb if it was refered to
                * */
            }


            //public class ChildOneMap : ClassMap<ChildOne>
            //{
            //    public ChildOneMap()
            //    {
            //        Table("ChildOne");

            //        Id(x => x.ChildId).Column("childId").GeneratedBy.Identity();
            //        References(x => x.MyParent).Class<GrandParent>().Columns("ParentID");
            //        Map(x => x.Name).Column("Name").Not.Nullable();
            //    }
            //}
            #endregion

        }
    }

