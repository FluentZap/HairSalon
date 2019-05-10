using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using KrillinStyles.Controllers;

namespace KrillinStylesTests
{
	[TestClass]
	public class RouteTest
	{
		[TestMethod]
		public void Test_Route_HomeController_Get_Index()
		{
			HomeController controller = new HomeController();
			IActionResult view = controller.Index();
			Assert.IsInstanceOfType(view, typeof(ViewResult));
		}

		[TestMethod]
		public void Test_Route_HomeController_Get_New()
		{
			HomeController controller = new HomeController();
			IActionResult view = controller.New();
			Assert.IsInstanceOfType(view, typeof(ViewResult));
		}

		[TestMethod]
		public void Test_Route_StylistController_Get_Index()
		{
			StylistController controller = new StylistController();
			IActionResult view = controller.Index();
			Assert.IsInstanceOfType(view, typeof(ViewResult));
		}

		[TestMethod]
		public void Test_Route_StylistController_Get_Update()
		{
			StylistController controller = new StylistController();
			IActionResult view = controller.Update();
			Assert.IsInstanceOfType(view, typeof(ViewResult));
		}

		[TestMethod]
		public void Test_Route_StylistController_Get_Create()
		{
			StylistController controller = new StylistController();
			IActionResult view = controller.Create();
			Assert.IsInstanceOfType(view, typeof(ViewResult));
		}
	}
}
