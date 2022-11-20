using Lab07.Problem_5_6._Border_Control___Birthday_Celebrations.Interfaces;

namespace Lab07.Problem_5_6._Border_Control___Birthday_Celebrations.Models;

public class CitizenProblem5 : IName, IIdentible, IBirthdate
{
    public CitizenProblem5(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
    }

    public int Age { get; protected set; }
    public string Id { get; protected set; }
    public string Model { get; protected set; }
    public string Name { get; protected set; }
    public string Birthdate { get; protected set; }
}