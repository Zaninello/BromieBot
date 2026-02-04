using Bot;
using Bot.Data;
using Bot.Repository.Todo;
using Bot.Repository.User;

var todoRepository = new TodoRepository();
var userRepository = new UserRepository();
var userService = new UserService(userRepository);
var botService = new BotService(
    userService, 
    todoRepository
);
var telegramToken = "";
await botService.Start(telegramToken);