using System;
namespace Bank
{

    public class Account : Customer
    {
        private string accountNumber;
        private double balance;

        public Account() : base()
        {
        }

        public Account(string ID, string Name, string Email, string PhoneNum, string Password, string Address, string CardNum
            , string AccountNumber, double Balance) : base(ID, Name, Email, PhoneNum, Password, Address)
        {
            _AccountNumber = AccountNumber;
            _Balance = Balance;
        }
        public string _AccountNumber
        {
            get { return accountNumber; }
            set
            {
                //possible Exception
                if (value.Length == 16)
                    accountNumber = value;
                else
                    Console.WriteLine("Enter a valid number ");
            }
        }

        public double _Balance
        {
            get { return balance; }
            set
            {
                if (value >= 0)
                    balance = value;
            }
        }

        public virtual void Deposit(double amount)
        {
            if (amount > 0)
                _Balance += amount;
        }

        public virtual void Withdraw(double amount)
        {
            if (amount <= _Balance)
                _Balance -= amount;
            else
                Console.WriteLine("Debit amount exceeded account balance ");
        }


    }
}
