using DataBase;
using Models;
using Repository;

namespace Functions;

public class TodoData(ITodoRepository repository)
{
    public void AddTask(long idUser, string header, string description, string status)
    {
        var todo = new Todo()
        {
            IdUser = idUser,
            Header = header,
            Description = description,
            Status = status
        };

        repository.AddTodo(todo);
    }

    public void RemoveTask(string header)
    {
        var todo = repository
            .BuscarTodos()
            .FirstOrDefault(t => t.Header == header);

        repository.RemoveTodo(todo!);
    }

    public void EditTodo(string header, string description)
    {
        var todo = repository.BuscarTodos().FirstOrDefault(t => t.Header == header);
        repository.EditTodo(todo!);
    }

    public List<Todo> ShowTodos(long chatId) => 
        repository.BuscarTodos().Where(t => t.IdUser == chatId).ToList();

    public bool VerificaExistenciaTodo(long chatId, string header) =>
        ShowTodos(chatId).Any(t => t.Header == header);

    public void ConcluirTarefa(string header)
    {
        var tarefa = repository.BuscarTodos().FirstOrDefault(t => t.Header == header);
        repository.ConcluirTodo(tarefa);
    }
}