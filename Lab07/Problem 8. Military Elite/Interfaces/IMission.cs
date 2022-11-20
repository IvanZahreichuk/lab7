namespace Lab07.Problem_8._Military_Elite.Interfaces;

public interface IMission
{
    string CodeName { get; }

    string State { get; }

    void CompleteMission();
}