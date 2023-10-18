using System;

public interface Ipizza
{
    void Prepare();
}

class BasePizza : Ipizza
{
    public void Prepare()
    {
        Console.WriteLine("Base Pizza Prepared");
    }
}

public abstract class PizzaDecortaor : Ipizza
{
    private readonly Ipizza _ipizza;

    protected PizzaDecortaor(Ipizza pizza)
    {
        _ipizza = pizza;
    }

    public virtual void Prepare()
    {
        _ipizza.Prepare();
    }
}

public class GoldenCorn : PizzaDecortaor
{
    public GoldenCorn(Ipizza pizza) : base(pizza)
    {
    }

    public override void Prepare()
    {
        base.Prepare();
        Console.WriteLine("Add GoldenCorn");
    }
}

public class Onion : PizzaDecortaor
{
    public Onion(Ipizza pizza) : base(pizza)
    {
    }

    public override void Prepare()
    {
        base.Prepare();
        Console.WriteLine("Add Onion");
    }
}

internal class Pizzawala
{
    public static void Main(string[] args)
    {
        Ipizza pi = new GoldenCorn(new BasePizza());
        pi.Prepare();

        Ipizza pi1 = new Onion(new GoldenCorn(new BasePizza()));
        pi1.Prepare();
    }
}
