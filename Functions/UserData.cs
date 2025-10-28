using Data;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data;

public class UserData(IUserRepository repository)
{
    public bool VerifyUser(long chatId) =>
        repository.SearchUser(chatId);

    public void AddUser(string name, long chatId)
    {
        var user = new User
        {
            Name = name,
            ChatId = chatId
        };

        repository.AddUser(user);
    }
}
