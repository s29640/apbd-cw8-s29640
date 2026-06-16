using APBD_cw8_s29640.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_cw8_s29640.Data
{
    public class DbSeed
    {
        public static void Data(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "Stanisław", LastName = "Lem" },
                new Author { Id = 2, FirstName = "Olga", LastName = "Tokarczuk" },
                new Author { Id = 3, FirstName = "Andrzej", LastName = "Sapkowski" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book {
                    Id = 1,
                    Title = "Solaris",
                    Isbn = "9788374802550",
                    PublishedYear = 1961,
                    AuthorId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "Bajki robotów",
                    Isbn = "9788374802567",
                    PublishedYear = 1964,
                    AuthorId = 1
                },
                new Book
                {
                    Id = 3,
                    Title = "Prowadź swój pług przez kości umarłych",
                    Isbn = "9788308066980",
                    PublishedYear = 2009,
                    AuthorId = 2
                },
                new Book
                {
                    Id = 4,
                    Title = "Ostatnie życzenie",
                    Isbn = "9788375780635",
                    PublishedYear = 1993,
                    AuthorId = 3
                },
                new Book
                {
                    Id = 5,
                    Title = "Miecz przeznaczenia",
                    Isbn = "9788375780642",
                    PublishedYear = 1992,
                    AuthorId = 3
                }
            );
        }
    }
}
