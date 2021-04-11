using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Library.Api.Data.Models
{
    [Table("inventory_movements")]
    public partial class InventoryMovement
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("inventory_id")]
        public int InventoryId { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("movementType")]
        public bool MovementType { get; set; }
        [Column("movement_date", TypeName = "datetime")]
        public DateTime MovementDate { get; set; }

        [ForeignKey(nameof(InventoryId))]
        [InverseProperty("InventoryMovements")]
        public virtual Inventory Inventory { get; set; }
    }
}
