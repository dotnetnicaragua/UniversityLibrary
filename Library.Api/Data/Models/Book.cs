using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Library.Api.Data.Models
{
    [Table("books")]
    [Index(nameof(Isbn), Name = "UQ__books__99F9D0A475A2E225", IsUnique = true)]
    public partial class Book
    {
        public Book()
        {
            BookAuthors = new HashSet<BookAuthor>();
            BookGenres = new HashSet<BookGenre>();
            Inventories = new HashSet<Inventory>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(30)]
        public string Category { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? Price { get; set; }
        [Required]
        [Column("isbn")]
        [StringLength(255)]
        public string Isbn { get; set; }
        [Column("publish_date", TypeName = "date")]
        public DateTime PublishDate { get; set; }
        [Column("created at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [InverseProperty(nameof(BookAuthor.Book))]
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
        [InverseProperty(nameof(BookGenre.Book))]
        public virtual ICollection<BookGenre> BookGenres { get; set; }
        [InverseProperty(nameof(Inventory.Book))]
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
