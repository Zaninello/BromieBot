namespace Bot;

public partial class BotService
{
    private static ITelegramBotClient bot;
    public async Task Start(string telegramToken)
    {
        bot = new TelegramBotClient(telegramToken);
        
        bot.StartReceiving(ProcessUpdate, ProcessError);
        
        Console.WriteLine("bot running...");
        await Task.Delay(-1);
    }
    private static async Task ProcessUpdate(ITelegramBotClient bot, Update update, CancellationToken ct)
    {
        if (await VerifyMessage(update) is false) return;

        var (chatId, text, name) = GetUserInfos(update);

        await VerifyUser(chatId, name);

        await Menu(bot, chatId, text);
    }
    private static async Task ProcessError(ITelegramBotClient bot, Exception ex, CancellationToken ct) { }
    private static (long, string, string) GetUserInfos(Update update)
    {
        var userText = update.Message!.Text;
        var userChatId = update.Message.Chat.Id;
        var userName = update.Message.Chat.FirstName;

        return (userChatId!, userText!, userName!);
    }
    private static async Task<bool> VerifyMessage(Update update)
    {
        if (update.Message is null)
            return false;
        if (string.IsNullOrEmpty(update.Message.Text))
            return false;
        return true;
    }
}