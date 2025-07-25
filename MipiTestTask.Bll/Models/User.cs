using System.Text.RegularExpressions;

namespace MipiTestTask.Bll.Models;

public class User
{
    private Guid _id;
    public Guid Id 
    {
        get => _id;
        init
        {
            if (value == Guid.Empty)
                throw new ArgumentException("Идентификатор пользователя не может быть пустым");

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
                throw new ArgumentException("Имя пользователя должно быть указано");

            _name = value;
        }
    }

    private string _login;
    public string Login
    {
        get => _login;
        init
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Логин пользователя должен быть указан");

            if (!Regex.IsMatch(value, "^[a-zA-Z0-9]*$"))
                throw new ArgumentException("Логин пользователя должен состоять только из латинских букв и цифр");

            _login = value;
        }
    }

    public User(Guid id, string name, string login)
    {
        Id = id;
        Name = name;
        Login = login;
    }
}