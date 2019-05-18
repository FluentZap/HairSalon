using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace KrillinStyles.Database
{
	public class SalonContext : DbContext
	{
		public SalonContext()
		{ }
		
		public SalonContext(DbContextOptions<SalonContext> options)
			: base(options)
		{ }

		public DbSet<Client> Clients { get; set; }
		public DbSet<Stylist> Stylists { get; set; }
		public DbSet<Specialty> Specialties { get; set; }
		public DbSet<StylistSpecialty> StylistSpecialties { get; set; }

		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseMySQL("server=localhost;database=todd_aden;user=root;password=root;port=3306;");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<StylistSpecialty>().HasKey(ss => new { ss.StylistId, ss.SpecialtyId });
		}

	}

	public class Client
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Stylist Stylist { get; set; }
		public string Phone_number { get; set; }
		public string Alt_phone_number { get; set; }
	}


	public class StylistSpecialty
	{
		public int StylistId { get; set; }
		public Stylist Stylist { get; set; }

		public int SpecialtyId { get; set; }
		public Specialty Specialty { get; set; }
	}

	public class Stylist
	{
		public int Id { get; set; }		
		public string Session_id { get; set; }
		public string Login_name { get; set; }
		public string Password { get; set; }
		public string Name { get; set; }
		public List<StylistSpecialty> StylistSpecialties { get; } = new List<StylistSpecialty>();
	}


	public class Specialty
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<StylistSpecialty> StylistSpecialties { get; } = new List<StylistSpecialty>();
	}
}
