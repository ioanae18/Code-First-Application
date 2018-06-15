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
using System.Windows.Shapes;
using ProiectExamen;
using DataAcces;

namespace AvionInterfata
{
    /// <summary>
    /// Interaction logic for WindowAvion.xaml
    /// </summary>
	/// 

    public partial class WindowAvion : Window
    {
		public static AvionContext AvionDb { get; } = new AvionContext();

		public WindowAvion()
        {

            InitializeComponent();

			var avn = App.AvionDb;

			foreach (var av in avn.Avions)
			{
				var itm = new ListViewItem();
				itm.Content = av.IDAvion + " " + av.TipAeronava + " " + av.NumarLocuri + av.IDPasager + " ";
				itm.Tag = av;
				lbAvion.Items.Add(itm);
				lbAvion.Items.Clear();
			}
		}

		private void btnAdaug_Click(object sender, RoutedEventArgs e)
		{
			var avn = App.AvionDb;

			Avion av = new Avion();

			av.IDAvion = Convert.ToInt32(txtIDAvion.Text);
			txtIDAvion.Clear();
			av.TipAeronava = txtTipAeronava.Text;
			txtTipAeronava.Clear();
			av.NumarLocuri = Convert.ToInt32(txtNrLocuri.Text);
			txtNrLocuri.Clear();
			av.IDPasager = Convert.ToInt32(txtIDPasager.Text);
			txtIDPasager.Clear();

			avn.Avions.Add(av);
			avn.SaveChanges();

			lbAvion.Items.Clear();
			
			foreach (var av1 in avn.Avions)
			{
				var itm = new ListViewItem();
				itm.Content = av1.IDAvion + " " + av1.TipAeronava + " " + av1.NumarLocuri + av1.IDPasager + " ";
				itm.Tag = av1;
				lbAvion.Items.Add(itm);
			}
		}

		private void btnSterg_Click(object sender, RoutedEventArgs e)
		{
			var avn = App.AvionDb;

			Avion av1 = (lbAvion.SelectedItem as ListViewItem).Tag as Avion;
			txtSters.Text = " ";
			var s = (from s1 in avn.Avions where s1.IDAvion == av1.IDAvion select s1).First();
			avn.Avions.Remove(s);
			avn.SaveChanges();
		}

		private void btnModific_Click(object sender, RoutedEventArgs e)
		{
			var avn = App.AvionDb;
			// if(lbCamera.SelectedItem!=null)
			Avion avion = (lbAvion.SelectedItem as ListViewItem).Tag as Avion;
			var av = (from av1 in avn.Avions where avion.IDAvion == av1.IDAvion select av1).First();

			av.IDAvion = Convert.ToInt32(txtIDAvion.Text);
			txtIDAvion.Clear();
			av.TipAeronava = txtTipAeronava.Text;
			txtTipAeronava.Clear();
			av.NumarLocuri =Convert.ToInt32(txtNrLocuri.Text);
			txtNrLocuri.Clear();
			av.IDPasager = Convert.ToInt32(txtIDPasager.Text);
			txtIDPasager.Clear();

			avn.SaveChanges();
		}

		private void btnAfiseaza_Click(object sender, RoutedEventArgs e)
		{
			var avn = App.AvionDb;

			lbAvion.Items.Clear();

			foreach (var av1 in avn.Avions)
			{
				var itm = new ListViewItem();
				itm.Content = av1.IDAvion + " " + av1.TipAeronava + " " + av1.NumarLocuri + av1.IDPasager + " ";
				itm.Tag = av1;
				lbAvion.Items.Add(itm);
			}
		}

		private void lbAvion_ContextMenuClosing(object sender, ContextMenuEventArgs e)
		{

			ListViewItem lv = lbAvion.SelectedItem as ListViewItem;
			txtSters.Text = lv.Content.ToString();
			//btnAdaug.IsEnabled = false;
		}
	}
}
