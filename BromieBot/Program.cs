using System.Globalization;
using System.Net.Http.Headers;
using DataBase;
using Microsoft.EntityFrameworkCore.Design;
using Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using static Functions.Functions;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BromieBot;

public static class Program
{
    static async Task Main(string[] args)
    {
        var bot = new TelegramBotClient();
        bot.StartReceiving(ProcessUpdate, ProcessError);
        Console.ReadLine();
    }
    public static async Task ProcessUpdate(ITelegramBotClient bot, Update update, CancellationToken ct)
    {
        var text = update.Message.Text;
        var chatId = update.Message.Chat.Id;

        var functions = new Functions.Functions(new TodoRepository());

        if (string.IsNullOrEmpty(text)) return;

        if (functions.VerificaUsuario(chatId) is false)
            functions.AddUser(update.Message.Chat.FirstName, chatId);

        if (text.ToLower() == "/menu")
        {
            await bot.SendMessage(chatId, "/add\n/deletar\n/edit\n/show\n/concluir");
            return;
        }
        if (text.ToLower() == "/show")
        {
            var list = functions.ShowTodos(chatId);

            if (list.Count() == 0)
            {
                await bot.SendMessage(chatId, "Lista vazia");
                return;
            }

            foreach (var item in list)
            {
                await bot.SendMessage(chatId, $"Id: {item.Id}." +
                                              $"\nHeader: {item.Header}." +
                                              $"\nDescription: {item.Description}." +
                                              $"\nStatus: {item.Status}.");
            }
            return;
        }

        if (text.Split(" ").Count() == 2)
        {
            var cmd = text.Split(" ");

            if (cmd[0] == "/concluir")
            {
                if (functions.VerificaExistenciaTodos(cmd[1]) is false)
                {
                    await bot.SendMessage(chatId, $"tarefa {cmd[1]} não existe.");
                    return;
                }
                functions.ConcluirTarefa(cmd[1]);
                await bot.SendMessage(chatId, $"tarefa concluida.");
                return;
            }
            if (cmd[0] == "/deletar")
            {
                if (functions.VerificaExistenciaTodos(cmd[1]) is false)
                {
                    await bot.SendMessage(chatId, $"tarefa { cmd[1]} não existe.");
                    return;
                }
                functions.RemoveTask(cmd[1]);
                await bot.SendMessage(chatId, $"Tarefa {cmd[1]} removida com sucesso!");
                return;
            }
        }

        if (text.Split(" ").Count() < 3)
        {
            await bot.SendMessage(chatId, "Digite /Menu");
            return;
        }

        var command = text.Split(" ")[0].ToLower();
        var header = text.Split(" ")[1].ToLower();
        var description = text.Split(" ")[2].ToLower();
        
        switch (command)
        {
            case "/add":
                if (functions.VerificaExistenciaTodos(header))
                {
                    await bot.SendMessage(
                        chatId, 
                        $"Já existe uma tarefa com este nome: {header}.\n" +
                                            $"Para prosseguir chame o /Menu novamente."
                        );
                    return;
                }
                
                functions.AddTask(
                    chatId,
                    header, 
                    description,
                    "pendente"
                );

                await bot.SendMessage(chatId,$"Tarefa {header} adicionada com sucesso!");
                break;

            

                

            case "/edit":
                if (functions.VerificaExistenciaTodos(header) is false)
                {
                    await bot.SendMessage(chatId, $"A tarefa: {header} não existe.");
                    return;
                }

                functions.EditTodo(header, description);
                await bot.SendMessage(chatId, $"Tarefa {header} alterada com sucesso!");
                break;
        }
    }

    public static async Task ProcessError(ITelegramBotClient bot, Exception ex, CancellationToken ct) { }

}
