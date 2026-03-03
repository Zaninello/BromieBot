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

    public async Task<bool> VerifyTodo(Todo todo)
    {
        return await context.Todos.AnyAsync(x => x.Header == todo.Header);
    }
}
