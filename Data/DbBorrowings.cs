using APBD_cw8_s29640.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_cw8_s29640.Data
{
    public class DbBorrowings
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Borrowing>(entity =>
            {
                entity.ToTable("Borrowings");

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
