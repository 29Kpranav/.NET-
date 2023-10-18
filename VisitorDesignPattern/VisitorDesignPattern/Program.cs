using System;
using System.Collections.Generic;

// Visitor interface
interface IAnimalVisitor
{
    void Visit(Cat cat);
    void Visit(Dog dog);
    void Visit(Bird bird);
}

// Concrete visitor class
class SoundVisitor : IAnimalVisitor
{
    public void Visit(Cat cat)
    {
        Console.WriteLine("Cat: Meow");
    }

    public void Visit(Dog dog)
    {
        Console.WriteLine("Dog: Woof");
    }

    public void Visit(Bird bird)
    {
        Console.WriteLine("Bird: Chirp");
    }
}

// Element interface
interface IAnimal
{
    void Accept(IAnimalVisitor visitor);
}

// Concrete element classes
class Cat : IAnimal
{
    public void Accept(IAnimalVisitor visitor)
    {
        visitor.Visit(this);
    }
}

class Dog : IAnimal
{
    public void Accept(IAnimalVisitor visitor)
    {
        visitor.Visit(this);
    }
}

class Bird : IAnimal
{
    public void Accept(IAnimalVisitor visitor)
    {
        visitor.Visit(this);
    }
}

// Object structure
class Zoo
{
    private List<IAnimal> animals = new List<IAnimal>();

    public void AddAnimal(IAnimal animal)
    {
        animals.Add(animal);
    }

    public void PerformVisitor(IAnimalVisitor visitor)
    {
        foreach (var animal in animals)
        {
            animal.Accept(visitor);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Zoo zoo = new Zoo();
        zoo.AddAnimal(new Cat());
        zoo.AddAnimal(new Dog());
        zoo.AddAnimal(new Bird());

        IAnimalVisitor soundVisitor = new SoundVisitor();
        zoo.PerformVisitor(soundVisitor);
    }
}