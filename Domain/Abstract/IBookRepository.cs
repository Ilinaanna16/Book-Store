﻿using System;
using System.Collections.Generic;
using Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IBookRepository
    {
        IEnumerable<Book> Books { get; }
    }
}
