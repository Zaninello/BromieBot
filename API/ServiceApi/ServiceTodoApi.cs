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
            var resultVerify = await VerifyTodo(todo.UserId, todo.Header);
            
            if(resultVerify is not null)
                return false;
            
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
            return await _repo.VerifyTodo(chatId, nameTodo);
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

    public async Task<bool> EditTodo(long chatId, string nameTodo, string newDescription)
    {
        if(await VerifyTodo(chatId, nameTodo) is null)
            return false;        

        await _repo.EditTodo(chatId, nameTodo, newDescription);
        return true;
    }

    public async Task<List<Todo>> GetAll(long chatId)
        => await _repo.GetAll(chatId); 
}
