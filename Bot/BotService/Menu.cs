using Models;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace Bot;

public partial class BotService
{
    public static async Task Menu(long chatId, string text)
    {
        var allMessageParts = text.Split(" ");
        var command = allMessageParts[0];
        
        if (UserCanGoToMenu(allMessageParts))
        {
            await bot.SendMessage(
                chatId,
                "<b><i>MENU</i></b>" +
                "\n/add <i>&lt;Task_Name&gt; &lt;Task description&gt;</i>" +
                "\n/delete <i>&lt;Task_Name&gt;</i>" +
                "\n/edit <i>&lt;Task_Name&gt;</i> <i>New description</i>\n" +
                "/show - show tasks\n" +
                "/complete <i>&lt;Task_Name&gt;</i> - Complete tasks",
                ParseMode.Html
            );

            return;
        }

        if (UserCanList(allMessageParts))
        {
            var todos = await _todoRepository.GetAllTodos(chatId);
            var listTodos = todos.ToList();

            if (listTodos is null || listTodos.Count() is <= 0)
            {
                await bot.SendMessage(chatId, "There are not tasks listed");
                return;
            }
            foreach (var item in listTodos)
            {
                await bot.SendMessage(
                    chatId,
                    $"Id: {item.Id}." +
                    $"\nHeader: {item.Header}." +
                    $"\nDescription: {item.Description}." +
                    $"\nStatus: {item.Status}."
                );
            }

            return;
        }

        if (UserCanAdd(allMessageParts))
        {

            var todoName = allMessageParts[1];
            var rangeDescription = allMessageParts.Skip(2);
            var todoDescription = string.Join(" ", rangeDescription);
            var todo = new Todo(chatId, todoName, todoDescription);
            var resultApi = await _todoRepository.AddTodo(todo);

            await bot.SendMessage(
                chatId,
                resultApi
            );

            return;
        }
        
        if (UserCanEdit(allMessageParts))
        {
            var todoName = allMessageParts[1];
            var rangeDescription = allMessageParts.Skip(2);
            var newTodoDescription = string.Join(" ", rangeDescription);
            
            var resultApi = await _todoRepository.EditTodo(chatId, todoName, newTodoDescription);

                await bot.SendMessage(
                chatId,
                resultApi 
            );
            return;
        }
        
        if (UserCanCompleteTodo(allMessageParts))
        {
            var todoName = allMessageParts[1];
           
           var returnApi = await _todoRepository.CompleteTodo(chatId, todoName);
            
            await bot.SendMessage(
                chatId,
                returnApi
            );

            return;
        }
        
        if (UserCanDelete(allMessageParts))
        {
            var nameTodoToDelete = allMessageParts[1];
            
            var resultApi = await _todoRepository.RemoveTodo(chatId, nameTodoToDelete);

            await bot.SendMessage(
                chatId,
                resultApi 
            );
            return;
        }

        await bot.SendMessage(
            chatId, 
            $"command {command} not cataloged! Type /menu to view formatting options"
        );
    }
}