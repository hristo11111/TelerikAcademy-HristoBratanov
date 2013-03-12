using System;

class MortgageAccount : Account
{
    public MortgageAccount(Customers customer, decimal balance)
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
        if (months <= 12 && this.Customer == Customers.companies)
        {
            this.InterestAmount = (months * InterestRate)/2;           
        }
        else if (months <= 6 && this.Customer == Customers.individuals)
        {
            this.InterestAmount = months * InterestRate;
        }
        else
        {
            this.InterestAmount = months * InterestRate;
        }
        
    }
}
