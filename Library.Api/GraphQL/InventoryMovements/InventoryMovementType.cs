using HotChocolate;
using HotChocolate.Types;
using Library.Api.Data;
using Library.Api.Data.Models;
using System.Linq;

namespace Library.Api.GraphQL.InventoryMovements
{
    public class InventoryMovementType : ObjectType<InventoryMovement>
    {
        protected override void Configure(IObjectTypeDescriptor<InventoryMovement> descriptor)
        {
            descriptor.Description("Represents all the movements of inventories");

            descriptor
                .Field(c => c.Id)
                .UseDbContext<GlobalAzureContext>()
                .Description("These are the Inventory's movements");

        }

        private class Resolvers
        {
            public IQueryable<Inventory> GetInventoriesMovements(Inventory inventory, [ScopedService] GlobalAzureContext context)
            {
                return context.InventoryMovements.Where(i => i.InventoryId == inventory.Id).Select(n => n.Inventory);
            }
        }
    }
}
