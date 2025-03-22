using Containers.Containers;
using Containers.Interfaces;

namespace Containers.UI;

public class MoveContainer : IUiOption
{
    public override string ToString() => "Move container";

    public bool IsActive(ICollection<ContainerShip> ships, ICollection<Container> containers)
    {
        return ships.Count > 1 && ships.FirstOrDefault(ship => !ship.IsEmpty()) != null;
    }

    public void Execute(ICollection<ContainerShip> ships, ICollection<Container> containers)
    {
        var sourceShipName = ConsoleDialog.GetStringStrategy(
            $"{string.Join("\n", ships.Where(ship => !ship.IsEmpty()))}\nInsert source ship name:\n=> ");
        var sourceContainerShip = ships.FirstOrDefault(ship => ship.ShipId == sourceShipName);
        if (sourceContainerShip == null) return;
        
        var destinationShipName = ConsoleDialog.GetStringStrategy(
            $"{string.Join("\n", ships.Where(
                ship => ship != sourceContainerShip))}\nInsert destination ship name:\n=> ");
        var destinationContainerShip = ships.FirstOrDefault(ship => ship.ShipId == destinationShipName);
        if (destinationContainerShip == null) return;
        var containerName = ConsoleDialog.GetStringStrategy(
            $"{sourceContainerShip.PrintLoad()}\nInsert container name:\n=> ");
        sourceContainerShip.MoveContainer(containerName, destinationContainerShip);
    }
}