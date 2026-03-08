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
        => await context.Todos.FirstOrDefaultAsync(x => x.UserId == chatId && x.Header == nameTodo);

    public async Task DeleteTodo(long chatId, string nameTodo)
    {
        var todo = await context
            .Todos
            .FirstOrDefaultAsync(x => x.UserId == chatId && x.Header == nameTodo);

        context.Todos.Remove(todo!);
        await context.SaveChangesAsync();
    }

    public async Task EditTodo(long chatId, string nameTodo, string descriptionNew)
    {
        var todo = await context
            .Todos
            .FirstOrDefaultAsync(x => x.UserId == chatId && x.Header == nameTodo);

        todo!.Description = descriptionNew;
        await context.SaveChangesAsync();
    }

    public async Task<List<Todo>> GetAll(long chatId)
    {
        var list = context.Todos.Where(x => x.UserId == chatId).ToList();
        return list;
    }
}
