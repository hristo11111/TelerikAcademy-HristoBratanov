using System;

public enum Customers
{
    individuals,
    companies
}

abstract class Account
{
    private const decimal rate = 0.13M;

    public decimal Balance { get; protected set; }
    private decimal interestRate;
    public decimal InterestAmount { get; protected set; }
    public Customers Customer { get; protected set; }

    public decimal InterestRate
    {
        get
        {
            return this.interestRate = rate;
        }
    }

    public virtual void Deposit(decimal sum)
    {
        this.Balance += sum;
    }

    public virtual void Withdraw(decimal sum)
    {
        this.Balance -= sum;
    }

    public abstract void CalculateInterestAmount(byte months);


}
