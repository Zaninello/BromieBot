using Models;

namespace API;

public class ServiceTodoApi
{
    ServiceTodoApi(RepositoryTodoApi repo)
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
            Console.WriteLine(ex);
                return false;
        }
    }
}
