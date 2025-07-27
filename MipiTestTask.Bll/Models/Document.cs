namespace MipiTestTask.Bll.Models;

public class Document
{
    private Guid _id;
    public Guid Id
    {
        get => _id;
        init
        {
            if (value == Guid.Empty)
                throw new ArgumentException("Идентификатор документа не может быть пустым");

            _id = value;
        }
    }

    private string _name;
    public string Name
    {
        get => _name;
        init
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Наименование документа должно быть указано");

            _name = value;
        }
    }

    private User _user;
    public User User 
    { 
        get => _user;
        init
        {
            if (value is null)
                throw new ArgumentException("У документа должен быть указан пользователь");

            _user = value;
        }
    }

    public string Description { get; init; }

    public Priority Priority { get; init; }

    public Document(Guid id, string name, User user, string description, Priority priority)
    {
        Id = id;
        Name = name;
        User = user;
        Description = description;
        Priority = priority;
    }
}
