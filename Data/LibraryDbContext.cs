using APBD_cw8_s29640.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_cw8_s29640.Data
{
    public class LibraryDbContext :DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(a => a.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasMany(a => a.Books)
                    .WithOne(b => b.Author)
                    .HasForeignKey(b => b.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.Id);

                entity.Property(b => b.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(b => b.Isbn)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(b => b.PublishedYear)
                    .IsRequired();

                entity.HasCheckConstraint(
                    "CK_Books_PublishedYear",
                    "[PublishedYear] > 1900"
                );

                entity.HasMany(b => b.Borrowings)
                    .WithOne(br => br.Book)
                    .HasForeignKey(br => br.BookId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Borrowing>(entity =>
            {
                entity.HasKey(br => br.Id);

                entity.Property(br => br.BorrowerName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(br => br.BorrowedAt)
                    .IsRequired();

                entity.Property(br => br.ReturnedAt)
                    .IsRequired(false);
            });
        }
    }
}
