namespace apbd12_cw2;

public class GasContainer : Container, IHazardNotifier
{
    private double _pressure;
    public GasContainer(double height, double containerMass, double depth, double maxLoad, double pressure) 
        : base(height, containerMass, depth, maxLoad, ContainerType.G)
    {
        Pressure = pressure;
    }

    public void Notify()
    {
        Console.WriteLine($"UWAGA: Próbowano podjąć niebezpieczną operację na kontenerze {SerialNumber}");
    }

    public override void EmptyLoad()
    {
        if (LoadMass != 0)
            LoadMass *= 0.05;
    }

    public double Pressure
    {
        get {return _pressure;}
        set {_pressure = value;}
    }

    public override String ToString()
    {
        return base.ToString() + $", Ciśnienie: {Pressure}";
    }
}