namespace APBD_cw8_s29640.Models;

public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public ICollection<Book> Books { get; set; } = new List<Book>();
}