using System.Net.Sockets;

namespace apbd12_cw2;

public class ConsoleApp
{
    
    public ConsoleApp()
    {
        bool isRunning = true;
        Storage.Containers.Clear();
        Storage.ContainerShips.Clear();
        Console.Clear();
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("Lista dostępnych statków: ");
            Console.WriteLine(Storage.ToStringShips());
            Console.WriteLine("");
            Console.WriteLine("Lista dostępnych kontenerówców: ");
            Console.WriteLine(Storage.ToStringContainers());
            Console.WriteLine("");
            Console.WriteLine("Lista dostępnych akcji:");
            Console.WriteLine("1. Stwórz kontenerowiec");
            if(Storage.Containers.Count > 0)
                Console.WriteLine("2. Naładuj kontenerowiec");
            Console.WriteLine("3. Stwórz statek");
            if(Storage.ContainerShips.Count > 0 && Storage.Containers.Count > 0)
                Console.WriteLine("4. Zaladuj kontenerowiec na statek");
            bool anyContainer = false;
            bool anyContainer2 = false;
            int a = 0;
            foreach (ContainerShip ship in Storage.ContainerShips)
            {
                if (ship.Containers.Count > 0)
                {
                    anyContainer = true;
                    a++;
                }
            }

            if (anyContainer)
            {
                Console.WriteLine("5. Usuń kontenerowiec ze statku");
                Console.WriteLine("6. Rozładuj kontenerowiec");
                if(Storage.Containers.Count > 0) 
                    Console.Write("7. Wymień kontenerowiec");
            }
            if (a > 1)
            {
                Console.WriteLine("8. Wymiana miedzy statkami");
            }
            if(Storage.ContainerShips.Count > 0)Console.WriteLine("9. Wyświetl info o statku");
            if(Storage.Containers.Count > 0)Console.WriteLine("10. Wyświetl info o kontenerze");
            String str = Console.ReadLine();
            switch (str)
            {
                case "1":
                    Console.WriteLine("Jakiego typu ma to być kontener?");
                    Console.WriteLine("1. Liquid");
                    Console.WriteLine("2. Gas");
                    Console.WriteLine("3. Refrigerated");
                    String str2 = Console.ReadLine();
                    Console.WriteLine("Podaj Height");
                    double height = double.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj Container Mass");
                    double containerMass = double.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj Depth");
                    double depth = double.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj Max Load");
                    double maxLoad = double.Parse(Console.ReadLine());
                    switch (str2)
                    {
                        case "1":
                            Console.WriteLine("Podaj czy ładunek jest niebezpieczny");
                            String str3 = Console.ReadLine();
                            bool isDangerous;
                            switch (str3)
                            {
                                case "true":
                                    isDangerous = true;
                                    break;
                                case "false":
                                    isDangerous = false;
                                    break;
                                default:
                                    isDangerous = false;
                                    break;
                            }

                            LiquidContainer liquidContainer = new LiquidContainer(height, containerMass, depth, maxLoad,
                                isDangerous);
                            break;
                        case "2":
                            Console.WriteLine("Podaj pressure");
                            double pressure = double.Parse(Console.ReadLine());
                            GasContainer gasContainer = new GasContainer(height, containerMass, depth, maxLoad, pressure);
                            break;
                        case "3":
                            Console.WriteLine("Podaj co będzie przewożone");
                            String productType = Console.ReadLine();
                            Console.WriteLine("Podaj temperature");
                            double temperature = double.Parse(Console.ReadLine());
                            RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer(
                                height, containerMass, depth, maxLoad, productType, temperature);
                            break;
                    }
                    break;
                case "2":
                    if (Storage.Containers.Count > 0)
                    {
                        Console.WriteLine("Wybierz kontenerowiec");
                        Console.WriteLine(Storage.ToStringContainers());
                        int number = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ile załadować?");
                        double load = double.Parse(Console.ReadLine());
                        Storage.Containers.ElementAt(number-1).Fill(load);
                    }
                    break;
                case "3":
                    Console.WriteLine("Nazwa statku");
                    string name = Console.ReadLine();
                    Console.WriteLine("Predkosc statku");
                    double speed = double.Parse(Console.ReadLine());
                    Console.WriteLine("Maksymalna liczba kontenerow na statku");
                    int numbersOfShips = int.Parse(Console.ReadLine());
                    Console.WriteLine("Maks waga");
                    double mass = double.Parse(Console.ReadLine());
                    ContainerShip containerShip = new ContainerShip(name, speed,numbersOfShips,mass);
                    break;
                case "4":
                    if (Storage.ContainerShips.Count > 0 && Storage.Containers.Count > 0)
                    {
                        Console.WriteLine("Wybierz kontenerowiec");
                        Console.WriteLine(Storage.ToStringContainers());
                        int number = int.Parse(Console.ReadLine());
                        Console.WriteLine("Wybierz statek");
                        Console.WriteLine(Storage.ToStringShips());
                        int number2 = int.Parse(Console.ReadLine());
                        Storage.ContainerShips.ElementAt(number2-1).AddContainer(Storage.Containers.ElementAt(number-1));
                        Storage.Containers.Remove(Storage.Containers.ElementAt(number-1));
                    }
                    break;
                case "5":
                    if (anyContainer)
                    {
                        Console.WriteLine("Wybierz statek");
                        Console.WriteLine(Storage.ToStringShips());
                        int number = int.Parse(Console.ReadLine());
                        if (Storage.ContainerShips.ElementAt(number - 1).Containers.Count > 0)
                        {
                            Console.WriteLine("Wybierz kontenerowiec");
                            Storage.ContainerShips.ElementAt(number - 1).ShowContainers();
                            int number2 = int.Parse(Console.ReadLine());
                            string serial = Storage.ContainerShips.ElementAt(number-1).Containers.ElementAt(number2-1)
                                .SerialNumber;
                            Storage.AddContainer(Storage.ContainerShips.ElementAt(number-1).GetContainer(serial));
                            Storage.ContainerShips.ElementAt(number-1).RemoveContainer(Storage.ContainerShips.ElementAt(number-1).
                                GetContainer(serial));
                        }
                    }
                    break;
                case "6":
                    if (anyContainer)
                    {
                        Console.WriteLine("Wybierz statek");
                        Console.WriteLine(Storage.ToStringShips());
                        int number = int.Parse(Console.ReadLine());
                        if (Storage.ContainerShips.ElementAt(number - 1).Containers.Count > 0)
                        {
                            for (int i = 0; i < Storage.ContainerShips.ElementAt(number - 1).Containers.Count; i++)
                            {
                                string serial = Storage.ContainerShips.ElementAt(number-1).Containers.ElementAt(i)
                                    .SerialNumber;
                                Storage.AddContainer(Storage.ContainerShips.ElementAt(number-1).GetContainer(serial));
                            }
                            Storage.ContainerShips.ElementAt(number-1).UnloadShip();
                        }
                    }
                    break;
                case "7":
                    if (anyContainer && Storage.ContainerShips.Count > 0)
                    {
                        Console.WriteLine("Wybierz statek");
                        Console.WriteLine(Storage.ToStringShips());
                        int number = int.Parse(Console.ReadLine());
                        if (Storage.ContainerShips.ElementAt(number - 1).Containers.Count > 0)
                        {
                            Console.WriteLine("Wybierz kontenerowiec ze statku do wymiany");
                            Storage.ContainerShips.ElementAt(number - 1).ShowContainers();
                            int number2 = int.Parse(Console.ReadLine());
                            string serial1 = Storage.ContainerShips.ElementAt(number-1).Containers.ElementAt(number2-1)
                                .SerialNumber;
                            Console.WriteLine("Wybierz dostępny kontenerowiec");
                            Console.WriteLine(Storage.ToStringContainers());
                            int number3 = int.Parse(Console.ReadLine());
                            var container = Storage.Containers.ElementAt(number3 - 1);
                            Storage.Containers.Remove(container);
                            Storage.AddContainer(Storage.ContainerShips.ElementAt(number-1).GetContainer(serial1));
                            Storage.ContainerShips.ElementAt(number-1).ReplaceContainer(serial1, container);
                        }
                    }
                    break;
                case "8":
                    if (a > 1)
                    {
                        Console.WriteLine("Wybierz statek jeden");
                        Console.WriteLine(Storage.ToStringShips());
                        int number = int.Parse(Console.ReadLine());
                        var ship1 = Storage.ContainerShips.ElementAt(number - 1);
                        Console.WriteLine("Wybierz statek dwa");
                        Console.WriteLine(Storage.ToStringShips());
                        int number2 = int.Parse(Console.ReadLine());
                        var ship2 = Storage.ContainerShips.ElementAt(number2 - 1);
                        if (ship1 == ship2)
                        {
                            Console.WriteLine("Podane statki są takie same");
                            break;
                        }
                        Console.WriteLine("Wybierz kontenerowiec do przeniesienia");
                        Storage.ContainerShips.ElementAt(number - 1).ShowContainers();
                        int number3 = int.Parse(Console.ReadLine());
                        string serial1 = Storage.ContainerShips.ElementAt(number-1).Containers.ElementAt(number3-1)
                            .SerialNumber;
                        var container = Storage.ContainerShips.ElementAt(number - 1).GetContainer(serial1);
                        ContainerShip.SwitchBetween(ship1, ship2, container);
                    }
                    break;
                case "9":
                    if (Storage.ContainerShips.Count > 0)
                    {
                        Console.WriteLine("Wybierz statek");
                        Console.WriteLine(Storage.ToStringShips());
                        int number1 = int.Parse(Console.ReadLine());
                        var ship1 = Storage.ContainerShips.ElementAt(number1 - 1);
                        ship1.GetInfo();
                        Console.WriteLine("Kliknij cokolwiek by kontyunować.");
                        var whatever = Console.ReadLine();
                    }
                    break;
                case "10":
                    if (Storage.Containers.Count > 0)
                    {
                        Console.WriteLine("Wybierz kontenerowiec");
                        Console.WriteLine(Storage.ToStringContainers());
                        int number1 = int.Parse(Console.ReadLine());
                        var container = Storage.Containers.ElementAt(number1-1);
                        Console.WriteLine(container.ToString());
                        Console.WriteLine("Kliknij cokolwiek by kontyunować.");
                        var whatever = Console.ReadLine();
                    }
                    break;
                default: 
                    isRunning = false; 
                    break;
            }
        }
        
    }
}