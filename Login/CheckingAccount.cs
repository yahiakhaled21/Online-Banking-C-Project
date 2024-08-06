using System;
namespace Bank
{

     class CheckingAccount : Account
{
    private double fees;
    public CheckingAccount(string ID, string Name, string Email, string PhoneNum, string Password, string Address, string CardNum
        , string AccountNumber, double Balance, double Fees) : base(ID, Name, Email, PhoneNum, Password, Address, CardNum, AccountNumber, Balance)
    {
        fees = Fees;
    }

    public override void Deposit(double amount)
    {
        base.Deposit(amount - fees);
    }

    public override void Withdraw(double amount)
    {
        base.Withdraw(amount + fees);
    }
}
}
