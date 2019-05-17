using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KrillinStyles.Database
{
	public partial class DB
	{

		public static bool StylistExistsById(int id)
		{
			using (var db = new SalonContext())
			{
				var stylist = db.Stylists.Where(b => b.Id == id).FirstOrDefault();
				return stylist != null;
			}			
		}

		public static bool StylistExists(string login_name)
		{
			using (var db = new SalonContext())
			{
				var stylist = db.Stylists.Where(b => b.Login_name == login_name).FirstOrDefault();
				return stylist != null;
			}
		}

		public static bool StylistCheckBySessionId(string session_id)
		{
			using (var db = new SalonContext())
			{
				var stylist = db.Stylists.Where(b => b.Session_id == session_id).FirstOrDefault();
				return stylist != null;
			}
		}		

		public static void StylistUpdateSessionId(string login_name, string session_id)
		{
			using (var db = new SalonContext())
			{
				var stylist = db.Stylists.Where(b => b.Login_name == login_name).FirstOrDefault();
				stylist.Session_id = session_id;
				db.SaveChanges();
			}			
		}

		public static void StylistLogout(string session_id)
		{
			using (var db = new SalonContext())
			{
				var stylist = db.Stylists.Where(b => b.Session_id == session_id).FirstOrDefault();
				stylist.Session_id = "";
				db.SaveChanges();
			}
		}


		public static long StylistCreate(string login_name, string session_id, string name, string password)
		{
			Stylist stylist = new Stylist { Login_name = login_name, Session_id = session_id, Name = name, Password = password };
			using (var db = new SalonContext())
			{
				db.Stylists.Add(stylist);
				db.SaveChanges();
			}
			return stylist.Id;
		}

		public static List<Stylist> StylistGetAll()
		{
			using (var db = new SalonContext())
			{
				var stylists = db.Stylists.ToList();
				return stylists;
			}			
		}

		public static Stylist StylistGetByName(string login_name)
		{
			using (var db = new SalonContext())
			{
				var stylist = db.Stylists.Where(b => b.Login_name == login_name).FirstOrDefault();
				return stylist;
			}			
		}

		public static Stylist StylistGetBySessionId(string session_id)
		{
			using (var db = new SalonContext())
			{
				var stylist = db.Stylists.Where(b => b.Session_id == session_id).FirstOrDefault();
				return stylist;
			}
		}

		public static Stylist StylistGetById(int id)
		{
			using (var db = new SalonContext())
			{
				var stylist = db.Stylists.Where(b => b.Id == id).FirstOrDefault();
				return stylist;
			}			
		}

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
