namespace CleanArchitectureBlazor.Domain.Entities;

public class Animal
{
    // todo : move to Constant class
    private const int NAME_MAX_LENGTH = 200;

    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Birthdate { get; set; }

    public Animal()
    { }

    public Animal(string name, DateTime birthdate)
    {
        Name = name;
        Birthdate = birthdate;
    }

    public Animal(int id, string name, DateTime birthdate)
    {
        Id = id;
        Name = name;
        Birthdate = birthdate;
    }

    public void ChangeName(string name)
    {
        if (!string.IsNullOrWhiteSpace(name) && name.Length <= NAME_MAX_LENGTH)
        {
            Name = name;
        }
    }
}
