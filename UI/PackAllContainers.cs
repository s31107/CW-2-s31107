using Containers.Containers;
using Containers.Interfaces;

namespace Containers.UI;

public class PackAllContainers : IUiOption
{
    public override string ToString() => "Pack all containers";

    public bool IsActive(ICollection<ContainerShip> ships, ICollection<Container> containers)
    {
        return ships.Count > 0 && containers.Count > 1;
    }

    public void Execute(ICollection<ContainerShip> ships, ICollection<Container> containers)
    {
        var shipName = ConsoleDialog.GetStringStrategy(
            $"{string.Join("\n", ships)}\nInsert ship name:\n=> ");
        var containerShip = ships.FirstOrDefault(ship => ship.ShipId == shipName);
        if (containerShip == null) return;
        foreach (var container in containers.ToList())
        {
            containerShip.LoadContainer(container);
            containers.Remove(container);
        }
    }
}