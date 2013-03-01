using System;

class Call
{
    public string Date { get; set; }
    private string Time { get; set; }
    private ulong dialedNumber;
    private ulong duration;

    public ulong DialedNumber
    {
        get { return this.dialedNumber; }
        set
        {
            if (this.dialedNumber < 0)
            {
                throw new ArgumentException("dialed number must be non-negative");
            }
            this.dialedNumber = value;
        }
    }

    public ulong Duration
    {
        get { return this.duration; }
        set
        {
            if (this.duration < 0)
            {
                throw new ArgumentException("duration must be non-negative");
            }
            this.duration = value;
        }

    }

    public Call(string date, string time, ulong dialedNumber, ulong duration)
    {
        this.Date = date;
        this.Time = time;
        this.DialedNumber = dialedNumber;
        this.Duration = duration;
    }

    public override string ToString()
    {
        return string.Format("date: {0}\ntime: {1}\nphone number: {2}\nduration: {3}(s)", this.Date, this.Time, this.DialedNumber, this.Duration);
    }
}
