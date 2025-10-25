using DataBase;
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
    public bool VerificaUsuario(long chatId) =>
        repository.BuscarUsuario(chatId);

    public void AddUser(string nome, long chatId)
    {
        var user = new Usuario
        {
            Nome = nome,
            ChatId = chatId
        };

        repository.AddUser(user);
    }
}
