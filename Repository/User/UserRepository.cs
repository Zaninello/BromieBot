using DataBase;
using Models;

namespace Repository;

public class UserRepository : IUserRepository
{
    private readonly TelegramBotContext _conexao;

    public UserRepository() => _conexao = new TelegramBotContext();
    
    public void AddUser(User user)
    {
        _conexao.Add(user);
        _conexao.SaveChanges();
    }

    public bool SearchUser(long chatId)
    {
        return _conexao.Users.Any(u => u.ChatId == chatId);
    }
}
