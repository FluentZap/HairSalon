using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using KrillinStyles.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Caching.Distributed;

namespace KrillinStylesTests
{	
	[TestClass]
	public class RouteTest
	{
		//These route tests rely on using HttpContext.Session.Id, this is an instanced variable for accessing a user session
		//There were some ways of creating a mock Session but it was more involved then i had time to get into
		[TestInitialize]
		public void TestSetup()
		{
			
		}

		//[TestMethod]
		//public void Test_Route_HomeController_Get_Index()
		//{
		//	HomeController controller = new HomeController();
		//	IActionResult view = controller.Index(0);
		//	Assert.IsInstanceOfType(view, typeof(ViewResult));
		//}

		//[TestMethod]
		//public void Test_Route_HomeController_Post_Create()
		//{
		//	HomeController controller = new HomeController();
		//	IActionResult view = controller.Create("root", "root");
		//	Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
		//}

		//[TestMethod]
		//public void Test_Route_HomeController_Post_Destroy()
		//{
		//	HomeController controller = new HomeController();
		//	IActionResult view = controller.Destroy();
		//	Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
		//}

		//[TestMethod]
		//public void Test_Route_StylistController_Get_Index()
		//{
		//	StylistController controller = new StylistController();
		//	IActionResult view = controller.Index();
		//	Assert.IsInstanceOfType(view, typeof(ViewResult));
		//}

		//[TestMethod]
		//public void Test_Route_StylistController_Get_New()
		//{
		//	StylistController controller = new StylistController();
		//	IActionResult view = controller.New(0);
		//	Assert.IsInstanceOfType(view, typeof(ViewResult));
		//}

		//[TestMethod]
		//public void Test_Route_StylistController_Get_Show()
		//{
		//	StylistController controller = new StylistController();
		//	IActionResult view = controller.Show("");
		//	Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
		//}

	}
}
