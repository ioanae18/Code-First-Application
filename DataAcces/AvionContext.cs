using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProiectExamen;
using DataAcces;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace DataAcces
{
    public class AvionContext : DbContext
    {
		public DbSet<Pasager> Pasagers { get; set; }
		public DbSet<Avion> Avions { get; set; }
		public DbSet<Bilet> Biletes { get; set; }
		public DbSet<RezervareBilet> RezervareBiletes { get; set; }

		public AvionContext()
			: base("AvionEntities")
		{
		}
	}
}
