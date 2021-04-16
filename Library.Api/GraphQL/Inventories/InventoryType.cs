using HotChocolate;
using HotChocolate.Types;
using Library.Api.Data;
using Library.Api.Data.Models;
using System.Linq;

namespace Library.Api.GraphQL.Inventories
{
    public class InventoryType : ObjectType<Inventory>
    {
        protected override void Configure(IObjectTypeDescriptor<Inventory> descriptor)
        {
            descriptor.Description("Represents all the Inventories");

            descriptor
                .Field(c => c.Id)
                .UseDbContext<GlobalAzureContext>()
                .Description("This is the Inventory");

        }

        private class Resolvers
        {
            public IQueryable<Book> GetInventoryBooks(Inventory inventory, [ScopedService] GlobalAzureContext context)
            {
                return context.Inventories.Where(i => i.Id == inventory.Id).Select(n => n.Book);
            }
        }
    }
}
