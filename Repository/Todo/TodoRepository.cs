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
    private readonly TelegramBotContext _connection;

    public TodoRepository() => _connection = new TelegramBotContext();

    public List<Todo> SearchTodos() =>
        _connection.Todos.ToList();

    public void AddTodo(Todo todo)
    {
        _connection.Todos.Add(todo);
        _connection.SaveChanges();
    }

    public void RemoveTodo(Todo todo)
    {
        _connection.Todos.Remove(todo);
        _connection.SaveChanges();
    }

    public void EditTodo(Todo todo, string newDescription)
    {
        todo.Description = newDescription;
        _connection.SaveChanges();
    }

    public void CompleteTodo(Todo todo)
    {
        todo.Status = "Completed";
        _connection.SaveChanges();
    }
}
