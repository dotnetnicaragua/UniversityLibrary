using System;
using System.Collections.Generic;
using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using Library.Api.Data;
using Library.Api.Data.Models;

namespace Library.Api.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(LibraryDemoContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> GetBook([ScopedService] LibraryDemoContext context)
        {
            return context.Books;
        }
    }
}
