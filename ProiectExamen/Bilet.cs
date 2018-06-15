using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectExamen
{
	[Table("Bilet")]
	public class Bilet
	{
		[Key]
		public int IDBilet { get; set; }
		[Required]
		public int Bagaj { get; set; }
		public string Destinatie { get; set; }
		public string DurataZbor { get; set; }
		public string Loc { get; set; }

		//One-to-many => Pasager - Bilet
		[ForeignKey("IDPasager")]
		public virtual Pasager Pasager { get; set; }
		public int IDPasager { get; set; }
	}
}
