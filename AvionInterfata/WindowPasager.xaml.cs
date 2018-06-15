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
	/// Interaction logic for WindowPasager.xaml
	/// </summary>
	public partial class WindowPasager : Window
	{
		public WindowPasager()
		{
			InitializeComponent();

			var avn = App.AvionDb;
			
			foreach (var p in avn.Pasagers)
			{
				var itm = new ListViewItem();
				itm.Content = p.ID + " " + p.CNP + " " + p.Nume + " " + p.Prenume + " " + p.Varsta + " " + 
					p.Telefon + " " + p.Email + " " + p.Adresa;
				itm.Tag = p;
				lbPasageri.Items.Add(itm);
				lbPasageri.Items.Clear();
			}
			
		}

		private void btnAdaug_Click(object sender, RoutedEventArgs e)
		{
			var avn = App.AvionDb;

			Pasager p = new Pasager();

			p.ID = Convert.ToInt32(txtIDPasager.Text);
			txtIDPasager.Clear();
			p.CNP = Convert.ToInt32(txtCNP.Text);
			txtCNP.Clear();
			p.Nume = txtNume.Text;
			txtNume.Clear();
			p.Prenume = txtPrenume.Text;
			txtPrenume.Clear();
			p.Varsta = Convert.ToInt32(txtVarsta.Text);
			txtVarsta.Clear();
			p.Telefon = txtTelefon.Text;
			txtTelefon.Clear();
			p.Email = txtEmail.Text;
			txtEmail.Clear();
			p.Adresa = txtAdresa.Text;
			txtAdresa.Clear();

			avn.Pasagers.Add(p);
			avn.SaveChanges();

			lbPasageri.Items.Clear();

			foreach (var p1 in avn.Pasagers)
			{
				var itm = new ListViewItem();
				itm.Content = p1.ID + " " + p1.CNP + " " + p1.Nume + " " + p1.Prenume + " " 
					+ p1.Varsta + " " + p1.Telefon + " " + p1.Email + " " + p1.Adresa;
				itm.Tag = p1;
				lbPasageri.Items.Add(itm);
			}
		}

		private void btnSterg_Click(object sender, RoutedEventArgs e)
		{
			var avn = App.AvionDb;

			Pasager p1 = (lbPasageri.SelectedItem as ListViewItem).Tag as Pasager;
			txtSters.Text = " ";
			var s = (from s1 in avn.Pasagers where s1.ID == p1.ID select s1).First();
			avn.Pasagers.Remove(s);
			avn.SaveChanges();
		}

		private void btnModific_Click(object sender, RoutedEventArgs e)
		{
			var avn = App.AvionDb;
			// if(lbClient.SelectedItem!=null)
			Pasager pasager = (lbPasageri.SelectedItem as ListViewItem).Tag as Pasager;
			var p = (from p1 in avn.Pasagers where pasager.ID == p1.ID select p1).First();

			p.ID = Convert.ToInt32(txtIDPasager.Text);
			p.CNP = Convert.ToInt32(txtCNP.Text);
			p.Nume = txtNume.Text;
			p.Prenume = txtPrenume.Text;
			p.Adresa = txtAdresa.Text;
			p.Telefon = txtTelefon.Text;
			p.Email = txtEmail.Text;
			p.Varsta = Convert.ToInt32(txtVarsta.Text);
			avn.SaveChanges();
		}

		private void btnAfiseaza_Click(object sender, RoutedEventArgs e)
		{
			var avn = App.AvionDb;

			lbPasageri.Items.Clear();

			foreach (var p1 in avn.Pasagers)
			{
				var itm = new ListViewItem();
				itm.Content = p1.ID + " " + p1.CNP + " " 
					+ p1.Nume + " " + p1.Prenume + " " + p1.Adresa + " " 
					+ p1.Telefon + " " + p1.Email + " " + p1.Varsta + " ";
				itm.Tag = p1;
				lbPasageri.Items.Add(itm);
			}
		}

		private void lbPasageri_ContextMenuClosing(object sender, ContextMenuEventArgs e)
		{
			ListViewItem lv = lbPasageri.SelectedItem as ListViewItem;
			txtSters.Text = lv.Content.ToString();
			//btnAdaug.IsEnabled = false;
		}
	}
}
