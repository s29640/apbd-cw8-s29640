using APBD_cw8_s29640.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_cw8_s29640.Data
{
    public class DbBooks
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Books");

                entity.HasKey(b => b.Id);

                entity.Property(b => b.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(b => b.Isbn)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasIndex(b => b.Isbn)
                    .IsUnique();

                entity.Property(b => b.PublishedYear)
                    .IsRequired();

                entity.ToTable(t =>
                    t.HasCheckConstraint(
                        "CK_Books_PublishedYear",
                        "[PublishedYear] > 1900"
                    )
                );

                entity.HasMany(b => b.Borrowings)
                    .WithOne(br => br.Book)
                    .HasForeignKey(br => br.BookId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
