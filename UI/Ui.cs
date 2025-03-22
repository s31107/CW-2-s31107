using Containers.Containers;
using Containers.Interfaces;

namespace Containers.UI;

public class Ui(IList<IUiOption> availableOptions)
{
    private readonly List<ContainerShip> _ships = [];
    private readonly List<Container> _containers = [];
    
    public void StartMainScreen()
    {
        var options = new Dictionary<int, IUiOption>();
        while (true)
        {
            var dialog = "Ship container's list:\n";
            dialog += $"{string.Join("\n", _ships.Select(ship => ship.ToString()))}\n";
            dialog += "Container's list:\n";
            dialog += $"{string.Join("\n", _containers.Select(container => container.ToString()))}\n";
            for (var i = 0; i < availableOptions.Count; i++)
            {
                if (!availableOptions[i].IsActive(_ships, _containers)) continue;
                dialog += $"{i}. {availableOptions[i]}\n";
                options.Add(i, availableOptions[i]);
            }

            try
            {
                options[ConsoleDialog.GetIntStrategy($"{dialog}\n=> ", false)].Execute(
                    _ships, _containers);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(3000);
            }
            options.Clear();
        }
    }
}