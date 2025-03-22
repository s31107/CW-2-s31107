using Containers.Containers;

namespace Containers.Interfaces;

public interface IUiOption
{
    public bool IsActive(ICollection<ContainerShip> ships, ICollection<Container> containers);
    public void Execute(ICollection<ContainerShip> ships, ICollection<Container> containers);
}