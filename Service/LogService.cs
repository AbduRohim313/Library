
using Kutubxona.Model;
using Kutubxona.View;
using Kutubxona.EdataBase;
using Microsoft.EntityFrameworkCore;
using AppContext = Kutubxona.EdataBase.AppContext;

namespace Kutubxona.Service;

public class LogService
{
    public static HomeView.method? userSend;
    public static HomeView.DavomHandler? DavomHandler;


    public void Login()
    {
        Console.Clear();
        Console.Write("Raqamingizni kiriting: ");
        var phoneNumber = Console.ReadLine();
        Console.Write("Maxfiy so'z kiriting: ");
        var password = Console.ReadLine();
        using (AppContext db = new AppContext())
        {
            var searchUser = db.Users.Include(u=>u.Books).FirstOrDefault(u=>u.PhoneNumber==phoneNumber);
            if (searchUser?.Password == password)
            {
                userSend?.Invoke(searchUser!); // ostona
                // Ostona(searchUser);
                return;
            }
        }

        Console.WriteLine("\nBundan foydalanuvchi topilmadi");
        DavomHandler?.Invoke();
    }
}