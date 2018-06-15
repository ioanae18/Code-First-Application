namespace AvionInterfata
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	using System.Data.Entity.Infrastructure;
	using ProiectExamen;

	public partial class ModelAvion : DbContext
	{
		public ModelAvion()
			: base("name=AvionEntities")
		{
		}
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			throw new UnintentionalCodeFirstException();
		}

		public virtual DbSet<Pasager> Pasagers { get; set; }
		public virtual DbSet<Avion> Avions { get; set; }
		public virtual DbSet<Bilet> Bilets { get; set; }
		public virtual DbSet<RezervareBilet> RezervareBilets { get; set; }
		//public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }

		/*
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<spt_fallback_db>()
				.Property(e => e.xserver_name)
				.IsUnicode(false);

			modelBuilder.Entity<spt_fallback_db>()
				.Property(e => e.name)
				.IsUnicode(false);

			modelBuilder.Entity<spt_fallback_dev>()
				.Property(e => e.xserver_name)
				.IsUnicode(false);

			modelBuilder.Entity<spt_fallback_dev>()
				.Property(e => e.xfallback_drive)
				.IsFixedLength()
				.IsUnicode(false);

			modelBuilder.Entity<spt_fallback_dev>()
				.Property(e => e.name)
				.IsUnicode(false);

			modelBuilder.Entity<spt_fallback_dev>()
				.Property(e => e.phyname)
				.IsUnicode(false);

			modelBuilder.Entity<spt_fallback_usg>()
				.Property(e => e.xserver_name)
				.IsUnicode(false);

			modelBuilder.Entity<spt_values>()
				.Property(e => e.type)
				.IsFixedLength();
		}
		*/
	}
}
