using NHibernate.Validator.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteConnector.Domain
{
	public class Parameter
		: ITable
	{
		public virtual int Id { get; set; }

		[NotNullNotEmpty, Length(50)]
		public virtual string Name { get; set; }
		
		public virtual double Value { get; set; }

		[NotNullNotEmpty]
		public virtual Project Project { get; set; }
	}
}
