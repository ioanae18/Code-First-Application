using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectExamen
{

	[Table("Avion")]
	public class Avion
	{
		[Key]
		public int IDAvion { get; set; }
		public string TipAeronava { get; set; }
		public int NumarLocuri { get; set; }

		//One-to-many => Avion - Pasager
		[ForeignKey("IDPasager")]
		public virtual Pasager Pasager { get; set; }
		public int IDPasager { get; set; }
	}

}
