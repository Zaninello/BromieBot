using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataBase;

public interface ITodoRepository
{
    List<Todo> BuscarTodos();
    void AddTodo(Todo todo);
    void RemoveTodo(Todo todo);
    void EditTodo(Todo todo);
    void AddUser(Usuario user);
    List<Usuario> BuscarUsuarios();
    void Concluir(Todo todo);
}
