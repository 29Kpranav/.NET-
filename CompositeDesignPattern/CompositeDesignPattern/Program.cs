using System;
using System.Collections.Generic;

// Component interface
interface IShape
{
    void Draw();
}

// Leaf (individual shape) implementations
class Circle : IShape
{
    public void Draw() => Console.WriteLine("Drawing a circle");
}

class Square : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a square");
    }
}

// Composite (group of shapes) implementation
class Group : IShape
{
    private List<IShape> shapes = new List<IShape>();

    public void AddShape(IShape shape)
    {
        shapes.Add(shape);
    }

    public void Draw()
    {
        Console.WriteLine("Drawing a group:");
        foreach (var shape in shapes)
        {
            shape.Draw();
        }
    }
}

class Program
{
    static void Main()
    {
        IShape circle = new Circle();
        IShape square = new Square();

        Group group = new Group();
        group.AddShape(circle);
        group.AddShape(square);

        Console.WriteLine("Drawing individual shapes:");
        circle.Draw();
        square.Draw();

        Console.WriteLine("\nDrawing a group of shapes:");
        group.Draw();
    }
}
