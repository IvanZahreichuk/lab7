using Lab07.Problem_7._Food_Shortage.Interfaces;

namespace Lab07.Problem_7._Food_Shortage.Models;

public class CitizenProblem7 : PersonProblem7, ICitizen
{
    public CitizenProblem7(string name, int age, string group)
        : base(name, age)
    {
        this.Group = group;
    }

    public string Group { get; protected set; }

    public void BuyFood()
    {
        this.Food += 5;
    }
}