using HotChocolate.Types;
using HotChocolate;
using Library.Api.Data.Models;
using Library.Api.Data;
using System.Linq;

namespace Library.Api.GraphQL.Genres
{
    public class GenreType : ObjectType<Genre>
    {
        protected override void Configure(IObjectTypeDescriptor<Genre > descriptor)
        {
            descriptor.Description("Respresents all the Genre");

            //For ignoring a field
            descriptor
                .Field(p => p.CreatedAt).Ignore();

            descriptor
                .Field(c => c.Id)
                
                .UseDbContext<GlobalAzureContext>()
                .Description("This is the Genre");

        }

        private class Resolvers
        {
            public IQueryable<Genre> GetGenre(Genre genre, [ScopedService] GlobalAzureContext context)
            {
                return context.BookGenres.Where(p => p.GenreId  == genre.Id).Select(n => n.Genre );
            }
        }

    }
}
