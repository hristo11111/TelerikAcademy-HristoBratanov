using System;
using System.Collections.Generic;
using System.Linq;

class Product : IComparable
{
    private int weight;
    private int cost;
    private string name;

    public Product(string name, int weight, int cost)
    {
        this.name = name;
        this.weight = weight;
        this.cost = cost;
    }

    public int Weight
    {
        get { return this.weight; }
    }

    public int Cost
    {
        get { return this.cost; }
    }

    public string Name
    {
        get { return this.name; }
    }

    public int CompareTo(object obj)
    {
        Product other = obj as Product;

        return this.weight.CompareTo(other.weight);
    }
}
