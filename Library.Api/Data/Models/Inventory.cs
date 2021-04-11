using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Library.Api.Data.Models
{
    [Table("inventory")]
    public partial class Inventory
    {
        public Inventory()
        {
            InventoryMovements = new HashSet<InventoryMovement>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("book_id")]
        public int BookId { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("max_quantity")]
        public int MaxQuantity { get; set; }
        [Column("min_quantity")]
        public int MinQuantity { get; set; }

        [ForeignKey(nameof(BookId))]
        [InverseProperty("Inventories")]
        public virtual Book Book { get; set; }
        [InverseProperty(nameof(InventoryMovement.Inventory))]
        public virtual ICollection<InventoryMovement> InventoryMovements { get; set; }
    }
}
