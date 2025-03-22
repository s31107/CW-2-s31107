using Containers.Containers;
using Containers.Interfaces;
using Containers.Exceptions;

namespace Containers.UI;

public class ReplaceContainer : IUiOption
{
    public override string ToString() => "Replace container";

    public bool IsActive(ICollection<ContainerShip> ships, ICollection<Container> containers)
    {
        return containers.Count > 0 && ships.FirstOrDefault(ship => !ship.IsEmpty()) != null;
    }

    public void Execute(ICollection<ContainerShip> ships, ICollection<Container> containers)
    {
        var shipName = ConsoleDialog.GetStringStrategy(
            $"{string.Join("\n", ships)}\nInsert ship name:\n=> ");
        var containerShip = ships.FirstOrDefault(ship => ship.ShipId == shipName);
        if (containerShip == null) return;
        var containerName = ConsoleDialog.GetStringStrategy(
            $"{string.Join("\n", containers)}\nInsert replacement container name:\n=> ");
        var container = containers.FirstOrDefault(cont => cont.SerialNumber == containerName);
        if (container == null) return;
        var shippedContainerName = ConsoleDialog.GetStringStrategy(
            $"{containerShip.PrintLoad()}\nInsert container name to be replaced:\n=> ");
        containers.Add(containerShip.ReplaceContainer(shippedContainerName, container));
        containers.Remove(container);
    }
}