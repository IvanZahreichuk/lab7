namespace Lab07.Problem_8._Military_Elite.Interfaces;

public interface ICommando : ISpecialisedSoldier
{
    IList<IMission> Missions { get; }
}