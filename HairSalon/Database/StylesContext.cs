using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace KrillinStyles.Database
{
	public class StylesContext : DbContext
	{
		public DbSet<Client> Clients { get; set; }
		public DbSet<Stylist> Stylists { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySQL("server=localhost;database=todd_aden;user=root;password=root;port=3306;");									
		}

	}
}
