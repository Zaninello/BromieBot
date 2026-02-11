using Models;
using DataBase;
using Microsoft.EntityFrameworkCore;

namespace BromieBot.API;

public class RepositoryUserApi(TelegramBotContext context)
{
    public async Task<bool> VerificarUsuario(long chatId)
    {
        return await context.Users.AnyAsync(x => x.ChatId == chatId);
    }

    public async Task AdicionarUsuario(User usuario)
    {
        await context.AddAsync(usuario);
        await context.SaveChangesAsync();
    }
}
