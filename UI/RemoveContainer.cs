using Containers.Containers;
using Containers.Interfaces;

namespace Containers.UI;

public class RemoveContainer : IUiOption
{
    public override string ToString() => "Remove container";

    public bool IsActive(ICollection<ContainerShip> ships, ICollection<Container> containers) => containers.Count > 0;

    public void Execute(ICollection<ContainerShip> ships, ICollection<Container> containers)
    {
        var containerName = ConsoleDialog.GetStringStrategy(
            $"{string.Join("\n", containers)}\nInsert container name:\n=> ");
        var container = containers.FirstOrDefault(cont => cont.SerialNumber == containerName);
        if (container == null) return;
        containers.Remove(container);
    }
}