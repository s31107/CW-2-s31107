using Containers.Cargos;
using Containers.Interfaces;

namespace Containers.Containers;

public class LiquidContainer(double height, double containerWeight, double depth, double maximumLoad) : 
    Container(height, containerWeight, depth, maximumLoad, "L"), IHazardNotifier, ILoadable<LiquidCargo>
{
    private readonly List<LiquidCargo> _cargos = [];
    public bool IsDangerous { get; private set; }

    public List<LiquidCargo> Unload()
    {
        UnloadStrategy();
        Weight = 0;
        var cargosTemp = new List<LiquidCargo>(_cargos);
        _cargos.Clear();
        IsDangerous = false;
        return cargosTemp;
    }
    
    public void Load(LiquidCargo liquidCargo)
    {
        LoadStrategy(liquidCargo); 
        if (Weight + liquidCargo.CargoWeight > MaximumLoad * (liquidCargo.IsDangerous || IsDangerous ? 0.5 : 0.9)) 
        { 
            Notify("WARNING: LiquidCargo exceeds recommended load.");
        } 
        IsDangerous |= liquidCargo.IsDangerous; 
        _cargos.Add(liquidCargo);
    }

    public void Notify(string notification)
    {
        Console.WriteLine($"INFO ({SerialNumber}): {notification}");
        Thread.Sleep(3000);
    }
    
    public override string ToString() => $"Liquid Container: {base.ToString()}, Is Dangerous: {IsDangerous}";
    
    public override bool IsEmpty() => _cargos.Count == 0;
}