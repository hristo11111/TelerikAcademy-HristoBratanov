using System;
using System.Collections.Generic;
using System.Linq;

class Bowl
{
    private List<Vegetable> content = new List<Vegetable>();
    
    public void Add(Vegetable vegetable)
    {
        this.content.Add(vegetable);
    }
}
