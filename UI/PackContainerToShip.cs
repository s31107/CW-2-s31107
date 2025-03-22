using Containers.Containers;
using Containers.Interfaces;

namespace Containers.UI;

public class PackContainerToShip : IUiOption
{
    public override string ToString() => "Pack Container";

    public bool IsActive(ICollection<ContainerShip> ships, ICollection<Container> containers) => ships.Count > 0 
        && containers.Count > 0;

    public void Execute(ICollection<ContainerShip> ships, ICollection<Container> containers)
    {
        var shipName = ConsoleDialog.GetStringStrategy(
            $"{string.Join("\n", ships)}\nInsert ship name:\n=> ");
        var containerShip = ships.FirstOrDefault(ship => ship.ShipId == shipName);
        if (containerShip == null) return;
        var containerName = ConsoleDialog.GetStringStrategy(
            $"{string.Join("\n", containers)}\nInsert container name:\n=> ");
        var container = containers.FirstOrDefault(cont => cont.SerialNumber == containerName);
        if (container == null) return;
        containerShip.LoadContainer(container);
        containers.Remove(container);
    }
}