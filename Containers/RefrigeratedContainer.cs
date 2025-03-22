using Containers.Cargos;
using Containers.Exceptions;
using Containers.Interfaces;

namespace Containers.Containers;

public class RefrigeratedContainer(double height, double containerWeight, double depth, 
    double maximumLoad, double temperature) : Container(height, containerWeight, depth, maximumLoad, "C"), 
    ILoadable<RefrigeratedCargo>
{
    private readonly List<RefrigeratedCargo> _cargos = [];
    public RefrigeratedCargo? RefrigeratedCargoType { get; private set; }
    public double Temperature { get; } = temperature;

    public List<RefrigeratedCargo> Unload()
    {
        UnloadStrategy();
        Weight = 0;
        var cargosTemp = new List<RefrigeratedCargo>(_cargos);
        _cargos.Clear();
        RefrigeratedCargoType = null;
        return cargosTemp;
    }

    public void Load(RefrigeratedCargo refrigeratedCargo)
    {
        if (Temperature < refrigeratedCargo.Temperature)
        {
            throw new CargoMismatchException("Container has lower temperature than cargo.");
        }
        if (RefrigeratedCargoType != null && RefrigeratedCargoType.CargoType != refrigeratedCargo.CargoType)
        { 
            throw new CargoMismatchException("Container can store only one type of product.");
        }
        RefrigeratedCargoType ??= refrigeratedCargo; 
        LoadStrategy(refrigeratedCargo); 
        _cargos.Add(refrigeratedCargo);
    }
    
    public override string ToString()
    {
        return $"Refrigerated Container: {base.ToString()}, Temperature: {Temperature}, " +
               $"Refrigerated CargoType: {RefrigeratedCargoType}";
    }
    
    public override bool IsEmpty() =>_cargos.Count == 0;
}