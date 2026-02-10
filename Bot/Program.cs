using Bot;
using Bot.Data;
using Bot.Repository;

var todoRepository = new TodoRepository();
var userRepository = new UserRepository();
var userService = new UserService(userRepository);
var botService = new BotService(
    userService, 
    todoRepository
);
var telegramToken = "7663425286:AAGMZVVFJ86KFGYVrbd21Jc7GjTSRfhKYuw";
await botService.Start(telegramToken);