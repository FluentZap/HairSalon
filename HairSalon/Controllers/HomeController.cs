using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KrillinStyles.Models;

namespace KrillinStyles.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int message)
        {
			ViewBag.message = ErrorCodeMessages.FromCode(message);
			return View();
        }

		public IActionResult New()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
