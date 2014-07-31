using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernatePractice;
public class NHibernateHelper
{
    private static ISessionFactory _sessionFactory;

    private static ISessionFactory SessionFactory
    {
        get
        {
            if (_sessionFactory == null)

                InitializeSessionFactory();
            return _sessionFactory;
        }
    }

    private static void InitializeSessionFactory()
    {
        _sessionFactory = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2008
              .ConnectionString(
              @"Server=test;initial catalog=NhibernatePractice;
		user=dbadmb;") // Modify your ConnectionString
                          .ShowSql()
            )
            .Mappings(m =>
                      m.FluentMappings
                          .AddFromAssemblyOf<Department>())
            .ExposeConfiguration(cfg => new SchemaExport(cfg)
                                            .Create(true, true))
            .BuildSessionFactory();
    }

    public static ISession OpenSession()
    {
        return SessionFactory.OpenSession();
    }
}