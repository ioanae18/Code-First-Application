using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectExamen
{
	[Table("RezervareBilet")]
	public class RezervareBilet
	{
		[Key]
		public int IDRezervare { get; set; }
		[Required]
		public string Clasa { get; set; }
		[Required]
		public DateTime DataSosire { get; set; }
		[Required]
		public DateTime DataPlecare { get; set; }
		[Required]
		public string Destinatie { get; set; }
		[Required]
		public double Tarif { get; set; }

		//One-to-many => Rezervare-Bilet - Pasager
		[ForeignKey("IDPasager")]
		public virtual Pasager Pasager { get; set; }
		public int IDPasager { get; set; }
	}
}
