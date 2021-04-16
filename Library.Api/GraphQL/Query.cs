using HotChocolate;
using HotChocolate.Data;
using Library.Api.Data;
using Library.Api.Data.Models;
using System.Linq;

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

        [UseDbContext(typeof(GlobalAzureContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Inventory> GetInventory([ScopedService] GlobalAzureContext context)
        {
            return context.Inventories;
        }

        [UseDbContext(typeof(GlobalAzureContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<InventoryMovement> GetInventoryMovements([ScopedService] GlobalAzureContext context)
        {
            return context.InventoryMovements;
        }


        [UseDbContext(typeof(GlobalAzureContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Genre> GetGenre([ScopedService] GlobalAzureContext context)
        {
            return context.Genres;
        }

        [UseDbContext(typeof(GlobalAzureContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<BookGenre> GetBookGenre([ScopedService] GlobalAzureContext context)
        {
            return context.BookGenres;
        }


        //TODO: Add method for Getting data from other entities

    }
}
