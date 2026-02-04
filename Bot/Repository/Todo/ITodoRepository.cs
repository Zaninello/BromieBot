namespace Bot.Repository.Todo;

public interface ITodoRepository
{
    Task<Models.Todo?> SearchTodoByName(long chatId, string nameTodo);
    Task<IEnumerable<Models.Todo>> GetAllTodos(long chatId);
    Task AddTodo(Models.Todo todo);
    Task RemoveTodo(Models.Todo todo);
    Task EditTodo(Models.Todo todo, string newDescription);
    Task CompleteTodo(Models.Todo todo);
}
