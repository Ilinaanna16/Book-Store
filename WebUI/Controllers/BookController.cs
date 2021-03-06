using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;

namespace WebUI.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository repository;
        public int pageSize = 4;
        public BookController(IBookRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(int page = 1)
        {
            return View(repository.Books
            .OrderBy(book => book.BookId)
            .Skip((page - 1)*pageSize)
            .Take(pageSize));
        }
    }
}