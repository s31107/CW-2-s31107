using Containers.Cargos;
using Containers.Interfaces;

namespace Containers.Containers;

public class GasContainer(double height, double containerWeight, double depth, double maximumLoad) : 
    Container(height, containerWeight, depth, maximumLoad, "G"), IHazardNotifier, ILoadable<GasCargo>
{
    private readonly List<GasCargo> _gasCargos = [];
    public double Pressure { get; private set; }
    
    public void Notify(string notification)
    {
        Console.WriteLine($"INFO ({SerialNumber}): {notification}");
        Thread.Sleep(3000);
    }

    public List<GasCargo> Unload()
    {
        UnloadStrategy();
        Weight *= 0.05;
        Pressure *= 0.05;
        var tempCargos = new List<GasCargo>(_gasCargos);
        _gasCargos.Clear();
        foreach (var gasCargo in tempCargos)
        {
            _gasCargos.Add(new GasCargo(gasCargo.CargoWeight * 0.05, gasCargo.CargoType, 
                gasCargo.Pressure * 0.05));
        }
        return tempCargos;
    }

    public void Load(GasCargo gasCargo)
    {
        LoadStrategy(gasCargo); 
        Pressure += gasCargo.Pressure; 
        _gasCargos.Add(gasCargo);
    }
    
    public override string ToString() => $"Gas Container, {base.ToString()}, Pressure: {Pressure}";

    public override bool IsEmpty() => _gasCargos.Count == 0;
}