using Containers.Containers;
using Containers.Interfaces;

namespace Containers.UI;

public class PrintLoad : IUiOption
{
    public override string ToString() => "Print ship's load";

    public bool IsActive(ICollection<ContainerShip> ships, ICollection<Container> containers) => ships.Count > 0;

    public void Execute(ICollection<ContainerShip> ships, ICollection<Container> containers)
    {
        var shipName = ConsoleDialog.GetStringStrategy(
            $"{string.Join("\n", ships)}\nInsert ship name:\n=> ");
        var containerShip = ships.FirstOrDefault(ship => ship.ShipId == shipName);
        if (containerShip == null) return;
        Console.Write($"\n{containerShip.PrintLoad()}\n Press any key to continue...");
        Console.ReadKey(true);
    }
}