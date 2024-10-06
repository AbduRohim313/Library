
using Kutubxona.Model;
using Kutubxona.View;
using Kutubxona.EdataBase;
using Microsoft.EntityFrameworkCore;
using AppContext = Kutubxona.EdataBase.AppContext;


namespace Kutubxona.Service;

public class RegService
{

    public static HomeView.DavomHandler? DavomHandler;

    public void Register()
    {
        Console.Clear();
        Console.Write("Raqamingizni kiriting: ");
        var phoneNumber = Console.ReadLine();
        Console.Write("Maxfiy so'z kiriting: ");
        var password = Console.ReadLine();
        Console.Write("Ismingiz nima: ");
        var name = Console.ReadLine();


        if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(phoneNumber))
        {
            using (AppContext db = new AppContext())
            {
                if (null == db.Users.Include(u=>u.Books).FirstOrDefault(u=>u.PhoneNumber ==phoneNumber))
                {
                    db.Users.Add(new User
                    {
                        Password = password,
                        PhoneNumber = phoneNumber,
                        FirstName = name,
                        Books = new List<Book>()
                    });
                    db.SaveChanges();
                    Console.WriteLine("\nMufiaqatli royhatdan otdingiz!!!");
                    DavomHandler?.Invoke();
                    return;
                }
            }
        }

        Console.WriteLine("\nBundan raqamli foydalanuvchi mavjut!\nQaytadan urinib ko'ring... ");
        DavomHandler?.Invoke();
    }
}