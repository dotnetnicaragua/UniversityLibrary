using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Library.Api.Data.Models
{
    [Table("book_genres")]
    public partial class BookGenre
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("book_id")]
        public int BookId { get; set; }
        [Column("genre_id")]
        public int GenreId { get; set; }

        [ForeignKey(nameof(BookId))]
        [InverseProperty("BookGenres")]
        public virtual Book Book { get; set; }
        [ForeignKey(nameof(GenreId))]
        [InverseProperty("BookGenres")]
        public virtual Genre Genre { get; set; }
    }
}
