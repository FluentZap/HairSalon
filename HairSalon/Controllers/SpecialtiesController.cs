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

		public IActionResult Edit(int specialtyId)
		{
			if (!DB.StylistCheckBySessionId(HttpContext.Session.Id)) { return RedirectToAction("index", "home"); } //check for logout
			ViewBag.LoggedIn = true;
			Stylist user = DB.StylistGetBySessionId(HttpContext.Session.Id);			
			ViewBag.StylistName = user.Name;
			List<Specialty> specialties = DB.SpecialtyGetAll();
			specialties = specialties.OrderBy(u => u.Name).ToList();
			ViewBag.SpecialtyList = specialties;			
			ViewBag.SpecialtyEdit = specialties.Where(b => b.Id == specialtyId).FirstOrDefault();
			return View();
		}

		public IActionResult Create(string specialty)
		{
			if (!DB.StylistCheckBySessionId(HttpContext.Session.Id)) { return RedirectToAction("index", "home"); } //check for logout
			if (specialty == null)
			{
				return RedirectToAction("new", new { message = 2 });
			}
			if (!DB.SpecialtyExists(specialty))
			{
				DB.SpecialtyCreate(specialty);
				return RedirectToAction("index");
			}
			else
			{
				return RedirectToAction("new", new { message = 1 });
			}
		}

		public IActionResult Update(int specialtyId, string specialty)
		{
			if (!DB.StylistCheckBySessionId(HttpContext.Session.Id)) { return RedirectToAction("index", "home"); } //check for logout

			if (specialty == null)
			{
				return RedirectToAction("edit", new { message = 3 });
			}
			DB.SpecialtyUpdate(specialtyId, specialty);
			return RedirectToAction("index");
		}

		public IActionResult Destroy(int specialtyId)
		{
			if (!DB.StylistCheckBySessionId(HttpContext.Session.Id)) { return RedirectToAction("index", "home"); } //check for logout
			if (DB.SpecialtyExistsById(specialtyId))
			{
				DB.SpecialtyRemove(specialtyId);
			}
			return RedirectToAction("index");
		}

		public IActionResult Show(int specialtyId)
		{
			if (!DB.StylistCheckBySessionId(HttpContext.Session.Id)) { return RedirectToAction("index", "home"); } //check for logout						
			ViewBag.LoggedIn = true;
			if (DB.SpecialtyExistsById(specialtyId))
			{
				Stylist viewUser = DB.StylistGetById(specialtyId);
				Stylist user = DB.StylistGetBySessionId(HttpContext.Session.Id);
				ViewBag.Speciality = DB.SpecialtyGetAll().Where(b => b.Id == specialtyId).FirstOrDefault();
				ViewBag.StylistName = user.Name;
				ViewBag.StylistList = DB.StylistGetBySpecialty(specialtyId).StylistSpecialties;
				ViewBag.User = viewUser;
				//ViewBag.message = ErrorCodeMessages.FromCode(message);
				return View();
			}
			else
			{
				return RedirectToAction("index", "stylist");
			}

		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
