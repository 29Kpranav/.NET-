
//SOLID principles

//1.Single responsibility principle

// Before applying SRP
public class User
{
    public void UpdateProfile() { /* ... */ }
    public void SendEmail() { /* ... */ }
}

// After applying SRP
public class UserDataManager
{
    public void UpdateProfile() { /* ... */ }
}

public class EmailNotifier
{
    public void SendEmail() { /* ... */ }
}

//2. open/closed principle

// Before applying OCP
public class Shape
{
    public virtual double Area1() { /* ... */ return 0; }
}

// After applying OCP
public abstract class Shape1
{
    public abstract double Area1();
}

public class Triangle : Shape
{
    public override double Area1() { /* ... */ return 0; }
}

//3.Liskov Substitution Principle (LSP)

// Violating LSP
public class Bird
{
    public virtual void Fly() { /* ... */ }
}

public class Penguin : Bird
{
    public override void Fly() { /* Invalid! Penguins cannot fly. */ }
}

// Adhering to LSP
public interface IFlyable
{
    void Fly();
}

public class Bird1 : IFlyable
{
    public void Fly() { /* ... */ }
}

public class Penguin1 : IFlyable
{
    public void Fly() { /* Penguins may swim, not fly. */ }
}


//4.Interface Segregation Principle (ISP):

// Violating ISP
public interface IPrinter
{
    void Print();
    void Scan();
    void Fax();
}

// Adhering to ISP
public interface IPrinter1
{
    void Print();
}

public interface IScanner
{
    void Scan();
}

public interface IFaxMachine
{
    void Fax();
}


//5.Dependency Inversion Principle (DIP):

// Violating DIP
public class ReportGenerator
{
    private readonly Database _database1;

    public ReportGenerator()
    {
        _database1 = new Database(); // Direct dependency on concrete class
    }
}

// Adhering to DIP
public interface IDatabase
{
    void GetData();
}

public class Database : IDatabase
{
    public void GetData() { /* ... */ }
}

public class ReportGenerator1
{
    private readonly IDatabase _database;

    public ReportGenerator1(IDatabase database)
    {
        _database = database; // Dependency is injected through interface
    }
}
