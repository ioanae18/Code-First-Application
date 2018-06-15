using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProiectExamen;
using DataAcces;

namespace AvionInterfata
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public static AvionContext AvionDb { get; } = new AvionContext();

		public MainWindow()
		{

			var avn = App.AvionDb;

			InitializeComponent();

		}

		private void MenuItem_Click_1(object sender, RoutedEventArgs e)
		{
			WindowPasager wd = new WindowPasager();
			wd.Show();
		}

		private void MenuItem_Click_2(object sender, RoutedEventArgs e)
		{
			WindowBilet wd = new WindowBilet();
			wd.Show();
		}

		private void MenuItem_Click_3(object sender, RoutedEventArgs e)
		{
			WindowAvion wd = new WindowAvion();
			wd.Show();
		}

		private void MenuItem_Click_4(object sender, RoutedEventArgs e)
		{
			WindowRezervareBilet wd = new WindowRezervareBilet();
			wd.Show();
		}
	}
}
