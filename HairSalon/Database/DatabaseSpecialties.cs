using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KrillinStyles.Database
{
	public partial class DB
	{

		public static long SpecialtyCreate(int stylist_id, string name, string phone_number, string alt_phone_number)
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

		public static List<Client> SpecialtyGetAll()
		{
			using (var db = new SalonContext(Options))
			{
				var clients = db.Clients.ToList();
				return clients;
			}			
		}
		
	}
}
