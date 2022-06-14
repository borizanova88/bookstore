using Knijarnica_Desi.Entities;
using Knijarnica_Desi.Filters;
using Knijarnica_Desi.Repositories;
using Knijarnica_Desi.ViewModels.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Knijarnica_Desi.Controllers
{
    [AuthenticationFilter]
    public class BooksController : Controller
    {
        // GET: Books

        public ActionResult Index(IndexVM model)
        {
            BooksRepository booksRepo = new BooksRepository();
           
            model.Items = booksRepo.GetAll(model.Books);

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            BooksRepository booksRepo = new BooksRepository();
            Book item = id == null ? new Book() : booksRepo.GetById(id.Value);

            EditVM model = new EditVM();
            model.Id = item.Id;
            model.Bookname = item.Bookname;
            model.Author = item.Author;
            model.Genre = item.Genre;

            return View(model);

        }
    }
}