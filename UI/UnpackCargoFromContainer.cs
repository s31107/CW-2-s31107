using Containers.Cargos;
using Containers.Containers;
using Containers.Interfaces;

namespace Containers.UI;

public class UnpackCargoFromContainer : IUiOption
{
    public override string ToString() => "Unpack cargo from container";

    public bool IsActive(ICollection<ContainerShip> ships, ICollection<Container> containers)
    {
        return containers.FirstOrDefault(container => !container.IsEmpty()) != null;
    }

    public void Execute(ICollection<ContainerShip> ships, ICollection<Container> containers)
    {
        var containerName = ConsoleDialog.GetStringStrategy(
            $"{string.Join("\n", containers.Where(
                container => !container.IsEmpty()))}\nInsert container name:\n=> ");
        var container = containers.FirstOrDefault(cont => cont.SerialNumber == containerName);
        if (container == null) return;
        var cargos = new List<Cargo>();
        switch (container)
        {
            case ILoadable<GasCargo> gasContainer:
                cargos.AddRange(gasContainer.Unload());
                break;
            case ILoadable<LiquidCargo> liquidContainer: 
                cargos.AddRange(liquidContainer.Unload());
                break;
            case ILoadable<RefrigeratedCargo> refrigeratedContainer: 
                cargos.AddRange(refrigeratedContainer.Unload());
                break;
        }
        Console.Write($"\n{string.Join("\n", cargos)}\n Press any key to continue...");
        Console.ReadKey(true);
    }
}