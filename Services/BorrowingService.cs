using APBD_cw8_s29640.Data;
using APBD_cw8_s29640.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_cw8_s29640.Services;

public class BorrowingService : IBorrowingService
{
    private readonly LibraryDbContext _context;

    public BorrowingService(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task CreateBorrowingAsync(Borrowing borrowing)
    {
        var bookExists = await _context.Books.AnyAsync(b => b.Id == borrowing.BookId);

        if (!bookExists)
            throw new InvalidOperationException("Nie można dodać wypożyczenia dla książki, która nie istnieje.");

        if (string.IsNullOrWhiteSpace(borrowing.BorrowerName))
            throw new InvalidOperationException("Imię i nazwisko wypożyczającego jest wymagane.");

        if (borrowing.BorrowedAt == default)
            borrowing.BorrowedAt = DateTime.Now;

        _context.Borrowings.Add(borrowing);
        await _context.SaveChangesAsync();
    }
}