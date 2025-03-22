using Containers.Cargos;
using Containers.Containers;
using Containers.Interfaces;

namespace Containers.UI;

public class PackCargoToContainer : IUiOption
{
    public override string ToString() => "Pack Cargo To Container";

    public bool IsActive(ICollection<ContainerShip> ships, ICollection<Container> containers) => containers.Count > 0;

    public void Execute(ICollection<ContainerShip> ships, ICollection<Container> containers)
    {
        var containerName = ConsoleDialog.GetStringStrategy(
            $"{string.Join("\n", containers)}\nInsert container name:\n=> ");
        var container = containers.FirstOrDefault(cont => cont.SerialNumber == containerName);
        switch (container)
        {
            case ILoadable<GasCargo> gasContainer:
                gasContainer.Load(new GasCargo(ConsoleDialog.GetDoubleStrategy("Insert weight:\n=> ", 
                        false), 
                    ConsoleDialog.GetStringStrategy("Insert cargo type:\n=> "), 
                    ConsoleDialog.GetDoubleStrategy("Insert pressure:\n=> ", 
                        false)));
                break;
            case ILoadable<LiquidCargo> liquidContainer:
                liquidContainer.Load(new LiquidCargo(
                    ConsoleDialog.GetIntStrategy("Insert is dangerous:\n=> ", true) == 1, 
                    ConsoleDialog.GetDoubleStrategy("Insert cargo weight:\n=> ", false), 
                    ConsoleDialog.GetStringStrategy("Insert cargo type:\n=> ")));
                break;
            case ILoadable<RefrigeratedCargo> refrigeratedContainer:
                refrigeratedContainer.Load(new RefrigeratedCargo(
                    ConsoleDialog.GetDoubleStrategy("Insert cargo weight:\n=> ", false), 
                    ConsoleDialog.GetStringStrategy("Insert cargo type:\n=> "), 
                    ConsoleDialog.GetDoubleStrategy("Insert temperature:\n=> ", true)));
                break;
        }
    }
}