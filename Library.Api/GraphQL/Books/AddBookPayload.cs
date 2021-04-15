using Library.Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.GraphQL.Books
{
    public record AddBookPayload(Book book);
}
