
using Kutubxona.EdataBase;
using Kutubxona.Model;
using Kutubxona.View;
using AppContext = Kutubxona.EdataBase.AppContext;

namespace Kutubxona.Service;

public class ProfilService
{
    public static HomeView.DavomHandler? DavomHandler;


    public void ChangePhoneNumber(User user)
    {
        Console.Clear();
        Console.Write("\nYengi raqam: ");
        var phoneNumber = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(phoneNumber))
        {
            using (var db = new AppContext())
            {
                db.Users.Update(user);
                user.PhoneNumber = phoneNumber;
                db.SaveChanges();
                Console.WriteLine("Mufiyaqatli o'rnatildi");
            }
        }
        else
            Console.WriteLine("O'rnatilmadi!!!");

        DavomHandler?.Invoke();
    }

    public void ChangePassword(User user)
    {
        Console.Clear();
        Console.Write("\nYengi maxfiy so'z: ");
        var password = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(password))
        {
            using (var db = new AppContext())
            {
                db.Users.Update(user);
                user.Password = password;
                db.SaveChanges();
                Console.WriteLine("Mufiyaqatli o'rnatildi");
            }
        }
        else
            Console.WriteLine("O'rnatilmadi!!!");

        DavomHandler?.Invoke();
    }

    public void IsmOzgartiriw(User user)
    {
        Console.Clear();
        Console.Write("\nYengi ismiz: ");
        var name = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(name))
        {
            using (var db = new AppContext())
            {
                db.Users.Update(user);
                user.FirstName = name;
                db.SaveChanges();
                Console.WriteLine("Mufiyaqatli o'rnatildi");
            }
        }
        else
            Console.WriteLine("O'rnatilmadi!!!");

        DavomHandler?.Invoke();
    }
}