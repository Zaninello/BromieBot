using System.Text.Json;

namespace Bot.Repository;

public class TodoRepository : ITodoRepository
{
    private HttpClient _client = new HttpClient();

    string url = "http://localhost:5155/api/Todo";
    
    public async Task<Models.Todo?> SearchTodoByName(long chatId, string nameTodo)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Models.Todo>> GetAllTodos(long chatId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddTodo(Models.Todo todo)
    {
        var json = JsonSerializer.Serialize(todo);

        var todoJson = new StringContent(
            json,
            Encoding.UTF8,
            "application/json"
        );

        try
        {
            var result = await _client.PostAsync(url, todoJson);
                return result.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine("erro no request para envio do Todo para a Api: " + ex.Message);
            return false;
        }
    }

    public async Task RemoveTodo(Models.Todo todo)
    {
        throw new NotImplementedException();
    }

    public async Task EditTodo(Models.Todo todo, string newDescription)
    {
        throw new NotImplementedException();
    }

    public async Task CompleteTodo(Models.Todo todo)
    {
        throw new NotImplementedException();
    }
}
