using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectExamen
{
	[Table("Pasager")]
	public class Pasager
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public int CNP { get; set; }
		[MaxLength(15)]
		public string Nume { get; set; }
		public string Prenume { get; set; }
		public int Varsta { get; set; }
		public string Telefon { get; set; }
		[MaxLength(10)]
		public string Email { get; set; }
		public string Adresa { get; set; }

		public List<Pasager> Pasagers { get; set; }

		//One-to-many => Pasager - Avion
		public List<Avion> Avions { get; set; }

		//One-to-Many => Pasager - RezervareBilet
		public List<RezervareBilet> RezervareBiletes { get; set; }

		//One-to-Many => Pasager - Bilet
		public List<Bilet> Biletes { get; set; }
	}
}
