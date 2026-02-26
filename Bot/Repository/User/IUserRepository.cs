using Models;

namespace Bot.Repository;

public interface IUserRepository
{
    Task<bool> SearchAndAddUser(User user);
}
