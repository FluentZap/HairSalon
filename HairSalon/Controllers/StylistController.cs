﻿using System;
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
			if (!DB.UserCheckBySessionId(HttpContext.Session.Id)) { return RedirectToAction("index", "home"); } //check for logout
			ViewBag.LoggedIn = true;
			User user = DB.UserGetBySessionId(HttpContext.Session.Id);
			List<User> users = DB.UserGetAll();
			ViewBag.UserList = users;
			ViewBag.StylistName = user.Name;
			return View();
		}			

		public IActionResult New(int message)
		{
			if (!DB.UserCheckBySessionId(HttpContext.Session.Id)) { return RedirectToAction("index", "home"); } //check for logout
			ViewBag.LoggedIn = true;
			ViewBag.message = ErrorCodeMessages.FromCode(message);
			return View();
		}
		

		public IActionResult Show(string userId)
		{
			if (!DB.UserCheckBySessionId(HttpContext.Session.Id)) { return RedirectToAction("index", "home"); } //check for logout						
			ViewBag.LoggedIn = true;
			if (DB.UserExistsById(userId))
			{
				User viewUser = DB.UserGetById(userId);
				User user = DB.UserGetBySessionId(HttpContext.Session.Id);
				ViewBag.StylistName = user.Name;
				ViewBag.ClientList = DB.ClientGetAllFromUser(userId);
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
			InitSession();
			login_name.ToLower();
			if (login_name == null || name == null || password == null)
			{
				return RedirectToAction("new", new { message = 2 });
			}
			if (!DB.UserExists(login_name))
			{
				DB.UserCreate(login_name, HttpContext.Session.Id, name, password);
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
