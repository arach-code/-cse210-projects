namespace Mindfulness.Activities
{
  class Activity
  {
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
      this._name = name;
      this._description = description;
    }

    public int GetDuration
    {
        get { return _duration; }
    }

    public void DisplayStartingMessage()
    {
      Console.WriteLine("Welcome to the " + this._name);
      Console.WriteLine(this._description + "\n");
      Console.WriteLine("How long would you like this session to take?: ");
      this._duration = int.Parse(Console.ReadLine());

      Console.WriteLine("Get ready!");
      this.ShowCountDown(3);
    }

    public void DisplayEndingMessage()
    {
      Console.WriteLine("\nWell done!");
      this.ShowSpinner(20);
      Console.WriteLine("You have just completed " + this._duration + " seconds of the " + this._name);
      Thread.Sleep(5000);
    }

    public void ShowSpinner(int Seconds)
    {
      int initialCursorLeft = Console.CursorLeft;
      int initialCursorTop = Console.CursorTop;
      char[] spinnerChars = { '|', '/', '-', '\\' };
      for (int i = 0; i < Seconds; i++)
      {
        char spinnerChar = spinnerChars[i % spinnerChars.Length];
        Console.Write($"Processing.....{spinnerChar}\r");
        Thread.Sleep(100);
      }

      Console.SetCursorPosition(initialCursorLeft, initialCursorTop);
    }

    public void ShowCountDown(int Seconds)
    {
      for (int countdown = Seconds; countdown >= 0; countdown--)
      {
        Console.Write(countdown);
        Thread.Sleep(1000);
        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
      }
    }


    public string GetRandomString(List<string> strings)
    {
      Random random = new Random();

      if (strings.Count == 0)
        strings.AddRange(strings);

      for (int i = 0; i < strings.Count; i++)
      {
        int randomIndex = random.Next(i, strings.Count);
        string temp = strings[i];
        strings[i] = strings[randomIndex];
        strings[randomIndex] = temp;
      }

      string randomString = strings[0];
      strings.RemoveAt(0);
      return randomString;
    }
  }
}