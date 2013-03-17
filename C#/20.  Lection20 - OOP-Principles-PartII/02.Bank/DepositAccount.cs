using System;

class DepositAccount : Account
{
    public DepositAccount(Customers customer, decimal balance)
    {
        this.Customer = customer;
        this.Balance = balance;
    }

    public override void Deposit(decimal sum)
    {
        base.Deposit(sum);
    }

    public override void Withdraw(decimal sum)
    {
        base.Withdraw(sum);
    }

    public override void CalculateInterestAmount(byte months)
    {
        if (this.Balance > 0 && this.Balance < 1000)
        {
            this.InterestAmount = 0;
        }
        else
        {
            this.InterestAmount = months * this.InterestRate;
        }
    }
}
