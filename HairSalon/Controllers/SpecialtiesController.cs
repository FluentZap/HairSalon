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
	public class SpecialtiesController : Controller
	{
		public IActionResult Index()
		{
			if (!DB.StylistCheckBySessionId(HttpContext.Session.Id)) { return RedirectToAction("index", "home"); } //check for logout
			ViewBag.LoggedIn = true;
			Stylist user = DB.StylistGetBySessionId(HttpContext.Session.Id);
			List<Specialty> specialties = DB.SpecialtyGetAll();
			specialties = specialties.OrderBy(u => u.Name).ToList();
			ViewBag.SpecialtyList = specialties;
			ViewBag.StylistName = user.Name;
			return View();
		}

		public IActionResult New(int message)
		{
			if (!DB.StylistCheckBySessionId(HttpContext.Session.Id)) { return RedirectToAction("index", "home"); } //check for logout
			ViewBag.LoggedIn = true;
			ViewBag.SpecialtyList = DB.SpecialtyGetAll();
			ViewBag.message = ErrorCodeMessages.FromCode(message);
			return View();
		}


		public IActionResult Show(string userId)
		{
			if (!DB.StylistCheckBySessionId(HttpContext.Session.Id)) { return RedirectToAction("index", "home"); } //check for logout						
			ViewBag.LoggedIn = true;
			if (DB.StylistExistsById(int.Parse(userId)))
			{
				Stylist viewUser = DB.StylistGetById(int.Parse(userId));
				Stylist user = DB.StylistGetBySessionId(HttpContext.Session.Id);
				ViewBag.StylistName = user.Name;
				ViewBag.ClientList = DB.ClientGetAllFromUser(int.Parse(userId));
				ViewBag.User = viewUser;
				//ViewBag.message = ErrorCodeMessages.FromCode(message);
				return View();
			}
			else
			{
				return RedirectToAction("index", "stylist");
			}

		}

		public IActionResult Create(string login_name, string name, string password)
		{
			//InitSession();
			login_name.ToLower();
			if (login_name == null || name == null || password == null)
			{
				return RedirectToAction("new", new { message = 2 });
			}
			if (!DB.StylistExists(login_name))
			{
				DB.StylistCreate(login_name, "", name, password);
				return RedirectToAction("index");
			}
			else
			{
				return RedirectToAction("new", new { message = 1 });
			}
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
