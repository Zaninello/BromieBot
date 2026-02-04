using Bot.Repository.User;
using Models;
using User = Models.User;

namespace Bot.Data;


public class UserService(IUserRepository repository)
{
    public async Task<bool> VerifyUser(long chatId)
        => await repository.SearchUser(chatId);
    
    public async Task AddUser(long chatId, string name)
        => await repository.AddUser(new User()
        {
            ChatId = chatId,
            Name = name
        });
}
