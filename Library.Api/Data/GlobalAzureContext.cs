using System;
using Library.Api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Library.Api.Data
{
    public partial class GlobalAzureContext : DbContext
    {
        public GlobalAzureContext(DbContextOptions<GlobalAzureContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookAuthor> BookAuthors { get; set; }
        public virtual DbSet<BookGenre> BookGenres { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<InventoryMovement> InventoryMovements { get; set; }
        public virtual DbSet<VRandomNumber> VRandomNumbers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-5FL37A7\\MSSQLSERVER2019; user=sa; password=Pastor1987; Initial Catalog=GlobalAzure; Integrated Security=True; ConnectRetryCount=0");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Category).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<BookAuthor>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("authors_to_books");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_to_authors");
            });

            modelBuilder.Entity<BookGenre>(entity =>
            {
                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookGenres)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_to_genres");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.BookGenres)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("genres_to_books");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("inventory_books");
            });

            modelBuilder.Entity<InventoryMovement>(entity =>
            {
                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.InventoryMovements)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("inv_movements");
            });

            modelBuilder.Entity<VRandomNumber>(entity =>
            {
                entity.ToView("vRandomNumber");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
