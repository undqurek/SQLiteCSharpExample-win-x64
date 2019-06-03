using NHibernate;
using SQLiteConnector.Domain;
using SQLiteConnector.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLiteConnector
{
	public partial class MainForm : Form
	{
		private ProjectRepository _projectRepository = new ProjectRepository();

		public MainForm()
		{
			this.InitializeComponent();

			Project project = new Project()
			{
				Name = "Test-" + DateTime.Now.ToString(),
				Description = "Test",
				CreatedDate = DateTime.Now
			};

			this._projectRepository.Add(project);
		}
	}
}
