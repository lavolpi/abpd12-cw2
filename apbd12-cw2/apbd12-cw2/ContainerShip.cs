using System.Collections.ObjectModel;

namespace apbd12_cw2;

public class ContainerShip
{
    private HashSet<Container> _containers;
    private string _shipName;
    private double _speed; //in knots
    private int _numbersOfShips; //in a container
    private double maxWeight; //in tons

    public ContainerShip(string shipName, double speed, int numbersOfShips, double maxWeight)
    {
        ShipName = shipName;
        Speed = speed;
        NumbersOfShips = numbersOfShips;
        MaxWeight = maxWeight;
        Containers = new HashSet<Container>();
        Storage.AddContainerShip(this);
    }

    public HashSet<Container> Containers
    {
        get {return _containers;} 
        set {_containers = value;}
    }

    public void ShowContainers()
    {
        int i = 0;
        foreach (var container in Containers)
        {
           Console.WriteLine($"{++i}. " + container.ToString()); 
        }
    }

    public void AddContainer(Container container)
    {
        Containers.Add(container);
    }

    public void AddContainer(ICollection<Container> containers)
    {
        foreach (var container in containers)
        {
            Containers.Add(container);
        }
    }

    public void RemoveContainer(Container container)
    {
        Containers.Remove(container);
    }

    public void UnloadShip()
    {
        if(Containers.Count > 1)
            Containers.Clear();
    }

    public void ReplaceContainer(String serialNumber, Container container)
    {
        var temp = Containers.ToList();
        foreach (var serial in temp)
        {
            if (serial.SerialNumber == serialNumber)
            {
                Containers.Remove(serial);
                Containers.Add(container);
            }
        }
    }

    public Container GetContainer(string serialNumber)
    {
        foreach (var x in Containers)
        {
            if (x.SerialNumber == serialNumber)
                return x;
        }

        return null;
    }

    public static void SwitchBetween(ContainerShip ship1, ContainerShip ship2, Container container)
    {
        if (ship1.Containers.Contains(container))
        {
            ship1.Containers.Remove(container);
            ship2.Containers.Add(container);
        }
    }

    public void GetInfo()
    {
        Console.WriteLine($"Info dla statku - Prędkość: {Speed}, Maksymalna ilość kontenerów: {NumbersOfShips}," +
                          $" Maksymalna dopuszczalna ilość masy: {MaxWeight}");
        int i = 1;
        foreach (var container in Containers)
        {
            Console.WriteLine($"Info dla kontenera {i}: {container.ToString()}");
        }
    }

    public string ToString()
    {
        return $"{ShipName} (Prędkość: {Speed} węzłów, Liczba kontenerowców: {NumbersOfShips}, Maksymalna" +
               $" waga: {MaxWeight})";
    }

    public string ShipName
    {
        get => _shipName;
        set => _shipName = value;
    }
    public double Speed
    {
        get {return _speed;}
        set
        {
            if(value < 0)
            throw new ArgumentException("Speed cannot be negative");
            _speed = value;
        }
    }

    public int NumbersOfShips
    {
        get {return _numbersOfShips;}
        set
        {
            if (value < 0)
                throw new ArgumentException("Number of ships cannot be negative");
            _numbersOfShips = value;
        }
    }
    
    public double MaxWeight
    {
        get {return maxWeight;}
        set
        {
            if(value < 0)
                throw new ArgumentException("Max weight cannot be negative");
            maxWeight = value;
        }
    }
}