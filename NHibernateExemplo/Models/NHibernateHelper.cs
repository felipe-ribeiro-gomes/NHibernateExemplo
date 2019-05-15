using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Configuration;

namespace NHibernateExemplo.Models
{
	public class NHibernateHelper
	{
		public static ISession OpenSession()
		{
			ISessionFactory sessionFactory = Fluently
				.Configure()
				.Database(MsSqlConfiguration
					.MsSql2012
					.ConnectionString(ConfigurationManager.ConnectionStrings["NHibernateExemplo"].ConnectionString)
					.ShowSql()
				)
				.Mappings(m => m
					.FluentMappings
					.AddFromAssemblyOf<Aluno>())
					.ExposeConfiguration(cfg => new SchemaExport(cfg)
						.Create(false, false))
						.BuildSessionFactory();

			return sessionFactory.OpenSession();
		}
	}
}