using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KrillinStyles.Database
{
	public partial class DB
	{

		public static long ClientCreate(int stylist_id, string name, string phone_number, string alt_phone_number)
		{
			using (var db = new SalonContext())
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
			using (var db = new SalonContext())
			{
				var clients = db.Clients.ToList();
				return clients;
			}			
		}

		public static List<Client> ClientGetAllFromUser(int stylist_id)
		{
			using (var db = new SalonContext())
			{
				var clients = db.Clients.Where(b => b.Stylist == DB.StylistGetById(stylist_id)).ToList();
				return clients;
			}			
		}
	}
}
