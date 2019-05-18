using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace KrillinStyles.Database
{
	public partial class DB
	{

		public static DbContextOptions<SalonContext> Options { get; set; }

		static DB()
		{
			var optionsBuilder = new DbContextOptionsBuilder<SalonContext>();
			optionsBuilder.UseMySQL("server=localhost;database=todd_aden;user=root;password=root;port=3306;");
			Options = optionsBuilder.Options;
		}


		public static bool StylistExistsById(int id)
		{
			using (var db = new SalonContext(Options))
			{
				var stylist = db.Stylists.Where(b => b.Id == id).FirstOrDefault();
				return stylist != null;
			}
		}

		public static bool StylistExists(string login_name)
		{
			using (var db = new SalonContext(Options))
			{
				var stylist = db.Stylists.Where(b => b.Login_name == login_name).FirstOrDefault();
				return stylist != null;
			}
		}

		public static bool StylistCheckBySessionId(string session_id)
		{
			using (var db = new SalonContext(Options))
			{
				var stylist = db.Stylists.Where(b => b.Session_id == session_id).FirstOrDefault();
				return stylist != null;
			}
		}		

		public static void StylistUpdateSessionId(string login_name, string session_id)
		{
			using (var db = new SalonContext(Options))
			{
				var stylist = db.Stylists.Where(b => b.Login_name == login_name).FirstOrDefault();
				stylist.Session_id = session_id;
				db.SaveChanges();
			}			
		}

		public static void StylistLogout(string session_id)
		{
			using (var db = new SalonContext(Options))
			{
				var stylist = db.Stylists.Where(b => b.Session_id == session_id).FirstOrDefault();
				stylist.Session_id = "";
				db.SaveChanges();
			}
		}


		public static long StylistCreate(string login_name, string session_id, string name, string password)
		{
			Stylist stylist = new Stylist { Login_name = login_name, Session_id = session_id, Name = name, Password = password };
			using (var db = new SalonContext(Options))
			{
				db.Stylists.Add(stylist);
				db.SaveChanges();
			}
			return stylist.Id;
		}

		public static long StylistUpdate(int userId, string login_name, string session_id, string name, string password)
		{			
			using (var db = new SalonContext(Options))
			{
				Stylist stylist = db.Stylists.Where(b => b.Id == userId).FirstOrDefault();
				stylist.Login_name = login_name;
				stylist.Session_id = session_id;
				stylist.Name = name;
				stylist.Password = password;
				db.Update(stylist);
				db.SaveChanges();
				return stylist.Id;
			}
		}

		public static List<Stylist> StylistGetAll()
		{
			using (var db = new SalonContext(Options))
			{				
				var stylists = db.Stylists.Include(e => e.StylistSpecialties).ThenInclude(s => s.Specialty).ToList();
				return stylists;
			}			
		}

		public static Stylist StylistGetByName(string login_name)
		{
			using (var db = new SalonContext(Options))
			{
				var stylist = db.Stylists.Where(b => b.Login_name == login_name).FirstOrDefault();
				return stylist;
			}			
		}

		public static Stylist StylistGetBySessionId(string session_id)
		{
			using (var db = new SalonContext(Options))
			{
				var stylist = db.Stylists.Where(b => b.Session_id == session_id).FirstOrDefault();
				return stylist;
			}
		}

		public static Stylist StylistGetById(int id)
		{
			using (var db = new SalonContext(Options))
			{
				var stylist = db.Stylists.Where(b => b.Id == id).FirstOrDefault();
				return stylist;
			}			
		}

		public static void StylistRemove(int id)
		{
			using (var db = new SalonContext(Options))
			{
				db.Stylists.Remove(db.Stylists.Where(b => b.Id == id).FirstOrDefault());
				db.SaveChanges();
			}
		}

		public static void StylistRemoveAll()
		{
			using (var db = new SalonContext(Options))
			{
				db.Stylists.RemoveRange(db.Stylists.ToArray());
				db.SaveChanges();
			}
		}


		//public static List<Stylist> StylistGetBySpecialty(int specialty_id)
		//{
		//	using (var db = new SalonContext(Options))
		//	{
		//		var specialty = db.Specialties.Include(e => e.StylistSpecialties).ThenInclude(s => s.Stylist).ToList();
		//		//var stylists = db.Stylists.Include(e => e.StylistSpecialties).ThenInclude(s => s.Specialty).ToList();
				
		//		return stylists;
		//	}
		//}

		public static bool StylistLogin(string login_name, string password, string session_id)
		{
			if (StylistExists(login_name))
			{
				Stylist user = StylistGetByName(login_name);
				if (user.Password == password)
				{
					StylistUpdateSessionId(user.Login_name, session_id);
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}			
		}
	}
}
