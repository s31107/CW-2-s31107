using System.Numerics;
using Containers.Containers;
using Containers.Exceptions;

namespace Containers;

public class ContainerShip(double maxSpeed, int maxContainersNumber, double maxContainersWeight)
{
    private readonly List<Container> _containers = [];
    private int _containersNumber;
    private double _containersWeight;
    private static BigInteger _id = 0;
    public string ShipId { get; } = $"Ship{_id++}";
    public double MaxSpeed { get; } = maxSpeed;
    public int MaxContainersNumber { get; } = maxContainersNumber;
    public double MaxContainersWeight { get; } = maxContainersWeight;

    public void LoadContainer(Container container)
    {
        if (_containersNumber == MaxContainersNumber)
        {
            throw new ShipsFullException("The max container number has been exceeded.");
        }

        if (_containersWeight + container.ContainerWeight + container.Weight > MaxContainersWeight)
        {
            throw new ShipsFullException("The max container weight has been exceeded.");
        }

        _containersWeight += container.ContainerWeight + container.Weight;
        ++_containersNumber;
        container.CloseContainer = true;
        _containers.Add(container);
    }

    public void LoadAllContainers(ICollection<Container> listOfContainers)
    {
        foreach (var container in listOfContainers)
        {
            LoadContainer(container);
        }
    }

    public Container RemoveContainer(string id)
    {
         var findContainer = _containers.Find(container => container.SerialNumber == id);
         if (findContainer == null)
         {
             throw new ArgumentException("Specified container does not exist.");
         }
         --_containersNumber;
         _containersWeight -= findContainer.ContainerWeight + findContainer.Weight;
         findContainer.CloseContainer = false;
         _containers.Remove(findContainer);
         return findContainer;
    }

    public Container ReplaceContainer(string id, Container container)
    {
        var removeContainer = RemoveContainer(id);
        try
        {
            LoadContainer(container);
        }
        catch (ShipsFullException exc)
        {
            LoadContainer(removeContainer);
            throw new ShipsFullException(exc.Message);
        }
        return removeContainer;
    }

    public void MoveContainer(string id, ContainerShip ship)
    {
        var container = RemoveContainer(id);
        try
        {
            ship.LoadContainer(container);
        }
        catch (ShipsFullException exc)
        {
            LoadContainer(container);
            throw new ShipsFullException(exc.Message);
        }
    }

    public bool IsEmpty() => _containers.Count == 0;
    
    public string PrintLoad()
    {
        return $"Container's load:\n{string.Join("\n", _containers.Select(container => container.ToString()))}";
    }
    
    public override string ToString()
    {
        return $"Container Ship: {ShipId}, Max Speed {MaxSpeed}, Max Containers Number {MaxContainersNumber}, " +
               $"Max Containers Weight {MaxContainersWeight}, Containers Number {_containersNumber}, " +
               $"Containers Weight: {_containersWeight}";
    }
}