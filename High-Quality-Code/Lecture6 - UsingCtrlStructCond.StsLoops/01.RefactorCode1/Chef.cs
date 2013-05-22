using System;
using System.Linq;

class Chef
{
    public void Cook()
    {
        Potato potato = GetPotato();
        Peel(potato);
        Cut(potato);

        Carrot carrot = GetCarrot();
        Peel(carrot);
        Cut(carrot);

        Bowl bowl = GetBowl();
        bowl.Add(carrot);
        bowl.Add(potato);
    }

    private Potato GetPotato()
    {
        Potato potato = new Potato();

        return potato;
    }

    private Carrot GetCarrot()
    {
        Carrot carrot = new Carrot();

        return carrot;
    }

    private Bowl GetBowl()
    {
        Bowl bowl = new Bowl();

        return bowl;
    }

    private void Peel(Vegetable vegetable)
    {
    }

    private void Cut(Vegetable vegetable)
    {
    }
}

