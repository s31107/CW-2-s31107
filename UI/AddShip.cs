using Containers.Containers;
using Containers.Interfaces;

namespace Containers.UI;

public class AddShip : IUiOption
{
    public override string ToString() => "Add container ship";

    public bool IsActive(ICollection<ContainerShip> ships, ICollection<Container> containers) => true;

    public void Execute(ICollection<ContainerShip> ships, ICollection<Container> containers)
    {
        ships.Add(new ContainerShip(ConsoleDialog.GetDoubleStrategy(
            "Insert max speed:\n=> ", false), 
            ConsoleDialog.GetIntStrategy("Insert max containers number:\n=> ", false), 
            ConsoleDialog.GetDoubleStrategy(
                "Insert max containers weight:\n=> ", false)));
    }
}