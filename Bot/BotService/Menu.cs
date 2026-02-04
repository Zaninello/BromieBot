using Models;
using Telegram.Bot.Types.Enums;

namespace Bot;

public partial class BotService
{
    public static async Task Menu(ITelegramBotClient _bot, long chatId, string text)
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
            if (listTodos.Any() is false)
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
            var todoDescription = allMessageParts[2];
            var todoExists = await _todoRepository
                .SearchTodoByName(chatId, todoName);
            
            if (todoExists is null)
            {
                await bot.SendMessage(
                    chatId, 
                    $"Task: {todoName} does not exist."
                );
                return;
            }

            var todo = new Todo(chatId, todoName, todoDescription);
            
            await _todoRepository.AddTodo(todo);
            
            await bot.SendMessage(
                chatId,
                $"Task {todoName} successfully added!"
            );

            return;
        }
        
        if (UserCanEdit(allMessageParts))
        {
            var todoName = allMessageParts[1];
            var newTodoDescription = allMessageParts[2];
            var todo = await _todoRepository
                .SearchTodoByName(chatId, todoName);
            
            if (todo is null)
            {
                await _bot.SendMessage(
                    chatId, 
                    $"Task: {todoName} does not exist."
                );
                return;
            }

            await _todoRepository.EditTodo(todo, newTodoDescription);
            
            await _bot.SendMessage(
                chatId, 
                $"Task {todoName} successfully changed!"
            );

            return;
        }
        
        if (UserCanCompleteTodo(allMessageParts))
        {
            var todoName = allMessageParts[1];
            var todo = await _todoRepository
                .SearchTodoByName(chatId, todoName);

            if (todo is null)
            {
                await _bot.SendMessage(
                    chatId, 
                    $"Task: {todoName} does not exist."
                );
                return;
            }

            await _todoRepository.CompleteTodo(todo);
            
            await _bot.SendMessage(
                chatId,
                $"Task {todoName} successfully completed!"
            );

            return;
        }
        
        if (UserCanDelete(allMessageParts))
        {
            var nameTodoToDelete = allMessageParts[1];
            
            var todo = await _todoRepository.SearchTodoByName(
                chatId, nameTodoToDelete
            );
            
            if (todo is null)
            {
                await _bot.SendMessage(
                    chatId, 
                    $"Task: {nameTodoToDelete} does not exist."
                );
                return;
            }

            await _todoRepository.RemoveTodo(todo);
            
            await _bot.SendMessage(
                chatId, 
                $"Task {nameTodoToDelete} successfully remove!"
            );
        }
        
        await _bot.SendMessage(
            chatId, 
            $"command {command} not cataloged! Type /menu to view formatting options"
        );
    }
}