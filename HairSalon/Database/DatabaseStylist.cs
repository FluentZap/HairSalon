using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KrillinStyles.Database
{
	public partial class DB
	{

		public static bool UserExists(string login_name)
		{
			MySqlConnection conn = DB.Connection();
			conn.Open();
			MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"SELECT * FROM stylist WHERE login_name = @login_name;";
			cmd.Parameters.AddWithValue("@login_name", login_name);
			MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
			bool exists = rdr.Read();
			DB.Close(conn);
			return exists;
		}




		public static long UserCreate(string login_name, string name, string password)
		{
			MySqlConnection conn = DB.Connection();
			conn.Open();
			MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"INSERT INTO stylist (login_name, name, password) VALUES (@login_name, @name, @password);";
			cmd.Parameters.AddWithValue("@login_name", login_name);
			cmd.Parameters.AddWithValue("@name", name);
			cmd.Parameters.AddWithValue("@password", password);
			cmd.ExecuteNonQuery();
			DB.Close(conn);
			return cmd.LastInsertedId;
		}

		public static void UserLogin(string login_name, string password)
		{
			//MySqlConnection conn = DB.Connection();
			//conn.Open();
			//MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
			//cmd.CommandText = @"INSERT INTO stylist (login_name, name, password) VALUES (@login_name, @name, @password);";
			//cmd.Parameters.AddWithValue("@login_name", login_name);
			//cmd.Parameters.AddWithValue("@name", name);
			//cmd.Parameters.AddWithValue("@password", password);
			//cmd.ExecuteNonQuery();
			//DB.Close(conn);
			//return cmd.LastInsertedId;
		}


	}
}
