using System.Globalization;
using System.Text.Json;

namespace Bot.Repository;

public class TodoRepository : ITodoRepository
{
    private HttpClient _client = new HttpClient();

    string url = "http://localhost:5155/api/Todo";

    JsonSerializerOptions options = new JsonSerializerOptions()
    { 
        PropertyNameCaseInsensitive = true
    };
    
    public async Task<IEnumerable<Models.Todo>> GetAllTodos(long chatId)
    {
        var resultApi = await _client.GetAsync($"{url}/getAll?chatId={chatId}");
        var returnApi = await resultApi.Content.ReadAsStringAsync();

        if(resultApi.IsSuccessStatusCode)
        {
            var list = JsonSerializer.Deserialize<List<Models.Todo>>(returnApi, options);
            return list;
        }
        return new List<Models.Todo>();
    }

    public async Task<string> AddTodo(Models.Todo todo)
    {
        var json = JsonSerializer.Serialize(todo);

        var todoJson = new StringContent(
            json,
            Encoding.UTF8,
            "application/json"
        );

        try
        {
            var resultApi = await _client.PostAsync(url, todoJson);
            var returnApi = await resultApi.Content.ReadAsStringAsync();
            return returnApi;
        }
        catch (Exception ex)
        {
            Console.WriteLine("erro no request para envio do Todo para a Api: " + ex.Message);
            return "Error";
        }
    }

    public async Task<string> RemoveTodo(long chatId, string nameTodo)
    {
        var resultApi = await _client.DeleteAsync($"{url}?chatId={chatId}&nameTodo={nameTodo}");
        var returnApi = await resultApi.Content.ReadAsStringAsync();
        return returnApi;
    }

    public async Task<string> EditTodo(long chatId, string nameTodo, string newDescription)
    {
        var query = "{0}/edit?chatId={1}&nameTodo={2}&newDescription={3}";
        var fullQuery = string.Format(
            query,
            url, chatId, nameTodo, newDescription 
        );

        var resultApi = await _client.GetAsync(fullQuery);
        var returnApi = await resultApi.Content.ReadAsStringAsync();

        return returnApi;
    }

    public async Task CompleteTodo(Models.Todo todo)
    {
        throw new NotImplementedException();
    }
}
