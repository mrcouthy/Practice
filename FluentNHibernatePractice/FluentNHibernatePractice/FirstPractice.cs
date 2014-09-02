using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using FluentNHibernatePractice;

public static class FirstPractice
{
    public static void DoPractice()
    {
        var DepartmentObject = new Department { Name = "IT", PhoneNumber = "962788700227" };
        Helper.Create(DepartmentObject);
    }

    public static class Helper
    {
        public static bool Create(Department entity)
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
}
 //poco
namespace FluentNHibernatePractice
{
    class DepartmentMap : ClassMap<Department>
    {
        //Constructor
        public DepartmentMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.PhoneNumber);
            Table("Department");
        }
    }
}
//mapper
namespace FluentNHibernatePractice
{
    public class Department
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string PhoneNumber { get; set; }
    }

    ///Case study
    /// Error No persister for: FluentNHibernatePractic means mapping file not given
}
