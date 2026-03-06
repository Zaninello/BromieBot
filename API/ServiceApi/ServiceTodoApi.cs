using System.Security.Cryptography.X509Certificates;
using Models;

namespace API;

public class ServiceTodoApi
{
    public ServiceTodoApi(RepositoryTodoApi repo)
    {
        _repo = repo;
    }

    private RepositoryTodoApi _repo;

    public async Task<bool> AddTodo(Todo todo)
    {
        try
        {
            await _repo.AddTodo(todo);
            return true;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<Todo?> VerifyTodo(long chatId, string nameTodo)
    {
        try
        {
            var result = await _repo.VerifyTodo(chatId, nameTodo);
            if(result is not null)
               return result;
            return null; 

        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
                return null;
        }
    }

    public async Task<bool> DeleteTodo(long chatId, string nameTodo)
    {
        var resultTodo = await VerifyTodo(chatId, nameTodo);

        if(resultTodo is null)
        {
            return false;
        }
        await _repo.DeleteTodo(chatId, nameTodo);
        return true;
    }
}
