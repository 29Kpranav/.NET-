/*Design Patterns:
Design patterns, on the other hand, are specific solutions to recurring design problems that have been proven effective over time. 
They are more focused on actual implementations and code-level details. Design patterns provide 
concrete templates for solving certain types of problems by organizing classes and objects in a particular way. 
They can be thought of as blueprints that you can follow to solve common design challenges
*/

//1.Factory Pattern:
//The Factory Pattern provides an interface for creating objects in a super class, but allows subclasses to alter the type of objects that will be created.

public interface IProduct
{
    void Ship();
}

public class PhysicalProduct : IProduct
{
    public void Ship() { Console.WriteLine("Shipping physical product"); }
}

public class DigitalProduct : IProduct
{
    public void Ship() { Console.WriteLine("Delivering digital product"); }
}

public class ProductFactory
{
    public IProduct CreateProduct(ProductType type)
    {
        switch (type)
        {
        /*    case ProductType.Physical: return new PhysicalProduct();
            case ProductType.Digital: return new DigitalProduct();
            */
            default: throw new ArgumentException("Invalid product type");
        }
    }
}

//2.Singleton Pattern:
//The Singleton Pattern ensures that a class has only one instance and provides a global point of access to that instance.

public sealed class Singleton
{
    private static Singleton _instance;

    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Singleton();
            return _instance;
        }
    }
}

//3.Observer Pattern:
//The Observer Pattern defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.

public interface IObserver
{
    void Update(string message);
}

public class ConcreteObserver : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Received message: {message}");
    }
}

public class Subject
{
    private List<IObserver> _observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(string message)
    {
        foreach (var observer in _observers)
        {
            observer.Update(message);
        }
    }
}
