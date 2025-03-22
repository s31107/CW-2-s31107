namespace Containers.Cargos;

public class RefrigeratedCargo(double cargoWeight, string cargoType, double temperature) : Cargo(cargoWeight, cargoType)
{
    public double Temperature { get; } = temperature;
    
    public override string ToString() => $"Refrigerated Cargo, {base.ToString()}, Temperature: {Temperature}";
}