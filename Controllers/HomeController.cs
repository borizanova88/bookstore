using Knijarnica_Desi.Repositories;
using Knijarnica_Desi.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Knijarnica_Desi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            LoginVM model = new LoginVM();
            return View(model);
        }


        [HttpPost]
        public ActionResult Login(LoginVM model)
        {

            if (!ModelState.IsValid)
                return View(model);

            UsersRepository repo = new UsersRepository();
            Session["loggedUser"] = repo.GetByUsernameAndPassword(model.Username, model.Password);

            if (Session["loggedUser"] == null)
                ModelState.AddModelError("AuthenticationFailed", "Authentication Failed !!!");

            if (!ModelState.IsValid)
                return View(model);


            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout()
        {
            Session["loggedUser"] = null;
            return RedirectToAction("Login", "Home");
        }
    }
}