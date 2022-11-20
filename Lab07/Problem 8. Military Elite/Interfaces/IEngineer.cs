namespace Lab07.Problem_8._Military_Elite.Interfaces;

public interface IEngineer : ISpecialisedSoldier
{
    IList<IRepair> Repairs { get; }
}