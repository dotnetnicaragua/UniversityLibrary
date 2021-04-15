using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Api.Data.Models;

namespace Library.Api.GraphQL.Books
{
    public record AddBookInput(Book book);
}
