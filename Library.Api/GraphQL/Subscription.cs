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
        public Book OnPlatformAdded([EventMessage] Book book)
        {
            return book;
        }
    }
}
