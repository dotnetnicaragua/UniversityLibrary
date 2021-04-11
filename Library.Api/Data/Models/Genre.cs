using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Library.Api.Data.Models
{
    [Table("genres")]
    public partial class Genre
    {
        public Genre()
        {
            BookGenres = new HashSet<BookGenre>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("genre_name")]
        [StringLength(255)]
        public string GenreName { get; set; }
        [Column("created at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [InverseProperty(nameof(BookGenre.Genre))]
        public virtual ICollection<BookGenre> BookGenres { get; set; }
    }
}
