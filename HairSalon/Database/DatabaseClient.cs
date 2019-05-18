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
		public static bool ClientExistsById(int id)
		{
			using (var db = new SalonContext(Options))
			{
				var client = db.Clients.Where(b => b.Id == id).FirstOrDefault();
				return client != null;
			}
		}

		public static long ClientCreate(int stylist_id, string name, string phone_number, string alt_phone_number)
		{
			using (var db = new SalonContext(Options))
			{
				Stylist stylist = db.Stylists.Where(b => b.Id == stylist_id).FirstOrDefault();
				Client client = new Client { Stylist = stylist, Name = name,
					Phone_number = phone_number, Alt_phone_number = alt_phone_number };
				db.Clients.Add(client);
				db.SaveChanges();
				return client.Id;
			}			
		}

		public static List<Client> ClientGetAll()
		{
			using (var db = new SalonContext(Options))
			{
				var clients = db.Clients.Include("Stylist").ToList();
				return clients;
			}			
		}

		public static List<Client> ClientGetAllFromUser(int stylist_id)
		{
			using (var db = new SalonContext(Options))
			{
				var clients = db.Clients.Include("Stylist").Where(b => b.Stylist == DB.StylistGetById(stylist_id)).ToList();
				return clients;
			}			
		}

		public static void ClientRemoveAllFromUser(int userId)
		{
			using (var db = new SalonContext(Options))
			{
				db.Clients.RemoveRange(db.Clients.Include("Stylist").Where(b => b.Stylist == DB.StylistGetById(userId)).ToArray());
				db.SaveChanges();
			}
		}

		public static void ClientRemove(int id)
		{
			using (var db = new SalonContext(Options))
			{
				db.Clients.Remove(db.Clients.Where(b => b.Id == id).FirstOrDefault());
				db.SaveChanges();
			}
		}

		public static void ClientRemoveAll()
		{
			using (var db = new SalonContext(Options))
			{
				db.Clients.RemoveRange(db.Clients.ToArray());
				db.SaveChanges();
			}
		}
	}
}
