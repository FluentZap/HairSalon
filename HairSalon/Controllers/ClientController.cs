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
	public class ClientController : Controller
	{

		public void InitSession()
		{			
			HttpContext.Session.Set("Id", new Byte[0]);
		}

		public IActionResult Index()
		{
			if (!DB.StylistCheckBySessionId(HttpContext.Session.Id)) { return RedirectToAction("index", "home"); } //check for logout
			ViewBag.LoggedIn = true;
			Stylist user = DB.StylistGetBySessionId(HttpContext.Session.Id);
			ViewBag.ClientList = DB.ClientGetAll();			
			ViewBag.StylistName = user.Name;
			return View();
		}			

		public IActionResult New(int message)
		{
			if (!DB.StylistCheckBySessionId(HttpContext.Session.Id)) { return RedirectToAction("index", "home"); } //check for logout
			ViewBag.LoggedIn = true;
			ViewBag.message = ErrorCodeMessages.FromCode(message);
			List<Stylist> users = DB.StylistGetAll();
			ViewBag.UserList = users;
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

		public IActionResult Create(string client_name, string phone_number, string alt_phone_number, string stylist_id)
		{						
			if (client_name == null || phone_number == null || stylist_id == null)
			{
				return RedirectToAction("new", new { message = 3 });
			}
			DB.ClientCreate(int.Parse(stylist_id), client_name, phone_number, alt_phone_number);
			return RedirectToAction("index");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
