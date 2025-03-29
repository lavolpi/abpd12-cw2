namespace apbd12_cw2;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool _isDangerous;
    public LiquidContainer(double height, double containerMass, double depth, double maxLoad, bool isDangerous) 
        : base(height, containerMass, depth, maxLoad, ContainerType.L)
    {
        _isDangerous = isDangerous;
    }

    public void Notify()
    {
        Console.WriteLine($"UWAGA: Próbowano podjąć niebezpieczną operację na kontenerze {SerialNumber}");
    }

    public override void Fill(double value)
    {
        double limit  = _isDangerous ? MaxLoad*0.5 : MaxLoad*0.9;
        
        if(value + LoadMass > MaxLoad)
            throw new OverfillException("UWAGA! Nastąpiła próba załadowania statku wagą większą niż dopuszczalna.");
        
        if (value + LoadMass > limit)
        {
            Notify();
            Console.WriteLine($"Próbowano naładować kontener ponad dopuszczalną masę. Ustawiono masę {limit}");
            LoadMass = limit;
        }
        else
            LoadMass += value;
    }
    
    public bool IsDangerous
    {
        get {return _isDangerous;}
        set {_isDangerous = value;}
    }

    public override String ToString()
    {
        return base.ToString() + $", Niebezpiczny ładunek: {IsDangerous})";
    }
}