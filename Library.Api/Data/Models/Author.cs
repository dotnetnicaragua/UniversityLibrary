using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Library.Api.Data.Models
{
    [Table("authors")]
    public partial class Author
    {
        public Author()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("first_name")]
        [StringLength(255)]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name")]
        [StringLength(255)]
        public string LastName { get; set; }
        [Column("created at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [InverseProperty(nameof(BookAuthor.Author))]
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
