//using NHibernate;
//using NHibernate.Cfg;
//using NHibernate.Dialect;
//using NHibernate.Driver;
//using NHibernate.Tool.hbm2ddl;
//using NHibernate.Validator.Cfg;
//using System;
//using System.Collections.Generic;
//using System.Data.SQLite;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace SQLiteConnector
//{
//	public static class DatabaseFactory
//	{
//		#region Configuration

//		private const string _databasePath = "database.sqlite3";
//		private const string _tablesNamespace = "SQLiteConnector.Domain";

//		private static SQLiteConnection _connection = new SQLiteConnection("Data Source=" + _databasePath + ";Version=3;");

//		#endregion

//		#region Variables

//		private static ISessionFactory _sessionFactory;

//		#endregion

//		#region Properties

//		public static ISessionFactory SessionFactory
//		{
//			get
//			{
//				if (_sessionFactory == null)
//					_sessionFactory = BuildSessionFactory();

//				return _sessionFactory;
//			}
//		}

//		#endregion

//		static DatabaseFactory()
//		{
//			AppDomain.CurrentDomain.ProcessExit += (o, a) =>
//			{
//				if (_sessionFactory == null)
//					return;

//				_sessionFactory.Dispose();
//			};
//		}

//		#region Helper methods

//		private static SQLiteConfiguration CreateConfiguration()
//		{
//			SQLiteConfiguration configuration = SQLiteConfiguration.Standard;

//			configuration.Driver<SQLite20Driver>();
//			configuration.Dialect<SQLiteDialect>();
//			configuration.ConnectionString("Data Source='" + _databasePath + "';Version=3");

//			return configuration;
//		}

//		//private static void CreateMapping(MappingConfiguration configuration)
//		//{
//		//	Assembly assembly = Assembly.GetExecutingAssembly();

//		//	AutoPersistenceModel databaseModel = AutoMap.Assembly(assembly);
//		//	AutoPersistenceModel tablesModel = databaseModel.Where(p => p.Namespace == _tablesNamespace);

//		//	configuration.AutoMappings.Add(tablesModel);
//		//}

//		private static void BuildSchema(Configuration configuration)
//		{
//			if (File.Exists(_databasePath))
//				return;

//			SchemaExport exporter = new SchemaExport(configuration);
//			exporter.Create(true, true);
//		}

//		private static ISessionFactory BuildSessionFactory()
//		{
//			try
//			{


//				//ISessionFactory factory = Fluently.Configure()
//				//    .Database(SQLiteConfiguration.Standard
//				//        .UsingFile(_databasePath))
//				//    .Mappings(m =>
//				//        m.FluentMappings.AddFromAssemblyOf<Element>())
//				//    .ExposeConfiguration(BuildSchema)
//				//    .BuildSessionFactory();

//				//return factory;


//				FluentConfiguration configuration = Fluently.Configure();

//				configuration.Database(CreateConfiguration);
//				configuration.Mappings(CreateMapping);
//				configuration.ExposeConfiguration(BuildSchema);

//				return configuration.BuildSessionFactory();
//			}
//			catch (Exception)
//			{
//				return null;
//			}
//		}

//		#endregion
//	}
//}
