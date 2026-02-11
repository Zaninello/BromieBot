using System.ComponentModel.DataAnnotations;
using Models;

namespace Bot.Repository;

public class UserRepository : IUserRepository
{
    private HttpClient client = new HttpClient();
    string url = "http://localhost:3000/api/usuario/";

    public async Task<bool> AddUser(User user)
    {
     return true; 
    }

    public async Task<bool> SearchUser(long chatId)
    {
        var rersult = await client.GetAsync($"{url + chatId}");
        return rersult.IsSuccessStatusCode;
    }
}
