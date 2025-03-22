using Containers.Containers;
using Containers.Interfaces;

namespace Containers.UI;

public class UnpackContainersFromShip : IUiOption
{
    public override string ToString() => "Unpack container from ship";

    public bool IsActive(ICollection<ContainerShip> ships, ICollection<Container> containers)
    {
        return ships.FirstOrDefault(ship => !ship.IsEmpty()) != null;
    }

    public void Execute(ICollection<ContainerShip> ships, ICollection<Container> containers)
    {
        var shipName = ConsoleDialog.GetStringStrategy(
            $"{string.Join("\n", ships.Where(ship => !ship.IsEmpty()))}\nInsert ship name:\n=> ");
        var containerShip = ships.FirstOrDefault(ship => ship.ShipId == shipName);
        if (containerShip == null) return;
        var containerName = ConsoleDialog.GetStringStrategy(
            $"{containerShip.PrintLoad()}\nInsert container name:\n=> ");
        containers.Add(containerShip.RemoveContainer(containerName));
    }
}