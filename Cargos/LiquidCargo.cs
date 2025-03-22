namespace Containers.Cargos;

public class LiquidCargo(bool isDangerous, double cargoWeight, string cargoType) : Cargo(cargoWeight, cargoType)
{
    public bool IsDangerous { get; } = isDangerous;
    
    public override string ToString() => $"Liquid Cargo, {base.ToString()}, IsDangerous: {IsDangerous}";
}