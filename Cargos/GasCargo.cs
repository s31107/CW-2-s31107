namespace Containers.Cargos;

public class GasCargo(double cargoWeight, string cargoType, double pressure) : Cargo(cargoWeight, cargoType)
{
    public double Pressure { get; } = pressure;
    
    public override string ToString() => $"GasCargo, {base.ToString()}, Pressure: {Pressure}";
}