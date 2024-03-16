namespace ConsoleApp1;

public static class Problem7
{
    
public enum ItemType
{
    Product,
    Ticket,
    Laptop
}

public enum SortOrder
{
    Asc,
    Desc
}

public abstract class Item : IComparable
{
    public int Id
    {
        get;
        set;
    }
    
    public string Name
    {
        get;
        set;
    }
    
    public int Price
    {
        get;
        set;
    }

    public ItemType ItemType
    {
        get;
        set;
    }

    public Item(int id, string name, int price, ItemType itemType)
    {
        Id = id;
        Name = name;
        Price = price;
        ItemType = itemType;

    }
    
    public abstract void DisplayItemType();
    
    public int CompareTo(object obj)
    {
        if (obj == null) return 1;
        Item otherItem = obj as Item;
        if (otherItem != null)
        {
            return this.Price.CompareTo(otherItem.Price);
        }
        else
        {
            throw new ArgumentException("Object is not a Item");
        }
    }
    
    public override string ToString()
    {
        return $"{this.Id} {this.Name} {this.Price} {this.ItemType}";
    }
}

public class Product : Item
{
    public DateTime ExpirationDate
    {
        get;
        set;
    }

    public Product(int id, string name, int price, ItemType itemType, DateTime expirationDate) :  base(id, name, price, itemType)
    {
        ExpirationDate = expirationDate;
    }
    
    public override void DisplayItemType()
    {
        Console.WriteLine($"This item is of type Product");
    }
    
    public override string ToString()
    {
        return $"{this.Id} {this.Name} {this.Price} {this.ItemType} {this.ExpirationDate}";
    }
}

public class Venue
{
    public int Capacity
    {
        get;
        set;
    }
    
    public string Location
    {
        get;
        set;
    }
    
    public string Name
    {
        get;
        set;
    }

    public Venue(int capacity, string location, string name)
    {
        Capacity = capacity;
        Location = location;
        Name = name;
    }

    public override string ToString()
    {
        return $"{Name} {Location} {Capacity}";
    }
}

public class Ticket : Item
{
    public Venue? Venue
    {
        get;
        set;
    }

    public string? TicketSeries
    {
        get;
        set;
    }
    
    public Ticket(int id, string name, int price, ItemType itemType, Venue venue, string ticketSeries) :  base(id, name, price, itemType)
    {
        Venue = venue;
        TicketSeries = ticketSeries;
    }
    
    public override void DisplayItemType()
    {
        Console.WriteLine($"This item is of type Ticket");
    }
    
    public override string ToString()
    {
        return $"{this.Id} {this.Name} {this.Price} {this.ItemType} {this.Venue?.ToString()} {this.TicketSeries}";
    }
}

public class Laptop : Item
{
    public Tuple<int, int>? Sizes
    {
        get;
        set;
    }

    public int Weight
    {
        get;
        set;
    }
    
    public Laptop(int id, string name, int price, ItemType itemType, Tuple<int, int> sizes, int weight) :  base(id, name, price, itemType)
    {
        Sizes = sizes;
        Weight = weight;
    }

    public override string ToString()
    {
        return $"{this.Id} {this.Name} {this.Price} {this.ItemType} {this.Sizes} {this.Weight}";
    }

    public override void DisplayItemType()
    {
        Console.WriteLine($"This item is of type Laptop");
    }
}

public class Cart
{
    public int TotalPrice
    {
        get;
        set;
    }

    public List<Item> CartItems
    {
        get;
        set;
    }

    public Cart()
    {
        TotalPrice = 0;
        CartItems = new List<Item>();
    }

    public void AddToCart(Item newItem)
    {
        CartItems.Add(newItem);
    }

    public void RemoveFromCart(int id)
    {
        foreach (Item cartItem in CartItems)
        {
            if (cartItem.Id == id)
            {
                CartItems.Remove(cartItem);
                return;
            }
        }
    }

    public void DisplayCartItems()
    {
        ComputeTotalPrice();
        Console.WriteLine($"The total price is: {TotalPrice}");
        Console.WriteLine("The items are:");
        foreach (Item cartItem in CartItems)
        {
            Console.WriteLine(cartItem.ToString());
        }
    }

    private void ComputeTotalPrice()
    {
        int s = 0;
        foreach (Item cartItem in CartItems)
        {
            s += cartItem.Price;
        }

        this.TotalPrice = s;
    }

    public void SortCartItems(SortOrder ord)
    {
        this.CartItems.Sort();
        if (ord == SortOrder.Desc)
        {
            this.CartItems.Reverse();
        }

        Console.WriteLine($"The sorted items are: ");
        foreach (Item cartItem in CartItems)
        {
                Console.WriteLine(cartItem.ToString());
        }
    } 

    public void DisplayByType(ItemType type)
    {
        Console.WriteLine($"The items of type {type} in the cart are: ");
        foreach (Item cartItem in CartItems)
        {
            if(cartItem.ItemType == type)
            {
                Console.WriteLine(cartItem.ToString());
            }
        }
    }
}




        public static void Prob7()
        {
            
            Laptop l1 = new(10001, "Acer", 1250, ItemType.Laptop, new Tuple<int, int>(20, 35), 2);
            Laptop l2 = new(10002, "Asus", 1500, ItemType.Laptop, new Tuple<int, int>(25, 30), 3);
            Laptop l3 = new(10003, "Dell", 1150, ItemType.Laptop, new Tuple<int, int>(22, 33), 1);
            Product p1 = new(10004, "Cascaval", 10, ItemType.Product,new DateTime(2024,11,10) );
            Product p2 = new(10005, "Salam", 25, ItemType.Product,new DateTime(2024,08,10) );
            Product p3 = new(10006, "Sunca", 12, ItemType.Product,new DateTime(2024,04,10) );
            Venue v1 = new Venue(400, "Bd. Magheru", "Cinema Patria");
            Venue v2 = new Venue(210, "Ion Campineanu 28", "Sala Palatului");
            Ticket t1 = new Ticket(10010, "T1", 20, ItemType.Ticket, v1, "AA100");
            Ticket t2 = new Ticket(10011, "T2", 20, ItemType.Ticket, v2, "AA101");
            Ticket t3 = new Ticket(10012, "T3", 20, ItemType.Ticket, v1, "AA102");
            Ticket t4 = new Ticket(10013, "T4", 20, ItemType.Ticket, v2, "AA103");
            Ticket t5 = new Ticket(10014, "T5", 20, ItemType.Ticket, new Venue(100, "Bd Elisabeta", "Cinema Bucuresti"), "AA104");

            Cart cart = new Cart();
            cart.AddToCart(l1);
            cart.AddToCart(l2);
            cart.AddToCart(l3);
            cart.AddToCart(p1);
            cart.AddToCart(p2);
            cart.AddToCart(p3);
            cart.AddToCart(t1);
            cart.AddToCart(t2);
            cart.AddToCart(t3);
            cart.AddToCart(t4);
            cart.AddToCart(t5);

            cart.DisplayCartItems();
            cart.RemoveFromCart(10011);
            cart.DisplayCartItems();
            cart.SortCartItems(SortOrder.Desc);
            cart.DisplayByType(ItemType.Laptop);
        }
}