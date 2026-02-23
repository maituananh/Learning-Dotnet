using System.Text.Json.Serialization;

namespace Domain;

public class User
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    [JsonConstructor]
    public User(Guid id, string name, string email, string password)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
    }

    public User(Guid id)
    {
        if (id.Equals(null))
        {
            throw new ArgumentException("Id must not be empty.");
        }

        Id = id;
    }

    private User(string name, string email, string password)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Password = password;
    }

    public User(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    private User(string name, string password)
    {
        Name = name;
        Password = password;
    }

    public static User Create(string name, string email, string password)
    {
        return new User(name, email, password);
    }

    public static User Login(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("Username and password must not be empty.");
        }

        return new User(username, password);
    }
}
