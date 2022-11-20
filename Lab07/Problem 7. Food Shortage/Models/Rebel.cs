using Lab07.Problem_7._Food_Shortage.Interfaces;

namespace Lab07.Problem_7._Food_Shortage.Models;

public class Rebel : PersonProblem7, IRebel
{
    public Rebel(string name, int age, string id, string birthdate)
        : base(name, age)
    {
        this.Id = id;
        this.Birthdate = birthdate;
    }

    public string Id { get; }

    public string Birthdate { get; }

    public void BuyFood()
    {
        this.Food += 10;
    }
}