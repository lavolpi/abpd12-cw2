using apbd12_cw2;

//Stworzenie kontenera danego typu

LiquidContainer liquidContainer = new LiquidContainer(500, 30, 200, 200, true);
GasContainer gasContainer = new GasContainer(400, 24, 200, 500, 30);
RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer(600, 40, 300, 400,
    "Chocolate", 15);

//Załadowanie ładunku do danego kontenera

liquidContainer.Fill(150);
gasContainer.Fill(300);
refrigeratedContainer.Fill(250);

//Załadowanie kontenera na statek

ContainerShip containerShip1 = new ContainerShip("Statek 1",20, 5, 1000);
ContainerShip containerShip2 = new ContainerShip("Statek 2",30, 4, 800);

containerShip1.AddContainer(liquidContainer);

//Załadowanie listy kontenerów na statek

List<Container> containers = new List<Container>{gasContainer, refrigeratedContainer};

containerShip2.AddContainer(containers);

//Usunięcie kontenera ze statku

containerShip1.RemoveContainer(liquidContainer);

//Rozłaodwanie kontenera

containerShip2.UnloadShip();

//Zastąpienie kontenera na statku o danym numerze innym konenerem

containerShip1.AddContainer(liquidContainer);
containerShip1.ReplaceContainer("KON-Liquid-1", gasContainer);

//Możliwość przeniesienia kontenera między dwoma statkami

ContainerShip.SwitchBetween(containerShip1, containerShip2, gasContainer);

//Wypisanie informacji o danym kontenerze

Console.WriteLine(liquidContainer.ToString());

//Wypisanie informacji o danym statku i jego ładunku

containerShip2.GetInfo();

//Aplikacja konsolowa

ConsoleApp consoleApp = new ConsoleApp();