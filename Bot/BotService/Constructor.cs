using Bot.Data;
using Bot.Repository;

namespace Bot;

public partial class BotService
{
    public BotService(UserService userService, ITodoRepository repository)
    {
        _userService = userService;
        _todoRepository = repository;
    }
    
    private static UserService _userService;
    private static ITodoRepository _todoRepository;
}
