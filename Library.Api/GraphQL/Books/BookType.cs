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

            //For ignoring a field
            descriptor
                .Field(p => p.CreatedAt).Ignore();

            descriptor
                .Field(c => c.Id)
                //.ResolveWith<Resolvers>(c => c.GetBookAuthors(default!, default!))
                .UseDbContext<GlobalAzureContext>()
                .Description("This is the Book Author");

        }

        private class Resolvers
        {
            public IQueryable<Author> GetBookAuthors(Book book, [ScopedService] GlobalAzureContext context)
            {
                return context.BookAuthors.Where(p => p.BookId == book.Id).Select(n => n.Author);
            }
        }
    }
}
