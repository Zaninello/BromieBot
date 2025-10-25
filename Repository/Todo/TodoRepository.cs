using DataBase;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

public class TodoRepository : ITodoRepository
{
    private readonly TelegramBotContex _conexao;

    public TodoRepository() => _conexao = new TelegramBotContex();

    public List<Todo> BuscarTodos() =>
        _conexao.Todos.ToList();

    public void AddTodo(Todo todo)
    {
        _conexao.Todos.Add(todo);
        _conexao.SaveChanges();
    }

    public void RemoveTodo(Todo todo)
    {
        _conexao.Todos.Remove(todo);
        _conexao.SaveChanges();
    }

    public void EditTodo(Todo todo)
    {
        todo.Description = todo.Description;
        _conexao.SaveChanges();
    }

    public void ConcluirTodo(Todo todo)
    {
        todo.Status = "concluido";
        _conexao.SaveChanges();
    }
}
