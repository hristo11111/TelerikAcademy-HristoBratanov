using System;
using System.Collections.Generic;
using System.Linq;

class Product : IComparable
{
    private string name;
    private double price;

    public Product(string name, double price)
    {
        this.name = name;
        this.price = price;
    }

    public int CompareTo(Object product)
    {
        Product prod = product as Product;
        return this.price.CompareTo(prod.price);
    }

    public string Name
    {
        get { return this.name; }
    }

    public double Price
    {
        get { return this.price; }
    }
}
