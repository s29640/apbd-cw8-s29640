namespace APBD_cw8_s29640.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Isbn { get; set; } = null!;
    public int PublishedYear { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;
    public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
}