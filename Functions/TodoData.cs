using Data;
using Models;
using Repository;

namespace Functions;

public class TodoData(ITodoRepository repository)
{
    public void AddTask(long idUser, string header, string description, string status)
    {
        var todo = new Todo()
        {
            UserId = idUser,
            Header = header,
            Description = description,
            Status = status
        };

        repository.AddTodo(todo);
    }

    public void RemoveTask(string header)
    {
        var todo = repository
            .SearchTodos()
            .FirstOrDefault(t => t.Header == header);

        repository.RemoveTodo(todo!);
    }

    public void EditTodo(string header, string newDescription)
    {
        var todo = repository.SearchTodos().FirstOrDefault(t => t.Header == header);
        repository.EditTodo(todo!, newDescription);
    }

    public List<Todo> ShowTodos(long chatId) => 
        repository.SearchTodos().Where(t => t.UserId == chatId).ToList();

    public bool VerifyExistence(long chatId, string header) =>
        ShowTodos(chatId).Any(t => t.Header == header);

    public void CompleteTask(string header)
    {
        var tarefa = repository.SearchTodos().FirstOrDefault(t => t.Header == header);
        repository.CompleteTodo(tarefa);
    }
}