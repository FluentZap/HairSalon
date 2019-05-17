using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KrillinStyles.Models;
using KrillinStyles.Database;

namespace KrillinStyles.Controllers
{
    public class HomeController : Controller
    {
		public void InitSession()
		{
			HttpContext.Session.Set("Id", new Byte[0]);
		}

		public IActionResult Index(int message)
        {
			if (DB.StylistCheckBySessionId(HttpContext.Session.Id)) { return RedirectToAction("index", "stylist"); } //check for login			
			if (DB.StylistGetAll().Count == 0)
			{
				return RedirectToAction("new", "stylist");
			}
			ViewBag.LoggedIn = false;
			ViewBag.message = ErrorCodeMessages.FromCode(message);
			return View();
        }

		public IActionResult Create(string login_name, string password)
		{
			InitSession();
			login_name.ToLower();
			bool loggedIn = DB.StylistLogin(login_name, password, HttpContext.Session.Id);
			if (loggedIn)
			{
				return RedirectToAction("index", "stylist");
			}
			else
			{
				return RedirectToAction("index", "home");
			}
		}

		public IActionResult Destroy()
		{
			if (!DB.StylistCheckBySessionId(HttpContext.Session.Id))
			{
				ViewBag.LoggedIn = false;
				return RedirectToAction("index", "home");
			}
			DB.StylistLogout(HttpContext.Session.Id);
			ViewBag.LoggedIn = false;
			return RedirectToAction("index", "home");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
