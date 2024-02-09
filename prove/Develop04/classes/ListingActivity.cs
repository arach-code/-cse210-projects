namespace Mindfulness.Activities
{
  class ListingActivity: Activity
  {
    private int _count;
    private List<string> _prompts;

    public ListingActivity(string name, string description): base(name, description)
    {
      this._prompts = new List<string>{
        "When you came up with a new idea about anything",
        "When you felt demotivated",
        "When you were very helpful to someone else",
        "When you were very mean to a friend",
        "When you were pround of yourself",
      };

    }

    public int GetCount
    {
        get { return _count; }
    }

    public void Run()
    {
      Console.WriteLine("List as many responses to the following questions as you can");
      Console.WriteLine("\n --- " + this.GetRandomPrompt() +" --- \n");
      
      this.GetListFromUser(5);
    }

    public string GetRandomPrompt()
    {
      return this.GetRandomString(this._prompts);
    }

    public List<string> GetListFromUser(int Seconds)
    {
      List<string> strings = new List<string>{}; 
      bool timeUp = false;

      Thread inputThread = new Thread(() =>
      {
        while (!timeUp)
        {
          string line = Console.ReadLine();
          if (string.IsNullOrEmpty(line))
            break;
          else
            strings.Add(line);
            this._count++;
        }
      });

      inputThread.Start();

      Thread.Sleep(Seconds * 1000);
      timeUp = true;

      inputThread.Join();

      return strings;
    }
  }
}