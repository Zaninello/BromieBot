namespace Bot.Repository;

public class TodoRepository : ITodoRepository
{
    public async Task<Models.Todo?> SearchTodoByName(long chatId, string nameTodo)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Models.Todo>> GetAllTodos(long chatId)
    {
        throw new NotImplementedException();
    }

    public async Task AddTodo(Models.Todo todo)
    {
        throw new NotImplementedException();
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
