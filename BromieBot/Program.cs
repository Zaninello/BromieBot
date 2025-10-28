using System;
using System.Globalization;
using System.Net.Http.Headers;
using Data;
using DataBase;
using Functions;
using Microsoft.EntityFrameworkCore.Design;
using Models;
using Repository;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BromieBot;

public static class Program
{
    static async Task Main(string[] args)
    {
        var bot = new TelegramBotClient("8385370346:AAEjOGnEk0yJtJ_l4RNtrZtDaQ5BfNYdl1g");
        bot.StartReceiving(ProcessUpdate, ProcessError);
        Console.ReadLine();
    }
    public static async Task ProcessUpdate(ITelegramBotClient bot, Update update, CancellationToken ct)
    {
        var text = update.Message.Text;
        var chatId = update.Message.Chat.Id;

        var userData = new UserData(new UserRepository());
        var todoData = new TodoData(new TodoRepository());

        if (string.IsNullOrEmpty(text)) return;

        if (userData.VerifyUser(chatId) is false)
            userData.AddUser(update.Message.Chat.FirstName, chatId);

        string[] partes = text.Split(" ");

        var des = partes.Skip(2);
        
        var command = "";
        
        var header = "";
        
        string description = string.Empty;

        if (partes.Count() >= 3)
        {
            command = partes[0];
            header = partes[1];
            description = String.Join(" ", des);
        }
        else if (partes.Count() == 2)
        {
            command = partes[0];
            header = partes[1];
        }
        else if((partes.Count() == 1 && partes[0].ToLower() is "/menu") || (partes.Count() == 1 && partes[0].ToLower() is "/show") || (partes.Count() == 1 && partes[0].ToLower() is "/start"))
        {
            command = partes[0];
        }
        else
        {

        }

        if (command.ToLower() == "/menu" || command.ToLower() == "/start")
        {
            await bot.SendMessage(
                chatId,
                "<b><i>MENU</i></b>" +
                "\n/add <i>Task_Name</i>   <i>Task description</i>" +
                "\n/delete <i>Task_Name</i>" +
                "\n/edit <i>Task_Name</i>   <i>New description</i>\n" +
                "/show - show tasks\n" +
                "/complete <i>Task_Name</i>  - Complete tasks",
                ParseMode.Html
            );
            return;
        }
            
        switch (command)
        {
            case "/add":
                if (todoData.VerifyExistence(chatId, header))
                {
                    await bot.SendMessage(
                        chatId, 
                        $"There is already a task with this name: {header}.\n" +
                        $"To continue, call up the /Menu again."
                    );
                    return;
                }
                
                todoData.AddTask(
                    chatId,
                    header,
                    description,
                    "pending"
                );

                await bot.SendMessage(
                    chatId,
                    $"Task {header} successfully added!"
                );
                break;

            case "/remove":
                if (todoData.VerifyExistence(chatId, header) is false)
                {
                    await bot.SendMessage(chatId, $"Task: {header} does not exist.");
                    return;
                }

                await bot.SendMessage(
                   chatId,
                   $"Task {header} successfully remove!"
               );

                todoData.RemoveTask(header);
                break;

            case "/edit":
                if (todoData.VerifyExistence(chatId, header) is false)
                {
                    await bot.SendMessage(chatId, $"Task: {header} does not exist.");
                    return;
                }

                todoData.EditTodo(header, description);
                await bot.SendMessage(
                    chatId, 
                    $"Task {header} successfully changed!"
                );
                break;

            case "/complete":
                if (todoData.VerifyExistence(chatId, header) is false)
                {
                    await bot.SendMessage(chatId, $"Task: {header} does not exist.");
                    return;
                }

                todoData.CompleteTask(header);
                await bot.SendMessage(
                    chatId,
                    $"Task {header} successfully completed!"
                );
                break;

            case "/show":
                var list = todoData.ShowTodos(chatId);

                if (list.Count == 0)
                {
                    await bot.SendMessage(chatId, "There are not tasks listed");
                    return;
                }

                foreach (var item in list)
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
                break;
            
            default:
                await bot.SendMessage(
                    chatId, 
                    $"command {command} not cataloged! Type /menu to view formatting options"
                );
                break;
        }
    }

    public static async Task ProcessError(ITelegramBotClient bot, Exception ex, CancellationToken ct) { }

}
