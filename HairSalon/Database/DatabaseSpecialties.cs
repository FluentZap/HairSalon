using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KrillinStyles.Database
{
	public partial class DB
	{

		public static long SpecialtyCreate(string name)
		{
			using (var db = new SalonContext(Options))
			{
				Specialty specialty = new Specialty { Name = name };
				db.Specialties.Add(specialty);
				db.SaveChanges();
				return specialty.Id;
			}			
		}

		public static void SpecialtyRemove(int id)
		{
			using (var db = new SalonContext(Options))
			{
				db.Specialties.Remove(db.Specialties.Where(b => b.Id == id).FirstOrDefault());
				db.SaveChanges();
			}
		}

		public static bool SpecialtyExists(string specialtyName)
		{
			using (var db = new SalonContext(Options))
			{
				var specialty = db.Specialties.Where(b => b.Name == specialtyName).FirstOrDefault();
				return specialty != null;
			}
		}

		public static bool SpecialtyExistsById(int specialtyId)
		{
			using (var db = new SalonContext(Options))
			{
				var specialty = db.Specialties.Where(b => b.Id == specialtyId).FirstOrDefault();
				return specialty != null;
			}
		}

		public static List<Specialty> SpecialtyGetAll()
		{
			using (var db = new SalonContext(Options))
			{
				var specialties = db.Specialties.ToList();
				return specialties;
			}			
		}

		public static long SpecialtyUpdate(int specialty_id, string name)
		{
			using (var db = new SalonContext(Options))
			{
				Specialty specialty = db.Specialties.Where(b => b.Id == specialty_id).FirstOrDefault();
				specialty.Name = name;				
				db.SaveChanges();
				return specialty.Id;
			}
		}		

	}
}
