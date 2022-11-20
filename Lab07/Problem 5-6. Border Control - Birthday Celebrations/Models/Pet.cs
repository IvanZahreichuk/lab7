using Lab07.Problem_5_6._Border_Control___Birthday_Celebrations.Interfaces;

namespace Lab07.Problem_5_6._Border_Control___Birthday_Celebrations.Models;

public class Pet : IName, IBirthdate
{
    public Pet(string name, string birthdate)
    {
        this.Birthdate = birthdate;
        this.Name = name;
    }

    public string Name { get; protected set; }
    public string Birthdate { get; protected set; }
}