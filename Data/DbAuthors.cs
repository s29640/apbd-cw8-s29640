using APBD_cw8_s29640.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_cw8_s29640.Data
{
    public class DbAuthors
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Authors");

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
        }
    }
}
