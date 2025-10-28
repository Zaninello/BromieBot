using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

public interface IUserRepository
{
    void AddUser(User user);
    bool SearchUser(long chatId);
}
