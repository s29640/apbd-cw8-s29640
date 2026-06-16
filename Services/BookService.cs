using APBD_cw8_s29640.Data;
using APBD_cw8_s29640.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_cw8_s29640.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _context;

        public BookService(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books.Include(b => b.Author).OrderBy(b => b.Title).ToListAsync();
        }

        public async Task<Book?> GetBookDetailsAsync(int id)
        {
            return await _context.Books
                                 .Include(b => b.Author)
                                 .Include(b => b.Borrowings)
                                 .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task CreateBookAsync(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new InvalidOperationException("Tytuł książki jest wymagany.");

            if (string.IsNullOrWhiteSpace(book.Isbn))
                throw new InvalidOperationException("ISBN jest wymagany.");

            if (book.PublishedYear <= 1900)
                throw new InvalidOperationException("Rok wydania musi być większy niż 1900.");

            var authorExists = await _context.Authors.AnyAsync(a => a.Id == book.AuthorId);

            if (!authorExists)
                throw new InvalidOperationException("Wybrany autor nie istnieje.");

            _context.Books.Add(book);

            await _context.SaveChangesAsync();
        }
    }
}