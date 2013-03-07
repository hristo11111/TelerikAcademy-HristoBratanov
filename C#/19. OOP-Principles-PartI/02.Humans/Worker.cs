using System;
using System.Linq;

class Worker : Human
{
    public double WeekSalary { get; set; }
    public double WorkHoursPerDay { get; set; }

    public double MoneyPerHour(double weekSalary, double workHoursPerDay)
    {
        return (weekSalary / 5) / workHoursPerDay;
    }

    public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public override string ToString()
    {
        return string.Format(this.FirstName + " " + this.LastName + " money per hour: " + this.MoneyPerHour(this.WeekSalary, this.WorkHoursPerDay));
    }
}
