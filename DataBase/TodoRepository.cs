using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Models;

namespace DataBase;

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
        var t = _conexao.Todos.FirstOrDefault(x => x.Id == todo.Id);
        t.Description = todo.Description;
        _conexao.SaveChanges();
    }

    public void AddUser(Usuario user)
    {
        _conexao.Usuarios.Add(user);
        _conexao.SaveChanges();
    }

    public List<Usuario> BuscarUsuarios() => 
        _conexao.Usuarios.ToList();

    public void Concluir(Todo todo)
    {
        todo.Status = "concluido";
        _conexao.SaveChanges();
    }
}
