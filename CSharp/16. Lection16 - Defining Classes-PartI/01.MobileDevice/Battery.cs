using System;

public enum BatteryType
{
    Li_ion,
    NiMH,
    NiCd
}

class Battery
{
    private string batteryModel;
    private int hoursIdle;
    private int hoursTalk;
    private BatteryType? batteryType;

    public string BatteryModel
    {
        get { return this.batteryModel; }
        set
        {
            if (this.batteryModel == null)
            {
                throw new ArgumentException("model had to be non-nullable");
            }
            this.batteryModel = value;
        }
    }

    public int HoursIdle
    {
        get { return this.hoursIdle; }
        set
        {
            if (this.hoursIdle < 0)
            {
                throw new ArgumentException("hours idle has to be non-negative");
            }
            this.hoursIdle = value;
        }
    }

    public int HoursTalk
    {
        get { return this.hoursTalk; }
        set
        {
            if (this.hoursTalk < 0)
            {
                throw new ArgumentException("hours talk has to be non-negative");
            }
            this.hoursTalk = value;
        }
    }

    public BatteryType? BatteryType
    {
        get { return this.batteryType; }
        set { this.batteryType = value; }
    }

    public Battery()
    {
    }

    public Battery(string model)
        : this()
    {
        this.batteryModel = model;
    }

    public Battery(int hoursIdle, int hoursTalk, string model)
        : this(model)
    {
        this.hoursIdle = hoursIdle;
        this.hoursTalk = hoursTalk;
    }

    public Battery(int hoursIdle, int hoursTalk, string model, BatteryType batteryType)
        : this(hoursIdle, hoursTalk, model)
    {
        this.batteryType = batteryType;
    }
}

