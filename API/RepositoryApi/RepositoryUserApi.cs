using Models;

namespace BromieBot.API;

public class RepositoryUserApi : IUsuario
{
    public  bool VerificarUsuario(User user)
    {
        return true;

    }
}
