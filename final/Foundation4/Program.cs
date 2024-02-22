using System;
using System.Collections.Generic;

class Activity
{
    private DateTime Date { get; set; }
    protected int DurationInMinutes { get; set; }

    public Activity(DateTime date, int durationInMinutes)
    {
        Date = date;
        DurationInMinutes = durationInMinutes;
    }

    public virtual double GetDistance()
    {
        return 0; // Default implementation for activities without a distance
    }

    public virtual double GetSpeed()
    {
        return 0; // Default implementation for activities without a speed
    }

    public virtual double GetPace()
    {
        return 0; // Default implementation for activities without a pace
    }

    public virtual string GetSummary()
    {
        return $"{Date.ToShortDateString()} - {GetType().Name} ({DurationInMinutes} min)";
    }
}

class Running : Activity
{
    private double Distance { get; set; }

    public Running(DateTime date, int durationInMinutes, double distance)
        : base(date, durationInMinutes)
    {
        Distance = distance;
    }

    public override double GetDistance()
    {
        return Distance;
    }

    public override double GetSpeed()
    {
        return Distance / (DurationInMinutes / 60);
    }

    public override double GetPace()
    {
        return DurationInMinutes / Distance;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {Distance} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

class Cycling : Activity
{
    private double Speed { get; set; }

    public Cycling(DateTime date, int durationInMinutes, double speed)
        : base(date, durationInMinutes)
    {
        Speed = speed;
    }

    public override double GetSpeed()
    {
        return Speed;
    }

    public override double GetPace()
    {
        return 60 / Speed;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Speed: {Speed} kph, Pace: {GetPace()} min per km";
    }
}

class Swimming : Activity
{
    private int Laps { get; set; }

    public Swimming(DateTime date, int durationInMinutes, int laps)
        : base(date, durationInMinutes)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        return Laps * 50 / 1000; // Convert meters to kilometers
    }

    public override double GetSpeed()
    {
        return GetDistance() / (DurationInMinutes / 60);
    }

    public override double GetPace()
    {
        return DurationInMinutes / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }
}

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(DateTime.Now.AddDays(-7), 30, 3.0),
            new Cycling(DateTime.Now.AddDays(-5), 45, 20.0),
            new Swimming(DateTime.Now.AddDays(-3), 60, 30)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
