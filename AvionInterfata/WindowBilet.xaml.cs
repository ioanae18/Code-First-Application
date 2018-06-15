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
    /// Interaction logic for WindowBilet.xaml
    /// </summary>
    public partial class WindowBilet : Window
    {
        public WindowBilet()
        {
            InitializeComponent();
			

			var avn = App.AvionDb;

			var pas = avn.Pasagers.ToList();
			txtIDPasager.ItemsSource = pas;

			foreach (var b in avn.Biletes)
			{
				var itm = new ListViewItem();
				itm.Content = b.IDBilet + " " + b.Bagaj + " " + b.Destinatie + " " + b.DurataZbor + " " + b.Loc + " " 
					+ b.IDPasager + " ";
				itm.Tag = b;
				lbBilet.Items.Add(itm);
				lbBilet.Items.Clear();
			}
		}

		private void btnAdaug_Click(object sender, RoutedEventArgs e)
		{
			var avn = App.AvionDb;

			Bilet b = new Bilet();

			b.IDBilet = Convert.ToInt32(txtIDBilet.Text);
			txtIDBilet.Clear();
			b.Bagaj = Convert.ToInt32(txtBagaj.Text);
			txtBagaj.Clear();
			b.Destinatie = txtDestinatie.Text;
			txtDestinatie.Clear();
			b.DurataZbor = txtDurata.Text;
			txtDurata.Clear();
			b.Loc = txtLoc.Text;
			txtLoc.Clear();
			//b.IDPasager = Convert.ToInt32(txtIDPasager.Text);
			//txtIDPasager.Clear();

			avn.Biletes.Add(b);
			avn.SaveChanges();

			lbBilet.Items.Clear();
			
			foreach (var b1 in avn.Biletes)
			{
				var itm = new ListViewItem();
				itm.Content = b1.IDBilet + " " + b1.Bagaj + " " + b1.Destinatie + " " + b1.DurataZbor + " " + b1.Loc + " "
					+ b.IDPasager + " ";
				itm.Tag = b1;
				lbBilet.Items.Add(itm);
			}
		}

		private void btnSterg_Click(object sender, RoutedEventArgs e)
		{
			var avn = App.AvionDb;

			Bilet b1 = (lbBilet.SelectedItem as ListViewItem).Tag as Bilet;
			txtSters.Text = " ";
			var s = (from s1 in avn.Biletes where s1.IDBilet == b1.IDBilet select s1).First();
			avn.Biletes.Remove(s);
			avn.SaveChanges();
		}

		private void btnModific_Click(object sender, RoutedEventArgs e)
		{
			var avn = App.AvionDb;
			// if(lbClient.SelectedItem!=null)
			Bilet bilet = (lbBilet.SelectedItem as ListViewItem).Tag as Bilet;
			var b = (from b1 in avn.Biletes where bilet.IDBilet == b1.IDBilet select b1).First();

			b.IDBilet = Convert.ToInt32(txtIDBilet.Text);
			txtIDBilet.Clear();
			b.Bagaj = Convert.ToInt32(txtBagaj.Text);
			txtBagaj.Clear();
			b.Destinatie = txtDestinatie.Text;
			txtDestinatie.Clear();
			b.DurataZbor = txtDurata.Text;
			txtDurata.Clear();
			b.Loc = txtLoc.Text;
			txtLoc.Clear();
			b.IDPasager = Convert.ToInt32(txtIDPasager.Text);
			//txtIDPasager.Clear();
			avn.SaveChanges();
		}

		private void btnAfiseaza_Click(object sender, RoutedEventArgs e)
		{
			var avn = App.AvionDb;

			lbBilet.Items.Clear();

			foreach (var b1 in avn.Biletes)
			{
				var itm = new ListViewItem();
				itm.Content = b1.IDBilet + " " + b1.Bagaj + " " + b1.Destinatie + " " + b1.DurataZbor + " " + b1.Loc + " "
					+ b1.IDPasager + " ";
				itm.Tag = b1;
				lbBilet.Items.Add(itm);
			}
		}

		private void lbBilet_ContextMenuClosing(object sender, ContextMenuEventArgs e)
		{
			ListViewItem lv = lbBilet.SelectedItem as ListViewItem;
			txtSters.Text = lv.Content.ToString();
			//btnAdaug.IsEnabled = false;
		}

		/*
		private void txtIDPasager_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			txtIDPasager.ItemsSource = Pasager.Equals(Nume);
		}
		*/
	}
}
