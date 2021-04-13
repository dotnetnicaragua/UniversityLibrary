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
        [UseDbContext(typeof(GlobalAzureContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> GetBook([ScopedService] GlobalAzureContext context)
        {
            return context.Books;
        }

        //TODO: Add method for Getting data from other entities

    }
}
