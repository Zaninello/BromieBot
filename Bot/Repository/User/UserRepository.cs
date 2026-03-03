using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.VisualBasic;
using Models;

namespace Bot.Repository;

public class UserRepository : IUserRepository
{
    private HttpClient client = new HttpClient();
    string url = "http://localhost:5155/api/usuario";
    
    public async Task<bool> SearchAndAddUser(User user) 
    {
        var json = JsonSerializer.Serialize(user);

        var userJson = new StringContent(
            json,
            Encoding.UTF8,
            "application/json"
        );
        try
        {
            var result = await client.PostAsync(url, userJson);
            return result.IsSuccessStatusCode; 
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("erro no request: " + ex.Message);
            return false;
        }
    }
}
