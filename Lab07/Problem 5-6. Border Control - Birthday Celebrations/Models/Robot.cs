using Lab07.Problem_5_6._Border_Control___Birthday_Celebrations.Interfaces;

namespace Lab07.Problem_5_6._Border_Control___Birthday_Celebrations.Models;

public class Robot : IIdentible
{
    public Robot(string model, string id)
    {
        this.Model = model;
        this.Id = id;
    }

    public string Model { get; protected set; }
    public string Id { get; protected set; }
}