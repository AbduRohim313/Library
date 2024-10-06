using Kutubxona.EdataBase;
using AppContext = System.AppContext;

namespace Kutubxona.Model;

public class Book
{
    public int BookId { get; set; }
    public string Name { get; set; }
    public int? UserId { get; set; }
    public User? User { get; set; }

    // public Book()
    // {
    //     // Id = GetId();
    // }   
}