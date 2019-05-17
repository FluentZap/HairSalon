using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KrillinStyles.Database
{
	public partial class DB
	{

		public static long ClientCreate(string stylist_id, string name, string phone_number, string alt_phone_number)
		{
			MySqlConnection conn = DB.Connection();
			conn.Open();
			MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"INSERT INTO client (stylist_id, name, phone_number, alt_phone_number) VALUES (@stylist_id, @name, @phone_number, @alt_phone_number);";
			cmd.Parameters.AddWithValue("@stylist_id", stylist_id);
			cmd.Parameters.AddWithValue("@name", name);
			cmd.Parameters.AddWithValue("@phone_number", phone_number);
			cmd.Parameters.AddWithValue("@alt_phone_number", alt_phone_number);
			cmd.ExecuteNonQuery();
			DB.Close(conn);
			return cmd.LastInsertedId;
		}

		public static List<Client> ClientGetAll()
		{
			List<Client> clients = new List<Client>();
			MySqlConnection conn = DB.Connection();
			conn.Open();
			MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"SELECT * FROM client INNER JOIN stylist ON client.stylist_id = stylist.id;";
			MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
			while (rdr.Read())
			{
				Client client = new Client
				{
					Id = rdr.GetInt32(0),
					//Stylist_id = rdr.GetInt32(1),
					Name = rdr.GetString(2),
					Phone_number = rdr.GetString(3),					
					Alt_phone_number = rdr.IsDBNull(4) ? "" : rdr.GetString(4)
				};
				
				//client.Stylist_id = rdr.GetInt32(5);
				//client.Stylist_Name = rdr.GetString(7);
				clients.Add(client);
			}
			DB.Close(conn);
			return clients;
		}

		public static List<Client> ClientGetAllFromUser(string stylist_id)
		{
			List<Client> clients = new List<Client>();
			MySqlConnection conn = DB.Connection();
			conn.Open();
			MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"SELECT * FROM client WHERE stylist_id = @stylist_id;";
			cmd.Parameters.AddWithValue("@stylist_id", stylist_id);
			MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
			while (rdr.Read())
			{
				Client client = new Client
				{
					Id = rdr.GetInt32(0),
					//Stylist_id = rdr.GetInt32(1),
					Name = rdr.GetString(2),
					Phone_number = rdr.GetString(3),
					Alt_phone_number = rdr.IsDBNull(4) ? "" : rdr.GetString(4)
				};				
				clients.Add(client);
			}
			DB.Close(conn);
			return clients;
		}
	}
}
