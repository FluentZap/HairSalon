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

		[TestMethod]
		public void Test_Database_Stylist_UserExists()
		{
			Assert.IsTrue(DB.StylistExists("root"));
			Assert.IsFalse(DB.StylistExists("sillyPants"));
		}

		[TestMethod]
		public void Test_Database_Stylist_UserExistsById()
		{
			Assert.IsTrue(DB.StylistExistsById(1));
			Assert.IsFalse(DB.StylistExistsById(745779));
		}

		[TestMethod]
		public void Test_Database_Stylist_UserCheckBySessionId()
		{
			Assert.IsTrue(DB.StylistCheckBySessionId("820add4c-793b-c1b1-611c-bbbe5255d64b"));
			Assert.IsFalse(DB.StylistCheckBySessionId("Like a not good Session Id"));
		}


		//This test will run once... But not once the test user is created.
		//[TestMethod]
		//public void Test_Database_Stylist_UserCreate()
		//{
		//	Assert.IsFalse(DB.UserExists("test_man"));
		//	DB.UserCreate("test_man", "62145b09-15f1-9722-760f-a66448d00f2e", "Test Man", "root");
		//	Assert.IsTrue(DB.UserExists("test_man"));
		//}
		
	}
}
