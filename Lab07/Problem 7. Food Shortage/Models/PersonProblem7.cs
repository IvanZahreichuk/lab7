using Lab07.Problem_7._Food_Shortage.Interfaces;

namespace Lab07.Problem_7._Food_Shortage.Models;

public abstract class PersonProblem7 : IPersonProblem7
{
    protected PersonProblem7(string name, int age)
    {
        this.Name = name;
        this.Age = age;
        this.Food = 0;
    }

    public string Name { get; }

    public int Age { get; }

    public void BuyFood()
    {
    }

    public int Food { get; protected set; }
}