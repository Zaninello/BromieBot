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

    public async Task<bool> VerifyTodo(Todo todo)
    {
        try
        {
            var result = await _repo.VerifyTodo(todo);

            if(result == true)
            {
                return false;
            }
            
            return true; 

        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
                return false;
        }

    }
}
