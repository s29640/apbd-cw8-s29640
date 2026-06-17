using APBD_cw8_s29640.Models;

namespace APBD_cw8_s29640.ViewModels
{
    public class CreateBorrowingViewModel
    {
        public int? BookId { get; set; }
        public string? BorrowerName { get; set; } = null!;
        public DateTime? BorrowedAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
    }
}
