using Bot.Rules;

namespace Bot;

public partial class BotService
{
    private static bool UserCanList(string[] entireMessage)
    {
        var command = entireMessage[0];
        
        if (command == "/list" || command == "/show") return true;
        
        return false;
    }
    private static bool UserCanGoToMenu(string[] entireMessage)
    {
        var command = entireMessage[0];
        if (
            command == "/menu" ||
            command == "/start"
        ) return true;
        return false;
    }
    private static bool UserCanAdd(string[] entireMessage)
    {
        return entireMessage[0] == "/add" &&
               entireMessage.Length >= (int)MessageRules.MinimumPartsNecessaryToAdd;
    }
    private static bool UserCanEdit(string[] entireMessage)
    {
        return entireMessage[0] == "/edit" &&
               entireMessage.Length == (int)MessageRules.TotalPartsNecessaryToEdit;
    }
    private static bool UserCanDelete(string[] entireMessage)
    {
        return entireMessage[0] == "/delete" &&
               entireMessage.Length == (int)MessageRules.TotalPartsNecessaryToDeleteOrComplete;
    }
    private static bool UserCanCompleteTodo(string[] entireMessage)
    {
        return entireMessage[0] == "/complete" &&
               entireMessage.Length == (int)MessageRules.TotalPartsNecessaryToDeleteOrComplete; 
    }
    private static async Task VerifyUser(long userChatId, string userName)
    {
        var userExists = await _userService.VerifyUser(userChatId);
        if (userExists is false)
            await _userService.AddUser(userChatId, userName);
    }

}