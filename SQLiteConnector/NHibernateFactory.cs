using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using SQLiteConnector.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteConnector
{
	public class NHibernateFactory
	{
		public static ISessionFactory SessionFactory { get; private set; }

		static NHibernateFactory()
		{
			Configuration configuration = new Configuration();

			configuration.Configure();
			configuration.AddAssembly(typeof(Project).Assembly);

			SchemaUpdate exporter = new SchemaUpdate(configuration);
			exporter.Execute(true, true);

			SessionFactory = configuration.BuildSessionFactory();
		}

		public static ISession OpenSession()
		{
			return SessionFactory.OpenSession();
		}

		public static void CloseSession()
		{
			SessionFactory.Close();
		}

		public static void DisposeSession()
		{
			SessionFactory.Dispose();
		}
	}
}
