using Knijarnica_Desi.Entities;
using Knijarnica_Desi.Filters;
using Knijarnica_Desi.Repositories;
using Knijarnica_Desi.ViewModels.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Knijarnica_Desi.Controllers
{
    public class ContactsController : Controller
    {
        [AuthenticationFilter]
        // GET: Contacts
        public ActionResult Index()
        {
            User loggedUser = (User)Session["loggedUser"];

            ContactsRepository repo = new ContactsRepository();
            IndexVM model = new IndexVM();

            model.Items = repo.GetAll(loggedUser.Id);

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            User loggedUser = (User)Session["loggedUser"];

            ContactsRepository repo = new ContactsRepository();
            Contact item = id == null ? new Contact() : repo.GetById(id.Value);

            EditVM model = new EditVM();
            model.Id = item.Id;
            model.UserId = loggedUser.Id;
            model.FirstName = item.FirstName;
            model.LastName = item.LastName;
            model.Email = item.Email;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            User loggedUser = (User)Session["loggedUser"];

            if (!ModelState.IsValid)
                return View(model);

            ContactsRepository repo = new ContactsRepository();

            Contact item = new Contact();
            item.Id = model.Id;
            item.UserId = loggedUser.Id;
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;
            item.Email = model.Email;

            if (item.Id > 0)
                repo.Update(item);
            else
                repo.Insert(item);

            return RedirectToAction("Index", "Contacts");
        }

        public ActionResult Delete(int id)
        {

            ContactsRepository repo = new ContactsRepository();
            repo.Delete(id);

            return RedirectToAction("Index", "Contacts");
        }
    }
}