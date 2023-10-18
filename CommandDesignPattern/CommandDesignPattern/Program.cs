namespace commandDesignPattern
{
    interface ICommand
    {
        void Execute();
    }

    class ConcreteCommand : ICommand
    {
        private Receiver receiver;

        public ConcreteCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public void Execute()
        {
            receiver.PerformAction();
        }
    }

    class Receiver
    {
        public void PerformAction()
        {
            Console.WriteLine("Receiver is performing an action.");
        }
    }

    class Invoker
    {
        private ICommand command;

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void ExecuteCommand()
        {
            command.Execute();
        }
    }

    class Client
    {
        static void Main(string[] args)
        {
            Receiver receiver = new Receiver();
            ICommand command = new ConcreteCommand(receiver);

            Invoker invoker = new Invoker();
            invoker.SetCommand(command);

            invoker.ExecuteCommand();
        }
    }


}

//the ConcreteCommand encapsulates the action to be performed and references the Receiver object that carries
//out the action. The Invoker is responsible for invoking the command's Execute() method. The Client creates
//instances of the Receiver, ConcreteCommand, and Invoker, and ties them together to demonstrate the Command Design Pattern in action.