using System;
namespace Bank
{
    class SavingsAccount : Account
    {

        private double interestRate;
        public SavingsAccount(int ID, string Name, string Email, string PhoneNum, int Password, string Address, string CardNum
            ,string AccountNumber, double Balance, double interestRate) : base(ID, Name, Email, PhoneNum, Password, Address, CardNum, AccountNumber, Balance)
        {
            _Balance = Balance;
        }

        public double _InterestRate
        {
            get { return interestRate; }
            set { interestRate = value; }
        }

        public double CalculateInterest()
        {
            return (_InterestRate / 100) * _Balance;
        }

    }
}


