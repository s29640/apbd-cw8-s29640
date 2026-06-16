namespace APBD_cw8_s29640.Models;

public class Borrowing
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public string BorrowerName { get; set; } = null!;
    public DateTime BorrowedAt { get; set; }
    public DateTime? ReturnedAt { get; set; }
    public Book Book { get; set; } = null!;
}