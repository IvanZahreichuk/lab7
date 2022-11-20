using Lab07.Problem_3._Ferrari.Interfaces;

namespace Lab07.Problem_3._Ferrari.Models;

public class Ferrari : ICar
{
    private string _model;
    private string _brakes;
    private string _gasPedal;

    public Ferrari(string driversName)
    {
        this.DriversName = driversName;
        this.Model = _model;
        this.GasPedal = _gasPedal;
        this.Brakes = _brakes;
    }

    public string DriversName { get; }

    public string Model
    {
        get => _model;
        private set => this._model = "488-Spider";
    }

    public string Brakes
    {
        get => _brakes;
        private set => this._brakes = "Brakes!";
    }

    public string GasPedal
    {
        get => this._gasPedal;
        private set => this._gasPedal = "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.Brakes}/{this.GasPedal}/{this.DriversName}";
    }
}