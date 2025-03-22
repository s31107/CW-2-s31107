using Containers.Containers;
using Containers.Interfaces;

namespace Containers.UI;

public class AddContainer : IUiOption
{
    public bool IsActive(ICollection<ContainerShip> ships, ICollection<Container> containers) => true;

    public void Execute(ICollection<ContainerShip> ships, ICollection<Container> containers)
    {
        string[] containersName = ["Gas Container", "Liquid Container", "RefrigeratedContainer"];
        var dialog = "";
        for (var i = 0; i < containersName.Length; i++)
        {
            dialog += $"{i} - {containersName[i]}\n";
        }
        double height, weight, depth, maximumLoad;
        var index = ConsoleDialog.GetIntStrategy($"{dialog}\n=> ", false);
        if (index > containers.Count || index < 0) return;
        switch (containersName[index])
        {
            case "Gas Container":
                BasicContainerInfo();
                containers.Add(new GasContainer(height, weight, depth, maximumLoad));
                break;
            case "Liquid Container":
                BasicContainerInfo();
                containers.Add(new LiquidContainer(height, weight, depth, maximumLoad));
                break;
            case "RefrigeratedContainer":
                BasicContainerInfo();
                containers.Add(new RefrigeratedContainer(height, weight, depth, maximumLoad, 
                    ConsoleDialog.GetDoubleStrategy("Insert temperature:\n=> ", true)));
                break;
            default:
                return;
        }
        return;
        void BasicContainerInfo()
        {
            height = ConsoleDialog.GetDoubleStrategy("Insert height:\n=> ", false);
            weight = ConsoleDialog.GetDoubleStrategy("Insert weight:\n=> ", false);
            depth = ConsoleDialog.GetDoubleStrategy("Insert depth:\n=> ", false);
            maximumLoad = ConsoleDialog.GetDoubleStrategy("Maximum load:\n=> ", false);
        }
    }

    public override string ToString() => "Add container";
}