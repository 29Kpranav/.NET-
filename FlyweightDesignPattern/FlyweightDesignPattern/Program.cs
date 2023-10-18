using System;
using System.Collections.Generic;

// Flyweight interface
interface IFlyweight
{
    void Operation(int extrinsicState);
}

// Concrete Flyweight
class ConcreteFlyweight : IFlyweight
{
    private string intrinsicState;

    public ConcreteFlyweight(string intrinsicState)
    {
        this.intrinsicState = intrinsicState;
    }

    public void Operation(int extrinsicState)
    {
        Console.WriteLine($"ConcreteFlyweight: Intrinsic State: {intrinsicState}, Extrinsic State: {extrinsicState}");
    }
}

// Flyweight Factory
class FlyweightFactory
{
    private Dictionary<string, IFlyweight> flyweights = new Dictionary<string, IFlyweight>();

    public IFlyweight GetFlyweight(string key)
    {
        if (flyweights.ContainsKey(key))
        {
            return flyweights[key];
        }
        else
        {
            IFlyweight flyweight = new ConcreteFlyweight(key);
            flyweights.Add(key, flyweight);
            return flyweight;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        FlyweightFactory factory = new FlyweightFactory();

        IFlyweight flyweightA = factory.GetFlyweight("A");
        IFlyweight flyweightB = factory.GetFlyweight("B");
        IFlyweight flyweightA2 = factory.GetFlyweight("A"); // Reusing existing flyweight

        flyweightA.Operation(1); // Output: ConcreteFlyweight: Intrinsic State: A, Extrinsic State: 1
        flyweightB.Operation(2); // Output: ConcreteFlyweight: Intrinsic State: B, Extrinsic State: 2
        flyweightA2.Operation(3); // Output: ConcreteFlyweight: Intrinsic State: A, Extrinsic State: 3
    }
}
