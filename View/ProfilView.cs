using Kutubxona.Model;
using Kutubxona.Service;

namespace Kutubxona.View;

public class ProfilView
{
    private ProfilService _profilService;
    public static HomeView.DavomHandler? DavomHandler;

    public ProfilView(ProfilService profilService)
    {
        _profilService = profilService;
        OstonaView.SilkaSettings = Settings;
    }

    public void Settings(User user)
    {
        Console.Clear();
        Console.WriteLine("\n1. Telefon raqamni o'zgartiriw");
        Console.WriteLine("2. Maxfiy so'zni o'zgartiriw");
        Console.WriteLine("3. Ismni o'zgartiriw");
        Console.WriteLine("0. Chiqiw");
        Console.Write(">>>  ");

        switch (Console.ReadLine())
        {
            case "1":
                _profilService.ChangePhoneNumber(user);
                break;
            case "2":
                _profilService.ChangePassword(user);
                break;
            case "3":
                _profilService.IsmOzgartiriw(user);
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Bunday amal yoq");
                DavomHandler?.Invoke();
                Settings(user: user);
                return;
        }
    }
}