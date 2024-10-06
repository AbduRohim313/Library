using Kutubxona.Model;
using Kutubxona.View;
using Kutubxona.EdataBase;
using Microsoft.EntityFrameworkCore;
using AppContext = Kutubxona.EdataBase.AppContext;

namespace Kutubxona.Service;

public class OstonaService
{
    public static HomeView.DavomHandler? DavomHandler;

    public void KitobQaytiriw(User user)
    {
        Console.Clear();
        Kitobblar(user);
        Console.Write("\nQaysi kitobni qaytarmoqchisiz ID: ");
        var option = Console.ReadLine();
        if (!string.IsNullOrEmpty(option))
        {
            // int id = Convert.ToInt32(option.Trim()); //                                         MAWITTA HATO CHIQIWI MUNKUN
            if (int.TryParse(option?.Trim(), out var id))
            {
                using (AppContext db = new AppContext())
                {
                    var kitob = db.Books.FirstOrDefault(b => b.BookId == id);
                    if (kitob != null)
                    {
                        db.LibraryBooks.Add(new LibraryBooks()
                        {
                            Name = kitob.Name
                        }); // EQUALS or Phone-Number
                        db.Books.Remove(kitob);
                        db.SaveChanges();
                        Console.WriteLine($"\n{kitob.Name} nomli kitob kutubxonaga qaytarildi");
                        DavomHandler?.Invoke();
                        return;
                    }
                }
            }
        }

        Console.WriteLine("Sida bunday kitob yoq");

        // LogService.method
        DavomHandler?.Invoke();
    }

    public void Kitobblar(User user)
    {
        using (AppContext db = new AppContext())
        {
            Console.Clear();
            Console.WriteLine("\nSizni kitoblaringiz: \n");
            var list = db.Books.Where(b => b.UserId == user.Id);
            foreach (var book in list)
            {
                Console.WriteLine($"ID book: {book.BookId}\n\t{book.Name}");
            }
        }
    }

    public void ToplamniKoriw(User user)
    {
        Kitobblar(user);
        DavomHandler?.Invoke();
    }

    public void KitobOliw(int userId)
    {
        Console.Clear();
        Console.WriteLine("Kitoblar: \n");
        using (AppContext db = new AppContext())
        {
            foreach (var book in db.LibraryBooks.ToList())
            {
                Console.WriteLine($"id = {book.LibraryBookId} " + book.Name);
            }

            Console.Write("\nOlmoqchi bo'lgan Kitob id ingizni: ");
            var option = Console.ReadLine();
            if (!string.IsNullOrEmpty(option))
            {
                // int id = Convert.ToInt32(option?.Trim());
                if (int.TryParse(option?.Trim(), out var id))
                {
                    var kitob = db.LibraryBooks.FirstOrDefault(b => b.LibraryBookId == id);
                    if (kitob != null)
                    {
                        var user = db.Users.FirstOrDefault(u => u.Id == userId);
                        user?.Books.Add(new Book()
                        {
                            Name = kitob.Name,
                            User = user
                        });
                        db.LibraryBooks.Remove(kitob);
                        // kitob.User = user;
                        // var kitoblar = db.Books.Include(b => b.User).ToList();
                        // // var odamlar = db.Users.ToList();
                        // var kitob1 = kitoblar.Find(u => u.User?.PhoneNumber == user.PhoneNumber);
                        // kitob1?.User.Books.Add(kitob);
                        // db.Books.Remove(kitob);
                        // db.Books.Update(kitob);
                        // db.Users.Update(user);
                        Console.WriteLine($"\n{kitob.Name} nomli kitob sizga topwirildi");
                        db.SaveChanges();
                        DavomHandler?.Invoke();
                        return;
                    }
                }
            }
        }


        Console.WriteLine("Bunday kitob yoq");

        DavomHandler?.Invoke();
    }
}