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

    public async Task<Todo?> VerifyTodo(long chatId, string nameTodo)
    {
        return await context.Todos.FirstOrDefaultAsync(x => x.UserId == chatId && x.Header == nameTodo);
    }

    public async Task DeleteTodo(long chatId, string nameTodo)
    {
        await context.Todos.Where(x => x.UserId == chatId && x.Header == nameTodo).ExecuteDeleteAsync();
        await context.SaveChangesAsync();
    }
}
