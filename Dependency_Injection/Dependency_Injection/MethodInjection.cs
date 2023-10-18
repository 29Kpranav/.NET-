using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionCsharp
{
    public interface IAccount2
    {
        void PrintDetails();
    }

    class CurrentAccount2 : IAccount2
    {
        public void PrintDetails()
        {
            Console.WriteLine("Details Of Current Account..");
        }
    }
    class SavingAccount2 : IAccount2
    {
        public void PrintDetails()
        {
            Console.WriteLine("Details Of Saving Account..");
        }
    }

    class Account2
    {
        public void PrintAccounts(IAccount account)
        {
            account.PrintDetails();
        }
    }

    class Program2
    {
        static void Main3(string[] args)
        {
            Account2 sa = new Account2();
            sa.PrintAccounts(new SavingAccount());

            Account2 ca = new Account2();
            ca.PrintAccounts(new CurrentAccount());

            Console.ReadLine();
        }
    }
}