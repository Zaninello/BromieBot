using DataBase;
using Models;

namespace Repository;

public class UserRepository : IUserRepository
{
    private readonly TelegramBotContex _conexao;

    public UserRepository() => _conexao = new TelegramBotContex();
    
    public void AddUser(Usuario user)
    {
        _conexao.Add(user);
        _conexao.SaveChanges();
    }

    public bool BuscarUsuario(long chatId) =>
        _conexao.Usuarios.Any(u => u.ChatId == chatId);
}
