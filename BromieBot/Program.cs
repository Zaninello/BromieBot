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
        var bot = new TelegramBotClient("");
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

        if (userData.VerificaUsuario(chatId) is false)
            userData.AddUser(update.Message.Chat.FirstName, chatId);

        var command = text.Split(" ");

        if (command[0].ToLower() == "/menu")
        {
            await bot.SendMessage(
                chatId, 
                "*_MENU_*" + 
                "\n/add _<nome_data_tarefa> <descricao da tarefa>_" +
                "\n/deletar _<nome_da_tarefa>_"+
                "\n/edit _<nome_da_tarefa>_ _descricao_nova_\n" + 
                "/show - mostra suas tarefas\n" +
                "/concluir _<nome_da_tarefa> - conclui uma tarefa_",
                ParseMode.MarkdownV2
            );
            return;
        }

        if (command[0].ToLower() == "/show")
        {
            var list = todoData.ShowTodos(chatId);

            if (list.Count == 0)
            {
                await bot.SendMessage(chatId, "Não há nenhuma tarefa");
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
        }

        if (command.Count() == 2)
        {
            var firstCommand = command[0];
            var todoName = command[1];
            if (firstCommand == "/concluir")
            {
                if (todoData.VerificaExistenciaTodo(chatId, todoName) is false)
                {
                    await bot.SendMessage(
                        chatId, 
                        $"tarefa {todoName} não existe."
                    );
                    return;
                }
                
                todoData.ConcluirTarefa(todoName);

                await bot.SendMessage(
                    chatId, 
                    $"tarefa: {todoName} concluida."
                );
                
                return;
            }
            if (firstCommand == "/deletar")
            {
                var todoExists = todoData
                    .VerificaExistenciaTodo(chatId, todoName);

                if (todoExists is false)
                {
                    await bot.SendMessage(
                        chatId, 
                        $"A tarefa: {todoName} não existe."
                    );
                    return;
                }

                todoData.RemoveTask(todoName);

                await bot.SendMessage(
                    chatId, 
                    $"A tarefa: {todoName} removida com sucesso!"
                );
                
                return;
            }
        }

        if (text.Split(" ").Count() < 3)
        {
            await bot.SendMessage(chatId, "Digite /Menu");
            return;
        }

        switch (command[0])
        {
            case "/add":
                if (todoData.VerificaExistenciaTodo(chatId, command[1]))
                {
                    await bot.SendMessage(
                        chatId, 
                        $"Já existe uma tarefa com este nome: {command[1]}.\n" +
                        $"Para prosseguir chame o /Menu novamente."
                    );
                    return;
                }
                
                todoData.AddTask(
                    chatId,
                    command[1],
                    command[2],
                    "pendente"
                );

                await bot.SendMessage(
                    chatId,
                    $"Tarefa {command[1]} adicionada com sucesso!"
                );

                break;

            case "/edit":
                if (todoData.VerificaExistenciaTodo(chatId, command[1]) is false)
                {
                    await bot.SendMessage(chatId, $"A tarefa: {command[1]} não existe.");
                    return;
                }

                todoData.EditTodo(command[1], command[2]);
                await bot.SendMessage(
                    chatId, 
                    $"Tarefa {command[1]} alterada com sucesso!"
                );
                break;
            default:
                await bot.SendMessage(
                    chatId, 
                    $"Comando {command[1]} não reconhecido!"
                );
                break;
        }
    }

    public static async Task ProcessError(ITelegramBotClient bot, Exception ex, CancellationToken ct) { }

}
