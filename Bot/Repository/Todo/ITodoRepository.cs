namespace Bot.Repository;

public interface ITodoRepository
{
    Task<Models.Todo?> SearchTodoByName(long chatId, string nameTodo);
    Task<IEnumerable<Models.Todo>> GetAllTodos(long chatId);
    Task<bool> AddTodo(Models.Todo todo);
    Task<bool> RemoveTodo(long chatId, string nameTodo);
    Task EditTodo(Models.Todo todo, string newDescription);
    Task CompleteTodo(Models.Todo todo);
}
