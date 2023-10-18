using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionCsharp
{
    public interface IAccount1
    {
        void PrintDetails();
    }

    class CurrentAccount1 : IAccount1
    {
        public void PrintDetails()
        {
            Console.WriteLine("Details Of Current Account..");
        }
    }
    class SavingAccount1 : IAccount1
    {
        public void PrintDetails()
        {
            Console.WriteLine("Details Of Saving Account..");
        }
    }

    class Account1
    {
        public IAccount account { get; set; }

        public void PrintAccounts()
        {
            account.PrintDetails();
        }
    }

    class Program1
    {
        static void Main(string[] args)
        {
            Account1 sa = new Account1();
            sa.account = new SavingAccount();
            sa.PrintAccounts();

            Account1 ca = new Account1();
            ca.account = new CurrentAccount();
            ca.PrintAccounts();

            Console.ReadLine();
        }
    }
}