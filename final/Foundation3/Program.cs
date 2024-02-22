using System;

// Address class to represent event addresses
class Address
{
    private string Street { get; set; }
    private string City { get; set; }
    private string State { get; set; }
    private string Country { get; set; }

    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public string GetFullAddress()
    {
        return $"{Street}, {City}, {State}, {Country}";
    }
}

// Base Event class
class Event
{
    private string EventTitle { get; set; }
    private string Description { get; set; }
    private DateTime Date { get; set; }
    private TimeSpan Time { get; set; }
    private Address EventAddress { get; set; }

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        EventTitle = title;
        Description = description;
        Date = date;
        Time = time;
        EventAddress = address;
    }

    public string GetStandardDetails()
    {
        return $"Title: {EventTitle}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nTime: {Time}\nAddress: {EventAddress.GetFullAddress()}";
    }

    public string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public string GetShortDescription()
    {
        return $"Type: Generic Event\nTitle: {EventTitle}\nDate: {Date.ToShortDateString()}";
    }
}

// Derived Lecture class
class Lecture : Event
{
    private string Speaker { get; set; }
    private int Capacity { get; set; }

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        Speaker = speaker;
        Capacity = capacity;
    }

    public new string GetFullDetails()
    {
        return $"{base.GetStandardDetails()}\nType: Lecture\nSpeaker: {Speaker}\nCapacity: {Capacity}";
    }
}

// Derived Reception class
class Reception : Event
{
    private string RsvpEmail { get; set; }

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        RsvpEmail = rsvpEmail;
    }

    public new string GetFullDetails()
    {
        return $"{base.GetStandardDetails()}\nType: Reception\nRSVP Email: {RsvpEmail}";
    }
}

// Derived OutdoorGathering class
class OutdoorGathering : Event
{
    private string WeatherStatement { get; set; }

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherStatement)
        : base(title, description, date, time, address)
    {
        WeatherStatement = weatherStatement;
    }

    public new string GetFullDetails()
    {
        return $"{base.GetStandardDetails()}\nType: Outdoor Gathering\nWeather: {WeatherStatement}";
    }
}

class Program
{
    static void Main()
    {
        // Creating addresses
        Address eventAddress = new Address("123 Main St", "Anytown", "CA", "USA");

        // Creating events of each type
        Event genericEvent = new Event("Generic Event", "A generic event description", DateTime.Now, TimeSpan.FromHours(2), eventAddress);
        Lecture lectureEvent = new Lecture("Lecture Event", "An informative lecture", DateTime.Now.AddDays(7), TimeSpan.FromHours(3), eventAddress, "John Doe", 50);
        Reception receptionEvent = new Reception("Reception Event", "A social gathering", DateTime.Now.AddDays(14), TimeSpan.FromHours(4), eventAddress, "rsvp@example.com");
        OutdoorGathering outdoorEvent = new OutdoorGathering("Outdoor Event", "A fun outdoor gathering", DateTime.Now.AddDays(21), TimeSpan.FromHours(5), eventAddress, "Weather permitting");

        // Displaying marketing messages for each event
        DisplayMarketingMessages(genericEvent);
        DisplayMarketingMessages(lectureEvent);
        DisplayMarketingMessages(receptionEvent);
        DisplayMarketingMessages(outdoorEvent);
    }

    static void DisplayMarketingMessages(Event eventInstance)
    {
        Console.WriteLine("\nMarketing Messages for Event:");
        Console.WriteLine("Standard Details:");
        Console.WriteLine(eventInstance.GetStandardDetails());

        Console.WriteLine("\nFull Details:");
        Console.WriteLine(eventInstance.GetFullDetails());

        Console.WriteLine("\nShort Description:");
        Console.WriteLine(eventInstance.GetShortDescription());
    }
}
