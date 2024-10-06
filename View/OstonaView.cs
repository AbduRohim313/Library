using Kutubxona.Model;
using Kutubxona.Service;

namespace Kutubxona.View;

public class OstonaView
{
    private OstonaService _ostonaService;
    public static HomeView.DavomHandler? DavomHandler;
    public static HomeView.method? Silka;
    public static HomeView.method? SilkaSettings; //profil view

    public OstonaView(OstonaService ostonaService)
    {
        _ostonaService = ostonaService;
        LogService.userSend = Ostona;
    }

    public void Ostona(User user)
    {
        Console.Clear();
        Console.WriteLine($"Xush kelibsiz {user.FirstName}");

        Console.WriteLine("\n1. Kitob Ob ketiw");
        Console.WriteLine("2. Kitobni qaytarib beriw");
        Console.WriteLine("3. Sozlamalar");
        Console.WriteLine("4. Tomlamimni koriw");
        Console.WriteLine("0. Chiqiw");
        Console.Write("\n>>> ");
        switch (Console.ReadLine()?.Trim())
        {
            case "1":
                _ostonaService.KitobOliw(user.Id);
                Ostona(user);
                return;
            case "2":
                _ostonaService.KitobQaytiriw(user);
                Ostona(user);
                return;
            case "3":
                SilkaSettings?.Invoke(user);
                Ostona(user);
                return;
            case "4":
                _ostonaService.ToplamniKoriw(user);
                Ostona(user);
                return;
            case "0": return;
            default:
                Console.WriteLine("Bunday amal yoq");
                DavomHandler?.Invoke();
                Ostona(user);
                return;
        }
    }
}