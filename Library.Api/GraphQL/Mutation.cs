using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Library.Api.Data;
using Library.Api.Data.Models;
using Library.Api.GraphQL.Books;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;


namespace Library.Api.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(GlobalAzureContext))]
        public async Task<AddBookPayload> AddPlatformAsync(
            AddBookInput input,
            [ScopedService] GlobalAzureContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken
            )
        {
            var book = new Book
            {
                Title = input.book.Title,
                Category = "",
                Price = 0,
                Isbn = "",
                PublishDate = System.DateTime.Now,
                CreatedAt = System.DateTime.Now
            };

            context.Books.Add(book);
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), book, cancellationToken);

            return new AddBookPayload(book);
        }
    }
}
