using System;

// Abstract class (AbstractTemplate)
abstract class PizzaMaker
{
    public void MakePizza()
    {
        PrepareDough();
        AddSauce();
        AddToppings();
        BakePizza();
        Console.WriteLine("Pizza is ready!");
    }

    protected abstract void PrepareDough();
    protected abstract void AddSauce();
    protected abstract void AddToppings();
    protected abstract void BakePizza();
}

// Concrete subclass (ConcreteTemplateA)
class VeggiePizza : PizzaMaker
{
    protected override void PrepareDough()
    {
        Console.WriteLine("Preparing whole wheat dough");
    }

    protected override void AddSauce()
    {
        Console.WriteLine("Adding tomato sauce");
    }

    protected override void AddToppings()
    {
        Console.WriteLine("Adding vegetables: tomatoes, onions, peppers");
    }

    protected override void BakePizza()
    {
        Console.WriteLine("Baking at 400°C for 20 minutes");
    }
}

// Concrete subclass (ConcreteTemplateB)
class PepperoniPizza : PizzaMaker
{
    protected override void PrepareDough()
    {
        Console.WriteLine("Preparing regular dough");
    }

    protected override void AddSauce()
    {
        Console.WriteLine("Adding marinara sauce");
    }

    protected override void AddToppings()
    {
        Console.WriteLine("Adding pepperoni slices");
    }

    protected override void BakePizza()
    {
        Console.WriteLine("Baking at 350°C for 15 minutes");
    }
}

class Program
{
    static void Main5(string[] args)
    {
        PizzaMaker veggiePizza = new VeggiePizza();
        veggiePizza.MakePizza();

        Console.WriteLine();

        PizzaMaker pepperoniPizza = new PepperoniPizza();
        pepperoniPizza.MakePizza();
    }
}

