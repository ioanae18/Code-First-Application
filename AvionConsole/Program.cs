using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces;
using ProiectExamen;

namespace AvionConsole
{
	class Program
	{

		static void Main(string[] args)
		{
			try
			{
				//Database.SetInitializer<AvionContext>(new DropCreateHotelWithSeedData());
				AvionContext ac = new AvionContext();
				int count = ac.Pasagers.Count();
				Database.SetInitializer<AvionContext>(new DropCreateDatabaseIfModelChanges<AvionContext>());
			}
			catch (Exception ex)
			{
			}
		}
	}
}
