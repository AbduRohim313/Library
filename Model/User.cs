namespace Kutubxona.Model;

public class User : ModelBase
{
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string? FirstName { get; set; }

    public List<Book> Books { get; set; } = new List<Book>();

}