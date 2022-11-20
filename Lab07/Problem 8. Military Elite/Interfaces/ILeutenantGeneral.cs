namespace Lab07.Problem_8._Military_Elite.Interfaces;

public interface ILeutenantGeneral : IPrivate
{
    IList<IPrivate> Privates { get; }
}