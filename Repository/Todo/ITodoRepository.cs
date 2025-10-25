using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

public interface ITodoRepository
{
    List<Todo> BuscarTodos();
    void AddTodo(Todo todo);
    void RemoveTodo(Todo todo);
    void EditTodo(Todo todo);
    void ConcluirTodo(Todo todo);
}
