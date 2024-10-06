using Kutubxona.Model;
using Kutubxona.Service;
using Kutubxona.EdataBase;
using AppContext = Kutubxona.EdataBase.AppContext;

namespace Kutubxona.View;

public class HomeView
{
    private LogView _logView;
    private RegView _regView;
    private OstonaView _ostonaView;
    private ProfilView _profilView;

    public delegate void method(User user);

    public delegate void DavomHandler();

    private (int left, int top) getWindowSize() => (Console.WindowWidth, Console.WindowHeight);


    public HomeView(LogView logView, RegView regView, OstonaView ostonaView, ProfilView profilView)
    {
        _logView = logView;
        _regView = regView;
        _ostonaView = ostonaView;
        _profilView = profilView;
        LogService.DavomHandler = DavomEtiw;
        ProfilView.DavomHandler = DavomEtiw;
        ProfilService.DavomHandler = DavomEtiw;
        OstonaView.DavomHandler = DavomEtiw;
        OstonaService.DavomHandler = DavomEtiw;
        RegService.DavomHandler = DavomEtiw;
    }
    public void Bismillah()
    {
        Console.Clear();
        var size = (Console.WindowWidth, Console.WindowHeight);
        Console.SetCursorPosition((size.Item1 - 9) / 2, size.Item2 / 2);
        Console.WriteLine("Bismillah");
        Console.CursorVisible = false;
        Console.ReadKey();

        KutubxonagaKiriw();
    }

    void DavomEtiw()
    {
        Console.Write("\nDavom etiw uchun istalgan tugmani bosing...");
        Console.ReadKey();
    }

    void KutubxonagaKiriw()
    {
        // dbLoader();
        Console.Clear();
        Console.WriteLine("Assalamu A'laykum kutubxonaga huw kelibsiz!!!\n");
        Console.WriteLine("1. Kiriw");
        Console.WriteLine("2. Royhatdan o'tiw");
        Console.WriteLine("0. Chiqiw\n");
        Console.Write(">>> ");

        switch (Console.ReadLine()?.Trim())
        {
            case "1":
                _logView.GetService().Login();
                KutubxonagaKiriw();
                return;
            case "2":
                _regView.GetService().Register();
                KutubxonagaKiriw();
                return;
            case "0":
                return;
            default:
                Console.WriteLine("Bunday amal yoq");
                DavomEtiw();
                KutubxonagaKiriw();
                return;
        }
    }

    private void dbLoader()
    {
        using (AppContext db = new AppContext())
        {
            string[] books = new string[]
            {
                "Sariq", "Din nasihatdur", "Hadis va Hayot 13-jus", "Baxtiyor oila", "Ibodat islomiya", "Maa'lim saniy",
                "Adab", "Fikh ul akbar", "Mufatta", "as sahihul Buhoriy", "Hadis va Hayot Muqaddima 1 -jus"
            };
            // var kitoblar = db.Books.ToList();
            // db.Books.RemoveRange(kitoblar);


            foreach (var variable in books)
                db.LibraryBooks.Add(new LibraryBooks()
                {
                    Name = variable.Trim()
                });

            db.SaveChanges();
        }
    }
}