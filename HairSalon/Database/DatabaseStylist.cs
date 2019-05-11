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

		public static bool UserCheckBySessionId(string session_id)
		{
			MySqlConnection conn = DB.Connection();
			conn.Open();
			MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"SELECT * FROM stylist WHERE session_id = @session_id;";
			cmd.Parameters.AddWithValue("@session_id", session_id);
			MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
			bool exists = rdr.Read();

			DB.Close(conn);
			return exists;
		}

		public static bool UserCheckByName(string login_name)
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

		public static void UserUpdateSessionId(string login_name, string session_id)
		{
			MySqlConnection conn = DB.Connection();
			conn.Open();
			MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"UPDATE stylist SET session_id = @session_id WHERE login_name = @login_name;";
			cmd.Parameters.AddWithValue("@session_id", session_id);
			cmd.Parameters.AddWithValue("@login_name", login_name);
			cmd.ExecuteNonQuery();
			DB.Close(conn);
		}

		public static void UserLogout(string session_id)
		{
			MySqlConnection conn = DB.Connection();
			conn.Open();
			MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"UPDATE stylist SET session_id = '' WHERE session_id = @session_id;";
			cmd.Parameters.AddWithValue("@session_id", session_id);
			cmd.ExecuteNonQuery();
			DB.Close(conn);
		}


		public static long UserCreate(string login_name, string session_id, string name, string password)
		{
			MySqlConnection conn = DB.Connection();
			conn.Open();
			MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"INSERT INTO stylist (session_id, login_name, name, password) VALUES (@session_id, @login_name, @name, @password);";
			cmd.Parameters.AddWithValue("@session_id", session_id);
			cmd.Parameters.AddWithValue("@login_name", login_name);
			cmd.Parameters.AddWithValue("@name", name);
			cmd.Parameters.AddWithValue("@password", password);
			cmd.ExecuteNonQuery();
			DB.Close(conn);
			return cmd.LastInsertedId;
		}


		public static User UserGetByName(string login_name)
		{
			User user = new User();
			MySqlConnection conn = DB.Connection();
			conn.Open();
			MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"SELECT * FROM stylist WHERE login_name = @login_name;";
			cmd.Parameters.AddWithValue("@login_name", login_name);
			MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
			rdr.Read();
			user.Id = rdr.GetInt32(0);
			user.Session_id = rdr.GetString(1);
			user.Login_name = rdr.GetString(2);
			user.Name = rdr.GetString(3);
			user.Password = rdr.GetString(4);
			DB.Close(conn);
			return user;
		}

		public static User UserGetBySessionId(string session_id)
		{
			User user = new User();
			MySqlConnection conn = DB.Connection();
			conn.Open();
			MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"SELECT * FROM stylist WHERE session_id = @session_id;";
			cmd.Parameters.AddWithValue("@session_id", session_id);
			MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
			rdr.Read();
			user.Id = rdr.GetInt32(0);
			user.Session_id = rdr.GetString(1);
			user.Login_name = rdr.GetString(2);
			user.Name = rdr.GetString(3);
			user.Password = rdr.GetString(4);
			DB.Close(conn);
			return user;
		}

		public static bool UserLogin(string login_name, string password, string session_id)
		{
			if (UserCheckByName(login_name))
			{
				User user = UserGetByName(login_name);
				if (user.Password == password)
				{
					UserUpdateSessionId(user.Login_name, session_id);
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
