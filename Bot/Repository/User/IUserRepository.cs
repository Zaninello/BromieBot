using Models;

namespace Bot.Repository;

public interface IUserRepository
{
    Task<bool> AddUser(User user);
    Task<bool> SearchUser(long chatId);
}
