using APBD_cw8_s29640.Models;

namespace APBD_cw8_s29640.Services
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAllAuthorsAsync();
    }
}
