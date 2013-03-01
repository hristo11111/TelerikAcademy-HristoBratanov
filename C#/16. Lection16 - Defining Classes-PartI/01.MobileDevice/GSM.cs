using System;
using System.Collections.Generic;

class GSM
{
    const float pricePerMinute = 0.37f;

    private string model;
    private string manufacturer;
    private float price;
    public string Owner { get; set; }
    public Display Display { get; set; }
    public Battery Battery { get; set; }
    public List<Call> CallHistory { get; set; }

    public static GSM Iphone4S
    {
        get
        {
            return new GSM("4S", "Apple", 1000, "Pesho", new Battery(48, 55, "asd", BatteryType.NiCd), new Display());
        }
    }

    public string Model
    {
        get { return this.model; }
        set
        {
            if (value == null)
            {
                throw new ArgumentException("model has to be non-nullable");
            }
            this.model = value;
        }
    }

    public string Manufacturer
    {
        get { return this.manufacturer; }
        set
        {
            if (value == null)
            {
                throw new ArgumentException("manufacturer has to be non-nullable");
            }
            this.manufacturer = value;
        }
    }

    public float Price
    {
        get { return this.price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("price has to be non-negative");
            }
            this.price = value;
        }
    }

    public GSM(string model, string manufacturer)
    {
        this.Model = model;
        this.Manufacturer = manufacturer;
        this.Battery = new Battery();
        this.Display = new Display();
    }

    public GSM(string model, string manufacturer, float price)
        : this(model, manufacturer)
    {
        this.Price = price;
    }
    public GSM(string model, string manufacturer, float price, string owner)
        : this(model, manufacturer, price)
    {
        this.Owner = owner;
    }

    public GSM(string model, string manufacturer, float price, string owner, Battery battery, Display display)
        : this(model, manufacturer, price, owner)
    {
        this.Battery = battery;
        this.Display = display;
    }

    //public GSM(string model, string manufacturer, decimal price, string ownerName, Display display, Battery battery, List<Call> callHistory)
    //    : this(model, manufacturer, price, ownerName, display, battery)
    //{
    //    this.callHistory = callHistory;
    //}

    public override string ToString()
    {
        return string.Format("phone\nmodel: {0}\nmanufacturer: {1}\nprice: {2}$\nowner: {3}\n\nbattery:\nmodel: {4}\nhours idle: {5}\nhours talk: {6}\ntype: {7}\n\ndisplay:\nwidht: {8}mm\nheight: {9}mm\ncolors: {10}", this.Model, this.Manufacturer, this.Price, this.Owner, this.Battery.BatteryModel, this.Battery.HoursIdle, this.Battery.HoursTalk, this.Battery.BatteryType, this.Display.Width, this.Display.Height, this.Display.Colors);
    }

    public void AddCall(Call call)
    {
        this.CallHistory.Add(call);
    }

    public void DeleteCall(Call call)
    {
        this.CallHistory.Remove(call);
    }

    public void ClearCallHistory()
    {
        this.CallHistory.Clear();
    }

    public decimal CalculateTotalPriceOfCalls(List<Call> calls)
    {
        decimal sum = 0;
        foreach (var item in calls)
	    {
            sum = sum + (decimal)(Math.Ceiling((decimal)item.Duration / 60) * (decimal)pricePerMinute);  
	    }
        return sum;
    }
}