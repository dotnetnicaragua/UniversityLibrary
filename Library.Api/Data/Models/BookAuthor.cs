using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Library.Api.Data.Models
{
    [Table("book_authors")]
    public partial class BookAuthor
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("book_id")]
        public int BookId { get; set; }
        [Column("author_id")]
        public int AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        [InverseProperty("BookAuthors")]
        public virtual Author Author { get; set; }
        [ForeignKey(nameof(BookId))]
        [InverseProperty("BookAuthors")]
        public virtual Book Book { get; set; }
    }
}
