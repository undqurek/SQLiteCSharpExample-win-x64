using NHibernate;
using NHibernate.Criterion;
using NHibernate.Validator.Util;
using SQLiteConnector.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteConnector.Repositories
{
	public abstract class BasicRepository<T>
		where T : class, ITable
	{
		#region Variables

		protected static string _typeName;

		#endregion

		static BasicRepository()
		{
			_typeName = typeof(T).ToString();
		}

		#region Public methods

		public int Add(T entity)
		{
			try
			{
				using (ISession session = NHibernateFactory.OpenSession())
				{
					using (ITransaction transaction = session.BeginTransaction())
					{
						session.Save(entity);
						transaction.Commit();

						return entity.Id;
					}
				}
			}
			catch (ADOException ex)
			{
				throw new DatabaseException("Add " + _typeName + " entity exception.", ex);
			}
		}

		public void Update(T entity)
		{
			try
			{
				using (ISession session = NHibernateFactory.OpenSession())
				{
					using (ITransaction transaction = session.BeginTransaction())
					{
						session.Update(entity);
						transaction.Commit();
					}
				}
			}
			catch (ADOException ex)
			{
				throw new DatabaseException("Update " + _typeName + " entity exception.", ex);
			}
		}

		public void Remove(T entity)
		{
			try
			{
				using (ISession session = NHibernateFactory.OpenSession())
				{
					using (ITransaction transaction = session.BeginTransaction())
					{
						session.Delete(entity);
						transaction.Commit();
					}
				}
			}
			catch (ADOException ex)
			{
				throw new DatabaseException("Remove " + _typeName + " entity exception.", ex);
			}
		}

		public T GetById(int id)
		{
			try
			{
				using (ISession session = NHibernateFactory.OpenSession())
					return session.Get<T>(id);
			}
			catch (ADOException ex)
			{
				throw new DatabaseException("GetById " + _typeName + " entity exception.", ex);
			}
		}

		public IList<T> GetList()
		{
			try
			{
				using (ISession session = NHibernateFactory.OpenSession())
					return session.CreateCriteria<T>().List<T>();
			}
			catch (ADOException ex)
			{
				throw new DatabaseException("GetList " + _typeName + " entities exception.", ex);
			}
		}

		public IList<T> GetList(int pageNumber, int pageSize)
		{
			try
			{
				//using (ISession session = NHibernateHelper.OpenSession())
				//	return session.CreateCriteria<T>()..List<T>();

				//TODO: dorobic to

				return null;
			}
			catch (ADOException ex)
			{
				throw new DatabaseException("GetList " + _typeName + " entities exception.", ex);
			}
		}

		public IList<T> GetPagesCount()
		{
			try
			{
				//using (ISession session = NHibernateHelper.OpenSession())
				//	return session.CreateCriteria<T>()..List<T>();

				//TODO: dorobic to

				return null;
			}
			catch (ADOException ex)
			{
				throw new DatabaseException("GetList " + _typeName + " entities exception.", ex);
			}
		}

		#endregion
	}

	public abstract class NamedEntityRepository<T>
		: BasicRepository<T>
		where T : class, ITable
	{
		#region Public methods

		public T GetByName(string name)
		{
			try
			{
				using (ISession session = NHibernateFactory.OpenSession())
				{
					T entity = session.CreateCriteria<Project>()
						.Add(Restrictions.Eq("Name", name))
						.UniqueResult<T>();

					return entity;
				}
			}
			catch (ADOException ex)
			{
				throw new DatabaseException("GetByName " + _typeName + " entity exception.", ex);
			}
		}

		#endregion
	}
}
