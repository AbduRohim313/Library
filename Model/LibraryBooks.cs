using System.ComponentModel.DataAnnotations;

namespace Kutubxona.Model;

public class LibraryBooks
{
    [Key]
    public int LibraryBookId { get; set; }
    public string Name { get; set; }
}