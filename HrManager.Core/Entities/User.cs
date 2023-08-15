namespace HrManager.Core.Entities;

public class User
{
    public User() { }

    public User(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }


    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public int Age { get; set; }


    public bool IsOfLegalAge()
    {
        if (this.Age < 18)
            return false;

        return true;
    }
}
