using DataBase;
using Models;
using static DataBase.GlobalConnections;

namespace Functions;

public class Functions
{
    private readonly ITodoRepository repository;
    public Functions(ITodoRepository repository)
    { 
        this.repository = repository;
    }

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
        var todo = repository.BuscarTodos().FirstOrDefault(t => t.Header == header);
        repository.RemoveTodo(todo!);
    }

    public void EditTodo(string header, string description)
    {
        var todo = repository.BuscarTodos().FirstOrDefault(t => t.Header == header);
        repository.EditTodo(todo!);
    }

    public List<Todo> ShowTodos(long chatId) => 
        repository.BuscarTodos().Where(t => t.IdUser == chatId).ToList();

    public bool VerificaExistenciaTodos(string header) =>
        repository.BuscarTodos().Any(h => h.Header == header);

    public bool VerificaUsuario(long chatId) =>
        repository.BuscarUsuarios().Any(u => u.ChatId == chatId);
    public void AddUser(string nome, long chatId)
    {
        var user = new Usuario
        {
            Nome = nome,
            ChatId = chatId
        };

        repository.AddUser(user);
    }

    public void ConcluirTarefa(string header)
    {
        var tarefa = repository.BuscarTodos().FirstOrDefault(t => t.Header == header);
        repository.Concluir(tarefa);
    }

}