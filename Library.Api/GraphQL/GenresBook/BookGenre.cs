using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Library.Api.Data.Models;
using Library.Api.Data;
using HotChocolate.Types;
using HotChocolate;

namespace Library.Api.GraphQL.GenresBook
{
    public class BookGenreType : ObjectType<BookGenre>
    {
        protected override void Configure(IObjectTypeDescriptor<BookGenre> descriptor)
        {
            descriptor.Description("Respresents all the Genre");

            //For ignoring a field
            //descriptor
            //    .Field(p => p.CreatedAt).Ignore();

            descriptor
                .Field(c => c.Id)

                .UseDbContext<GlobalAzureContext>()
                .Description("This is the BookGenre");

        }

        private class Resolvers
        {
            public IQueryable<Genre> GetBooksGenre(Genre genre, [ScopedService] GlobalAzureContext context)
            {
                return context.BookGenres.Where(p => p.GenreId == genre.Id).Select(n => n.Genre);
            }
        }

    }
}
