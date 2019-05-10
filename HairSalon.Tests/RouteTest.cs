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
	}
}
