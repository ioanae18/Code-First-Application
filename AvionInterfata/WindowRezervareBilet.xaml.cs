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

namespace AvionInterfata
{
    /// <summary>
    /// Interaction logic for WindowRezervareBilet.xaml
    /// </summary>
    public partial class WindowRezervareBilet : Window
    {
        public WindowRezervareBilet()
        {
            InitializeComponent();

			var avn = App.AvionDb;

			foreach (var rb in avn.RezervareBiletes)
			{
				var itm = new ListViewItem();
				itm.Content = rb.IDRezervare + " " + rb.Clasa + " " + rb.DataSosire + " " + rb.DataPlecare + " " 
					+ rb.Destinatie + " " + rb.Tarif + " " + rb.IDPasager + " ";
				itm.Tag = rb;
				lbRezervareBilet.Items.Add(itm);
				lbRezervareBilet.Items.Clear();
			}
		}

		private void btnAdaug_Click(object sender, RoutedEventArgs e)
		{
			var avn = App.AvionDb;

			RezervareBilet rb = new RezervareBilet();

			rb.IDRezervare = Convert.ToInt32(txtCodRezervare.Text);
			txtCodRezervare.Clear();
			rb.Clasa = txtClasa.Text;
			txtClasa.Clear();
			rb.DataSosire = Convert.ToDateTime(dpDataSosire.Text);
		    //dpDataSosire.Clear();
			rb.DataPlecare = Convert.ToDateTime(dpDataPlecare.Text);
			//dpDataPlecare.Clear();
			rb.Destinatie = txtDestinatie.Text;
			txtDestinatie.Clear();
			rb.Tarif = Convert.ToInt32(txtTarif.Text);
			txtTarif.Clear();
			rb.IDPasager = Convert.ToInt32(txtIDPasager.Text);
			txtIDPasager.Clear();

			avn.RezervareBiletes.Add(rb);
			avn.SaveChanges();

			lbRezervareBilet.Items.Clear();

			foreach (var rb1 in avn.RezervareBiletes)
			{
				var itm = new ListViewItem();
				itm.Content = rb1.IDRezervare + " " + rb1.Clasa + " " + rb1.DataSosire + " " + rb1.DataPlecare + " "
									+ rb1.Destinatie + " " + rb1.Tarif + " " + rb.IDPasager + " ";
				itm.Tag = rb1;
				lbRezervareBilet.Items.Add(itm);
			}
		}

		private void btnSterg_Click(object sender, RoutedEventArgs e)
		{
			var avn = App.AvionDb;

			RezervareBilet rb1 = (lbRezervareBilet.SelectedItem as ListViewItem).Tag as RezervareBilet;
			txtSters.Text = " ";
			var s = (from s1 in avn.RezervareBiletes where s1.IDRezervare == rb1.IDRezervare select s1).First();
			avn.RezervareBiletes.Remove(s);
			avn.SaveChanges();
		}

		private void btnModific_Click(object sender, RoutedEventArgs e)
		{
			var avn = App.AvionDb;
			// if(lbClient.SelectedItem!=null)
			RezervareBilet rezbilet = (lbRezervareBilet.SelectedItem as ListViewItem).Tag as RezervareBilet;
			var rb = (from rb1 in avn.RezervareBiletes where rezbilet.IDRezervare == rb1.IDRezervare select rb1).First();

			rb.IDRezervare = Convert.ToInt32(txtCodRezervare.Text);
			txtCodRezervare.Clear();
			rb.Clasa = txtClasa.Text;
			txtClasa.Clear();
			rb.DataSosire = Convert.ToDateTime(dpDataSosire.Text);
			//dpDataSosire.Clear();
			rb.DataPlecare = Convert.ToDateTime(dpDataPlecare.Text);
			//dpDataPlecare.Clear();
			rb.Destinatie = txtDestinatie.Text;
			txtDestinatie.Clear();
			rb.Tarif = Convert.ToInt32(txtTarif.Text);
			txtTarif.Clear();
			rb.IDPasager = Convert.ToInt32(txtIDPasager.Text);
			txtIDPasager.Clear();
			avn.SaveChanges();
		}

		private void btnAfiseaza_Click(object sender, RoutedEventArgs e)
		{
			var avn = App.AvionDb;

			lbRezervareBilet.Items.Clear();

			foreach (var rb1 in avn.RezervareBiletes)
			{
				var itm = new ListViewItem();
				itm.Content = rb1.IDRezervare + " " + rb1.Clasa + " " + rb1.DataSosire + " " + rb1.DataPlecare + " "
												+ rb1.Destinatie + " " + rb1.Tarif + " " + rb1.IDPasager + " ";
				itm.Tag = rb1;
				lbRezervareBilet.Items.Add(itm);
			}
		}

		private void lbRezervareBilet_ContextMenuClosing(object sender, ContextMenuEventArgs e)
		{
			ListViewItem lv = lbRezervareBilet.SelectedItem as ListViewItem;
			txtSters.Text = lv.Content.ToString();
			//btnAdaug.IsEnabled = false;
		}
	}
}
