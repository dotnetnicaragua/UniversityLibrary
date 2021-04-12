using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Library.Api.Data;
using Library.Api.Data.Models;

namespace Library.Api.GraphQL.Books
{
    public class BookType : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor.Description("Respresents all the books");
            //descriptor
            //    .Field(p => p.Id).Ignore();

            descriptor
                .Field(c => c.Id)
                //.ResolveWith<Resolvers>(c => c.GetBook(default!, default!))
                .UseDbContext<LibraryDemoContext>()
                .Description("This is the Book");

        }


        private class Resolvers
        {
            public IQueryable<Book> GetBook(Book book, [ScopedService] LibraryDemoContext context)
            {
                return (IQueryable<Book>)context.Books.Select(p => p.Id == book.Id);
            }
        }
    }
}
