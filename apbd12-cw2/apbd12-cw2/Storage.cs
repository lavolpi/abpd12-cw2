namespace apbd12_cw2;

public class Storage
{
    public static HashSet<Container> Containers = new HashSet<Container>();
    public static HashSet<ContainerShip>  ContainerShips = new HashSet<ContainerShip>();

    public static void AddContainer(Container container)
    {
            Containers.Add(container);
    }
    

    public static void AddContainerShip(ContainerShip containerShip)
    {
        ContainerShips.Add(containerShip);
    }
    
    public static String ToStringContainers()
    {
        if (Containers.Count > 0)
        {
            String str = "";
            int i = 0;
            foreach (var container in Containers) str += ++i + ". " + container.ToString() + " \n";
            return str;
        }
        
        return "Brak";
    }

    public static String ToStringShips()
    {
        if (ContainerShips.Count > 0)
        {
            String str = "";
            int i = 0;
            foreach (var containerShip in ContainerShips) str += ++i + ". " + containerShip.ToString() + " \n";
            return str;    
        }
         
        return "Brak";
    }
}