using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Api.Data.Models;

namespace Library.Api.GraphQL.Books
{
    public record AddBookInput(BookDto book);

    public class BookDto
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }
        public string Isbn { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
