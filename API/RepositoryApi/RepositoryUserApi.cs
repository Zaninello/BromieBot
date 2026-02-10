using Models;
using DataBase; 

namespace BromieBot.API;

public class RepositoryUserApi(TelegramBotContext context)
{
    public bool VerificarUsuario(long chatId)
    {
        return context.Users.Any(x => x.ChatId == chatId);
    }
}
