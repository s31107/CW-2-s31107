namespace Containers.Cargos;

public abstract class Cargo(double cargoWeight, string cargoType)
{
    public double CargoWeight { get; } = cargoWeight;
    public string CargoType { get; } = cargoType;

    public override string ToString() => $"Cargo: {CargoType}, Weight: {CargoWeight}";
}