using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentNHibernatePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var DepartmentObject = new Department { Name = "IT", PhoneNumber = "962788700227" };
            Create(DepartmentObject);
            //FrameWork f = new FrameWork();
            //f.Create<Department>(DepartmentObject);
            //DepartmentObject.Name = "VIT";
            //f.Update<Department>(DepartmentObject);
            //Department newDept = f.Retrieve<Department>(1);
            //f.Delete(DepartmentObject);
        }


        public static bool Create(Department entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var result = (int)session.Save(entity);
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
