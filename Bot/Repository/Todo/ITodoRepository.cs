namespace Bot.Repository;

public interface ITodoRepository
{
    Task<IEnumerable<Models.Todo>> GetAllTodos(long chatId);
    Task<string> AddTodo(Models.Todo todo);
    Task<string> RemoveTodo(long chatId, string nameTodo);
    Task<string> EditTodo(long chatId, string nameTodo, string newDescription);
    Task<string> CompleteTodo(long chatId, string nameTodo);
}
