using APBD_cw8_s29640.ViewModels;
using APBD_cw8_s29640.Models;

namespace APBD_cw8_s29640.Mappers
{
    public static class BookMapper
    {
        public static Book ToEntity(CreateBookViewModel vm)
        {
            return new Book
            {
                Title = vm.Title ?? string.Empty,
                Isbn = vm.Isbn ?? string.Empty,
                PublishedYear = vm.PublishedYear ?? 0,
                AuthorId = vm.AuthorId ?? 0
            };
        }
    }
}
