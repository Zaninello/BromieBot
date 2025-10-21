using Telegram.Bot;
using Telegram.Bot.Types;
using Microsoft.EntityFrameworkCore.Design;
namespace BromieBot;

internal class Program
{
    static void Main(string[] args)
    {
        var bot = new TelegramBotClient("");
        bot.StartReceiving(ProcessUpdate, ProcessError);
    }

    public static void ProcessUpdate(ITelegramBotClient bot, Update update, CancellationToken ct)
    {
        var text = update.Message.Text;
        var chatId = update.Message.Chat.Id;

        var comando = text.Split(" ")[0].ToLower();
        var status = text.Split(" ")[2].ToLower();

        if(status == "concluido")

        switch (comando)
        {
            case "/add":
                
                break;

            case "/remove":
                
                break;

            case "/edit":
                break;

            case "/show":
                break;
        }
    }

    public static void ProcessError(ITelegramBotClient bot, Exception ex, CancellationToken ct)
    { 
        
    }
}
