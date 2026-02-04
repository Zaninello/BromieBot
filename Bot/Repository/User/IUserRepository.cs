namespace Bot.Repository.User;

public interface IUserRepository
{
    Task AddUser(Models.User user);
    Task<bool> SearchUser(long chatId);
}
