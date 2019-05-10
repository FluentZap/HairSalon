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
	public class StylistController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Update()
		{

			return View();
		}

		public IActionResult Create(string login_name, string name, string password)
		{
			if (!DB.UserExists(login_name))
			{
				DB.UserCreate(login_name, name, password);
				return RedirectToAction("Index");
			}
			else
			{
				return RedirectToAction("Index", "Home", new { message = 1 });
			}
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
