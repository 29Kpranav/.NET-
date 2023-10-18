using System;

class Memento
{
    public string State { get; private set; }

    public Memento(string state)
    {
        State = state;
    }
}

class Originator
{
    private string _state;

    public string State
    {
        get => _state;
        set
        {
            _state = value;
            Console.WriteLine("Originator's state changed to: " + _state);
        }
    }

    public Memento SaveState()
    {
        return new Memento(_state);
    }

    public void RestoreState(Memento memento)
    {
        _state = memento.State;
        Console.WriteLine("Originator's state restored to: " + _state);
    }
}

class Caretaker
{
    public Memento Memento { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Originator originator = new Originator();
        Caretaker caretaker = new Caretaker();

        originator.State = "State1";
        caretaker.Memento = originator.SaveState();
        Memento mementoState1 = caretaker.Memento;

        originator.State = "State2";
        caretaker.Memento = originator.SaveState();
        Memento mementoState2 = caretaker.Memento;

        originator.State = "State3";
        caretaker.Memento = originator.SaveState();
        Memento mementoState3 = caretaker.Memento;

        originator.State = "State4";
        caretaker.Memento = originator.SaveState();
        Memento mementoState4 = caretaker.Memento;

        originator.RestoreState(mementoState3); // Restore to "State3"
        originator.RestoreState(mementoState2); // Restore to "State2"
        originator.RestoreState(mementoState1); // Restore to "State1"
    }
}

