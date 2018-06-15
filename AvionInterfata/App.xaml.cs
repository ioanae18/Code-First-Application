using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DataAcces;

namespace AvionInterfata
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>

	public partial class App : Application
	{
		public static AvionContext AvionDb { get; } = new AvionContext();

		public static void af()
		{
			var avn = App.AvionDb;
		}


	}
}
