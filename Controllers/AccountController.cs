using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using TrainingSite.Models;
using TrainingSite.VIewModel;
// ReSharper disable All

namespace TrainingSite.Controllers
{
	public class AccountController : Controller
	{
		private readonly DataBaseContext _db = new DataBaseContext();

		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(LoginModel model)
		{
			if (ModelState.IsValid)
			{
				// поиск пользователя в бд
				var user = _db.UsersList.FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);

				if (user != null)
				{
					FormsAuthentication.SetAuthCookie(model.Login, true);
					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
				}
			}

			return View(model);
		}

		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Register(RegisterModel model)
		{
			if (ModelState.IsValid)
			{
				var user = _db.UsersList.FirstOrDefault(u => u.Login == model.Login);

				if (user == null)
				{
					// создаем нового пользователя
					var role = _db.GroupsList.FirstOrDefault(i => i.Name == "User");
					_db.UsersList.Add(new User {
						Login = model.Login, 
						Password = model.Password, 
						//DateOfBirthday = DateTime.Today,
						//EmploymentDate = DateTime.Today,
						Group = role
					});
					_db.SaveChanges();

					user = _db.UsersList.FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);


					// если пользователь удачно добавлен в бд
					if (user != null)
					{
						FormsAuthentication.SetAuthCookie(model.Login, true);
						return RedirectToAction("Index", "Home");
					}
				}
				else
				{
					ModelState.AddModelError("", "Пользователь с таким логином уже существует");
				}
			}

			return View(model);
		}

		public ActionResult Logoff()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Index", "Home");
		}
	}
}