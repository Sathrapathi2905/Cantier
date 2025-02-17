using System.Xml.Serialization;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHybernateCRUD.Mappings;
using NHibernate;
using NHibernate.Cfg.ConfigurationSchema;
using NHibernate.Tool.hbm2ddl;

namespace FluentNHybernateCRUD.Helper
{
    public class nhibernatehelper
    {
        private static ISessionFactory _sessionFactory;
        public static ISessionFactory SessionFactory 
        {
            get 
            {
                if (_sessionFactory == null) 
                {
                    _sessionFactory=Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString("Data Source=DESKTOP-URM2ERI;Initial Catalog=blackmirror;Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=False")
                        .Driver<NHibernate.Driver.MicrosoftDataSqlClientDriver>()).Mappings(m=>m.FluentMappings.AddFromAssemblyOf<empmap>())
                        .ExposeConfiguration(Cfg => new SchemaUpdate(Cfg).Execute(false,true))
                        .BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }
        public static NHibernate.ISession OpenSession() 
        {
            return SessionFactory.OpenSession();
        }
 
    }
}
