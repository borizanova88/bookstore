using Knijarnica_Desi.Entities;
using Knijarnica_Desi.Repositories;
using Knijarnica_Desi.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Knijarnica_Desi.Controllers
{
    public class UsersController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            UsersRepository repo = new UsersRepository();
            List<User> items = repo.GetAll();



            ViewData["items"] = items;

            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            UsersRepository repo = new UsersRepository();
            User item = id == null ? new User() : repo.GetById(id.Value);

            EditVM model = new EditVM();
            model.Id = item.Id;
            model.Username = item.Username;
            model.Password = item.Password;
            model.FirstName = item.FirstName;
            model.LastName = item.LastName;

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            UsersRepository repo = new UsersRepository();
            User item = new User();
            item.Id = model.Id;
            item.Username = model.Username;
            item.Password = model.Password;
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;


            repo.Save(item);

            return RedirectToAction("Index", "Users");
        }
        public ActionResult Delete(int id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            UsersRepository repo = new UsersRepository();
            repo.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
