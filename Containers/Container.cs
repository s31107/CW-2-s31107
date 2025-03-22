using System.Numerics;
using Containers.Cargos;
using Containers.Exceptions;

namespace Containers.Containers;


public abstract class Container(
    double height, double containerWeight, double depth, double maximumLoad, string containerType)
{
    private static BigInteger _id = 0;
    public bool CloseContainer { get; protected internal set; }
    public double Weight { get; protected set; }
    public double Height { get; } = height;
    public double ContainerWeight { get; } = containerWeight;
    public double Depth { get; } = depth;
    public double MaximumLoad { get; } = maximumLoad;
    public string SerialNumber { get; } = $"KON-{containerType}-{_id++}";
    
    protected void LoadStrategy(Cargo cargo)
    {
        if (CloseContainer)
        {
            throw new CargoMismatchException("Container has already been loaded.");
        }
        if (Weight + cargo.CargoWeight > MaximumLoad)
        {
            throw new OverfillException("Cannot load cargo more than maximum load");
        }
        Weight += cargo.CargoWeight;
    }

    protected void UnloadStrategy()
    {
        if (CloseContainer)
        {
            throw new CargoMismatchException("Container has already been loaded.");
        }
    }

    public abstract bool IsEmpty();
    
    public override string ToString()
    {
        return $"Container: {SerialNumber}, Weight: {Weight}, Height: {Height}, ContainerWeight: {ContainerWeight}, " +
               $"Depth: {Depth}, MaximumLoad: {MaximumLoad}";
    }
}