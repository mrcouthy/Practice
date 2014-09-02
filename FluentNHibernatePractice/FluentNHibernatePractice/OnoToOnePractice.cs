using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace SecondPractice
{
    public static class SecondPractice
    {
        public static void DoPractice()
        {
            var user = new User() { Username = "Suman" };
            user.UserDetail = new UserDetail() { FirstName = "suman", LastName = "rana", Email = "suss@ss.com", Address = "patan", Password = "ssssdss" };
            user.UserDetail.User = user;
            Helper.Create(user);
        }
    }

    public static class Helper
    {
        public static bool Create(User entity)
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
namespace SecondPractice
{
    public class User
    {
        public virtual UserDetail UserDetail { get; set; }

        public virtual int Id { get; set; }

        public virtual string Username { get; set; }
    }

    public class UserDetail
    {
        public virtual User User { get; set; }

        public virtual int Uid { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string MiddleName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Address { get; set; }

        public virtual string Email { get; set; }

        public virtual string Password { get; set; }

        //public virtual DateTime CreateDate{get; set;}
        //public virtual DateTime PasswordChangedDate { get; set; }
    }
}
//maps
namespace SecondPractice
{
    public class UserDetailMap : ClassMap<UserDetail>
    {
        public UserDetailMap()
        {
            Table("UsersDetails");

            //Id(x => x.Uid).GeneratedBy.Identity();
            Id(x => x.Uid).GeneratedBy.Foreign("User");
            HasOne(x => x.User).Constrained();

            //HasOne(x => x.User).Cascade.All().PropertyRef("UserDetail");

            Map(x => x.FirstName).Column("FirstName").Not.Nullable();
            Map(x => x.MiddleName).Column("MiddleName").Nullable();
            Map(x => x.LastName).Column("LastName").Not.Nullable();
            Map(x => x.Address).Column("Address").Not.Nullable();
            Map(x => x.Email).Column("Email").Not.Nullable();
            Map(x => x.Password).Column("Password").Not.Nullable();
            //    Map(x => x.CreateDate).Column("CreateDate").Nullable();
            //    Map(x => x.PasswordChangedDate).Column("PasswordChangedDate").Nullable();
        }

        public class UserMap : ClassMap<User>
        {
            public UserMap()
            {
                Table("Users");

                Id(x => x.Id);
                //References(x => x.UserDetail).Unique().Cascade.All();
                HasOne(x => x.UserDetail).Cascade.All();

                Map(x => x.Username).Not.Nullable();
            }
        }
    }
}