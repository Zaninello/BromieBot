namespace Bot.Repository;

public interface ITodoRepository
{
    Task<Models.Todo?> SearchTodoByName(long chatId, string nameTodo);
    Task<IEnumerable<Models.Todo>> GetAllTodos(long chatId);
    Task<bool> AddTodo(Models.Todo todo);
    Task<bool> RemoveTodo(long chatId, string nameTodo);
    Task<string> EditTodo(long chatId, string nameTodo, string newDescription);
    Task CompleteTodo(Models.Todo todo);
}
