using NHibernate.Validator.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteConnector.Domain
{
	public class Project
		: ITable
	{
		public virtual int Id { get; set; }

		[NotNullNotEmpty, Length(50)]
		public virtual string Name { get; set; }

		[Length(4000)]
		public virtual string Description { get; set; }

		[NotNullNotEmpty]
		public virtual DateTime CreatedDate { get; set; }

		public virtual IList<Parameter> Parameters { get; set; }
	}
}
