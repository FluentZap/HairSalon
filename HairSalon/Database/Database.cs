using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KrillinStyles.Database
{
	public partial class DB
	{
		public static MySqlConnection Connection()
		{
			MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
			return conn;
		}

		public static void Close(MySqlConnection conn)
		{
			conn.Close();
			if (conn != null)
			{
				conn.Dispose();
			}
		}

	}

	public static class DBConfiguration
	{
		public static string ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=todd_aden;";
	}
}
