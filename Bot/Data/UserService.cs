using Bot.Repository;
using Models;
namespace Bot.Data;


public class UserService(IUserRepository repository)
{
    public async Task<bool> VerifyUser(long chatId, string name)
    {
        var resultAdd = await repository.SearchAndAddUser(new User()
        {
            ChatId = chatId,
            Name = name
        }
        );
        return resultAdd;
    }
}
