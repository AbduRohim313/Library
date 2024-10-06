using Kutubxona.Model;
using Kutubxona.Service;
using Kutubxona.View;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Kutubxona;

class Kutubxona
{


    private static LogService _logService = new LogService();
    private static RegService _regService = new RegService();
    private static OstonaService _ostonaService = new OstonaService();
    private static ProfilService _profilService = new ProfilService();

    private static RegView _regView = new RegView(_regService);
    private static LogView _logView = new LogView(_logService);
    private static OstonaView _ostonaView = new OstonaView(_ostonaService);
    private static ProfilView _profilView = new ProfilView(_profilService);
    private HomeView _homeView = new HomeView(_logView, _regView, _ostonaView, _profilView);

    public static async Task Main(string[] args)
    {
        using var cts = new CancellationTokenSource();
        var bot = new TelegramBotClient($"{Settings.tokken}");
        Kutubxona kutubxona = new Kutubxona();
        kutubxona._homeView.Bismillah();
        bot.StartReceiving(HandleUpdate, async (bot, ex, ct) => Console.WriteLine(ex));

        var me = await bot.GetMeAsync();
        Console.WriteLine($"@{me.Username} is running... Press Enter to terminate");
        Console.ReadLine();
        cts.Cancel(); // stop the bot
    }

// method that handle updates coming for the bot:
    public static async Task HandleUpdate(ITelegramBotClient bot, Update update, CancellationToken ct)
    {
        if (update.Message is null) return; // we want only updates about new Message
        if (update.Message.Text is null) return; // we want only updates about new Text Message
        var msg = update.Message;
        var chatId = msg.Chat;
        Kutubxona kutubxona = new Kutubxona();
        kutubxona._homeView.Bismillah();
        Console.WriteLine($"{msg.Chat.FirstName} sended '{msg.Text}'");

        var message = await bot.SendTextMessageAsync(chatId, $"{msg.Text}");
    }
}