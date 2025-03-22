using Containers;
using Containers.Cargos;
using Containers.Containers;
using Containers.UI;

// Zadanie podstawowe:
// Stworzenie kontenera danego typu:
var liquidContainer = new LiquidContainer(
    100, 20, 500, 1200);
// Załadowanie ładunku do danego kontenera:
liquidContainer.Load(new LiquidCargo(true, 300, "Woda"));
// Załadowanie kontenera na statek:
var ship = new ContainerShip(500, 20, 1200);
ship.LoadContainer(liquidContainer);
// Załadowanie listy kontenerów na statek:
var gasContainer = new GasContainer(50, 200, 30, 300);
ship.LoadAllContainers([gasContainer, 
    new RefrigeratedContainer(50, 200, 30, 400, -10.0)]);
// Usunięcie kontenera ze statku && Wypisanie informacji o danym kontenerze:
Console.WriteLine(ship.RemoveContainer(liquidContainer.SerialNumber));
// Rozładowanie kontenera:
liquidContainer.Unload().ForEach(Console.WriteLine);
// Zastąpienie kontenera na statku o danym numerze innym kontenerem:
ship.ReplaceContainer(gasContainer.SerialNumber, liquidContainer);
// Możliwość przeniesienie kontenera między dwoma statkami && Wypisanie informacji o danym statku i jego ładunku:
var ship2 = new ContainerShip(500, 20, 1200);
ship.MoveContainer(liquidContainer.SerialNumber, ship2);
Console.WriteLine(ship2);
Console.WriteLine(ship2.PrintLoad());

Thread.Sleep(3000);

// Zadanie dla chętnych:
var x = new Ui([new AddContainer(), new AddShip(), new RemoveShip(), new RemoveContainer(), 
    new PackContainerToShip(), new PrintLoad(), new UnpackContainersFromShip(), new PackAllContainers(), 
    new PackCargoToContainer(), new UnpackCargoFromContainer(), new ReplaceContainer(), new MoveContainer()]);
x.StartMainScreen();