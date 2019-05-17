using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using KrillinStyles.Database;
using Microsoft.EntityFrameworkCore;

namespace KrillinStylesTests
{

	[TestClass]
	public class DatabaseTests
	{

		public static DbContextOptions<SalonContext> Options { get; set; }

		[TestInitialize]
		public void TestSetup()
		{
			var optionsBuilder = new DbContextOptionsBuilder<SalonContext>();
			optionsBuilder.UseMySQL("server=localhost;database=todd_aden_test;user=root;password=root;port=3306;");
			Options = optionsBuilder.Options;
			DB.Options = optionsBuilder.Options;
		}

		[TestCleanup]
		public void TestCleanup()
		{
			using (var db = new SalonContext(Options))
			{
				db.Stylists.RemoveRange(db.Stylists.ToArray());
				db.Clients.RemoveRange(db.Clients.ToArray());
				db.Specialties.RemoveRange(db.Specialties.ToArray());
				db.StylistSpecialties.RemoveRange(db.StylistSpecialties.ToArray());
				db.SaveChanges();
			}
		}

		[TestMethod]
		public void Test_Database_Stylist_UserCreate()
		{
			Assert.IsFalse(DB.StylistExists("test_man"));
			DB.StylistCreate("test_man", "62145b09-15f1-9722-760f-a66448d00f2e", "Test Man", "root");
			Assert.IsTrue(DB.StylistExists("test_man"));
		}

		[TestMethod]
		public void Test_Database_Stylist_UserExists()
		{
			DB.StylistCreate("test_man", "62145b09-15f1-9722-760f-a66448d00f2e", "Test Man", "root");

			Assert.IsTrue(DB.StylistExists("test_man"));
			Assert.IsFalse(DB.StylistExists("sillyPants"));
		}

		[TestMethod]
		public void Test_Database_Stylist_UserExistsById()
		{			
			int id = (int)DB.StylistCreate("test_man", "62145b09-15f1-9722-760f-a66448d00f2e", "Test Man", "root");
			Assert.IsTrue(DB.StylistExistsById(id));
			Assert.IsFalse(DB.StylistExistsById(745779));
		}

		[TestMethod]
		public void Test_Database_Stylist_UserCheckBySessionId()
		{
			int id = (int)DB.StylistCreate("test_man", "820add4c-793b-c1b1-611c-bbbe5255d64b", "Test Man", "root");
			Assert.IsTrue(DB.StylistCheckBySessionId("820add4c-793b-c1b1-611c-bbbe5255d64b"));
			Assert.IsFalse(DB.StylistCheckBySessionId("Like a not good Session Id"));
		}
		
	}
}
