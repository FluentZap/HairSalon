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

		public void InitSession()
		{			
			HttpContext.Session.Set("Id", new Byte[0]);
		}

		public IActionResult Index()
		{
			if (!DB.StylistCheckBySessionId(HttpContext.Session.Id)) { return RedirectToAction("index", "home"); } //check for logout
			ViewBag.LoggedIn = true;
			Stylist user = DB.StylistGetBySessionId(HttpContext.Session.Id);
			List<Stylist> users = DB.StylistGetAll();
			ViewBag.UserList = users;
			ViewBag.StylistName = user.Name;
			return View();
		}			

		public IActionResult New(int message)
		{
			if (!DB.StylistCheckBySessionId(HttpContext.Session.Id)) //check for logout
			{
				if (DB.StylistGetAll().Count > 0) //no users initiate administrator login 
				{
					return RedirectToAction("index", "home");					
				}
				else
				{
					ViewBag.message = ErrorCodeMessages.FromCode(4);
					return View();
				}
			}
			ViewBag.LoggedIn = true;
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

		public IActionResult Update(string login_name, string name, string password, int userId, List<int> specialties)
		{
			if (!DB.StylistCheckBySessionId(HttpContext.Session.Id)) { return RedirectToAction("index", "home"); } //check for logout

			if (login_name == null || name == null)
			{
				return RedirectToAction("Edit", new { message = 2, userId });
			}
			login_name = login_name.ToLower();
			if (DB.StylistExistsById(userId))
			{
				DB.StylistUpdate(userId, login_name, "", name, password, specialties);
				return RedirectToAction("index");
			}
			else
			{
				return RedirectToAction("new", new { message = 1 });
			}
		}

		public IActionResult Create(string login_name, string name, string password)
		{
			if (!DB.StylistCheckBySessionId(HttpContext.Session.Id) && DB.StylistGetAll().Count > 0) { return RedirectToAction("index", "home"); } //check for logout
			InitSession();
			if (login_name == null || name == null || password == null)
			{
				return RedirectToAction("new", new { message = 2 });
			}
			login_name = login_name.ToLower();
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

		public IActionResult Edit(string userId, int message)
		{
			if (!DB.StylistCheckBySessionId(HttpContext.Session.Id)) { return RedirectToAction("index", "home"); } //check for logout						
			ViewBag.message = ErrorCodeMessages.FromCode(message);
			ViewBag.User = DB.StylistGetBySessionId(HttpContext.Session.Id);
			
			List<Stylist> users = DB.StylistGetAll();
			ViewBag.UserList = users;		

			ViewBag.EditUser = DB.StylistGetById(int.Parse(userId));

			List<Specialty> specialties = DB.SpecialtyGetAll();
			specialties = specialties.OrderBy(u => u.Name).ToList();
			ViewBag.SpecialtyList = specialties;
			ViewBag.LoggedIn = true;

			return View();
		}


		public IActionResult Destroy(string userId)
		{
			if (!DB.StylistCheckBySessionId(HttpContext.Session.Id)) { return RedirectToAction("index", "home"); } //check for logout
			if (!DB.StylistExists(userId))
			{
				DB.StylistRemove(int.Parse(userId));
			}
			return RedirectToAction("index");
		}

		public IActionResult DestroySpeciality(int userId, int specialtyId)
		{
			if (!DB.StylistCheckBySessionId(HttpContext.Session.Id)) { return RedirectToAction("index", "home"); } //check for logout
			if (DB.StylistExistsById(userId))
			{
				DB.StylistRemoveSpecialty(userId, specialtyId);
			}
			return RedirectToAction("edit", new { userId });
		}

		public IActionResult DestroyAll()
		{
			if (!DB.StylistCheckBySessionId(HttpContext.Session.Id)) { return RedirectToAction("index", "home"); } //check for logout
			DB.StylistRemoveAll();			
			return RedirectToAction("index");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
