using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class BooksController : Controller
    {
        private IBookRepository repository;
        public int pageSize = 4;

        public BooksController(IBookRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string Category, int page = 1)
        {
            BooksListViewModel model = new BooksListViewModel
            {
                Books = repository.Books
                .Where(b => Category == null || b.Category == Category)
                .OrderBy(book => book.BookId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = Category == null ? 
                        repository.Books.Count() : 
                        repository.Books.Where(book => book.Category == Category).Count()
                },
                CurrentCategory = Category
            };
            
            return View(model);
        }
        public FileContentResult GetImage(int bookId)
        {
            Book book = repository.Books
                .FirstOrDefault(g => g.BookId == bookId);

            if (book != null)
            {
                return File(book.ImageData, book.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}