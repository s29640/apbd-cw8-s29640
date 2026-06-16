using APBD_cw8_s29640.Models;

namespace APBD_cw8_s29640.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book?> GetBookDetailsAsync(int id);
        Task CreateBookAsync(Book book);
    }
}
