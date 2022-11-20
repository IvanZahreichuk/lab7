using Lab07.Problem_1_2._Define_an_Interface_IPerson___Multiple_Implementation.Interfaces;

namespace Lab07.Problem_1_2._Define_an_Interface_IPerson___Multiple_Implementation.Models;

public class Citizen : IPerson, IIdentifiable, IBirthable
{
    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
    }

    public string Name { get; }
    public int Age { get; }
    public string Id { get; }
    public string Birthdate { get; }
}