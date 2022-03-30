using Domain.Concrete;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models.Repository
{
    public class Repository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Book> Books
        {
            get { return context.Books; }
        }

    }
}