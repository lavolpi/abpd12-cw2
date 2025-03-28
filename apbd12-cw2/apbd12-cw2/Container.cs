namespace apbd12_cw2;

public abstract class Container : OverfillException
{
    private double _loadMass; //in Kilograms
    private double _height; //in Centimeters
    private double _containerMass; //in Kilograms
    private double _depth; //in Centimeters
    private string _serialNumber; //KON-Type-UniqueNumber
    private double _maxLoad; //in Kilograms
    private static int _Id = 0;

    public enum ContainerType
    {
        Liquid,
        Gas,
        Refrigerated
    }

    protected ContainerType _containerType;
    public Container(double height, double containerMass, 
        double depth, double maxLoad, ContainerType containerType)
    {
        LoadMass = 0;
        Height = height;
        ContainerMass = containerMass;
        Depth = depth;
        _containerType = containerType;
        _serialNumber = $"KON-{_containerType}-{++_Id}";
        MaxLoad = maxLoad;
    }

    public double LoadMass
    {
        get {return _loadMass;}
        set
        {
            if(value < 0)
                throw new ArgumentException("Load mass cannot be negative");
            _loadMass = value;
        }
    }

    public double Height
    {
        get {return _height;}
        set
        {
            if(value < 0)
                throw new ArgumentException("Height cannot be negative");
            _height = value;
        }
    }

    public double ContainerMass
    {
        get {return _containerMass;}
        set
        {
            if(value < 0)
                throw new ArgumentException("Container Mass cannot be negative or lower than load mass");
            _containerMass = value;
        }
    }

    public double Depth
    {
        get {return _depth;}
        set
        {
            if(value < 0)
                throw new ArgumentException("Depth cannot be negative");
            _depth = value;
        }
    }

    public string SerialNumber
    {
        get {return _serialNumber;} 
    }

    public double MaxLoad
    {
        get {return _maxLoad;}
        set
        {
            if(value < 0)
                throw new ArgumentException("Maximum load cannot be negative");
            _maxLoad = value;
        }
    }

    public virtual void EmptyLoad()
    {
        _loadMass = 0;
    }

    public virtual void Fill(double value)
    {
        if (value + _loadMass > _maxLoad)
            throw new OverfillException("UWAGA! Nastąpiła próba załadowania statku wagą większą niż dopuszczalna.");
        _loadMass += value;
    }
    
    public virtual String ToString()
    {
        return $"{SerialNumber}, Masa: {LoadMass}, Wysokość: {Height}, Waga własna: {ContainerMass}, " +
               $"Głębokość: {Depth}, Maksymalna Ładowność: {MaxLoad}";
    }
}