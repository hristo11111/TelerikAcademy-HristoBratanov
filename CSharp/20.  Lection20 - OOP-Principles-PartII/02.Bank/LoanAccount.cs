using System;

class LoanAccount : Account
{
    public LoanAccount(Customers customer, decimal balance)
    {
        this.Customer = customer;
        this.Balance = balance;
    }

    public override void Deposit(decimal sum)
    {
        base.Deposit(sum);
    }

    public override void CalculateInterestAmount(byte months)
    {
        if (months <= 3 && this.Customer == Customers.individuals)
        {
            this.InterestAmount = 0;
        }
        else if (months <= 2 && this.Customer == Customers.companies)
        {
            this.InterestAmount = 0;
        }
        else
        {
            this.InterestAmount = months * InterestRate;
        }
    }
}
