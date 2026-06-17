using APBD_cw8_s29640.Models;
using APBD_cw8_s29640.ViewModels;

namespace APBD_cw8_s29640.Mappers
{
    public static class BorrowingMapper
    {
        public static Borrowing ToEntity(CreateBorrowingViewModel vm)
        {
            return new Borrowing
            {
                BookId = vm.BookId ?? 0,
                BorrowerName = vm.BorrowerName ?? string.Empty,
                BorrowedAt = vm.BorrowedAt ?? DateTime.Now,
                ReturnedAt = vm.ReturnedAt
            };
        }
    }
}
