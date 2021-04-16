using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Library.Api.Data.Models;

namespace Library.Api.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Book OnBookAdded([EventMessage] Book book)
        {
            return book;
        }

        [Subscribe]
        [Topic]
        public Genre OnPlatformAdded([EventMessage] Genre genre)
        {
            return genre;
        }


        [Subscribe]
        [Topic]
        public BookGenre OnPlatformAdded([EventMessage] BookGenre bookGenre)
        {
            return bookGenre;
        }

    }
}
