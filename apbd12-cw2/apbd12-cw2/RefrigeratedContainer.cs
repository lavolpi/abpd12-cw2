namespace apbd12_cw2;

public class RefrigeratedContainer : Container
{
    private string _productType;
    private double _temperature;
    private Dictionary<String, double> _temperaturesDict = new Dictionary<String, double>
    {
        {"Bananas", 13.3},
        {"Chocolate", 18},
        {"Fish", 2},
        {"Meat", -15},
        {"Ice cream", -18},
        {"Frozen pizza", -30},
        {"Cheese", 7.2},
        {"Sausages", 5},
        {"Butter", 20.5},
        {"Eggs", 19}
    };
    public RefrigeratedContainer(double height, double containerMass, double depth, double maxLoad, string productType, 
        double temperature) 
        : base(height, containerMass, depth, maxLoad, ContainerType.Refrigerated)
    {
        if(TemperaturesDict.ContainsKey(productType))
            ProductType = productType;
        else
            throw new ArgumentException("Podany produkt nie może być przewożony.");
        
        Temperature = temperature;
        
        foreach (var key in TemperaturesDict)
        {
            if (key.Key == productType && key.Value > temperature)
            {
                Temperature = key.Value;
                Console.WriteLine($"Ustawiona temperatura statku ({temperature}) była za mała! Ustawiono minimalną" +
                                  $" temperaturę dla produktu {key.Key}.");
            }
        }
    }

    public string ProductType
    {
        get {return _productType;}
        set {_productType = value;}
        
    }

    public Dictionary<String, double> TemperaturesDict
    {
        get {return _temperaturesDict;}
    }

    public double Temperature
    {
        get {return _temperature;}
        set {_temperature = value;}
    }

    public override String ToString()
    {
        return base.ToString() + $", Załadowany produkt: {ProductType}, Temperatura: {Temperature}";
    }
}