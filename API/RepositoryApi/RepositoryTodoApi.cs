using Microsoft.EntityFrameworkCore;
using DataBase;
using Models;

namespace API;

public class RepositoryTodoApi(TelegramBotContext context)
{
    public async Task AddTodo(Todo todo)
    {
        await context.Todos.AddAsync(todo);
        await context.SaveChangesAsync();
    }
}
