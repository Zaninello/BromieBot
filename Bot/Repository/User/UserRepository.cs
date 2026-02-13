using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using Microsoft.VisualBasic;
using Models;

namespace Bot.Repository;

public class UserRepository : IUserRepository
{
    private HttpClient client = new HttpClient();
    string url = "http://localhost:3000/api/usuario/";
     
    public async Task<bool> AddUser(User user) 
    {
        var userJson = new StringContent(
             user.ToString()!,
             Encoding.UTF8,
             "application/json"
        );

        var result = await client.PostAsync(url, userJson);
     return result.IsSuccessStatusCode; 
    }

    public async Task<bool> SearchUser(long chatId)
    {
        var result = await client.GetAsync(url + chatId);
        return result.IsSuccessStatusCode;
    }
}
