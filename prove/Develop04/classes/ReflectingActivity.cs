namespace Mindfulness.Activities
{
  class ReflectingActivity: Activity
  {
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity(string name, string description): base(name, description)
    {
      this._prompts = new List<string>{
        "When you came up with a new idea about anything",
        "When you felt demotivated",
        "When you were very helpful to someone else",
        "When you were very mean to a friend",
        "When you were pround of yourself",
      };
      
      this._questions = new List<string>{
        "What is the most memorable thing about this experience?",
        "What did you learn from the experience?",
        "What would you do different basing on lessons from the experience?",
        "Who could you recommend for this activity?"
      };
    }

    public void Run()
    {
      DateTime startTime = DateTime.Now;
      DateTime futureTime = startTime.AddSeconds(this.GetDuration);
      
      this.DisplayPrompt();

      while (startTime < futureTime)
      {
        this.DisplayQuestion();
        this.ShowCountDown(6);
        startTime = startTime.AddSeconds(6);
      }
    }

    public string GetRandomPrompt()
    {
      return this.GetRandomString(this._prompts);
    }

    public string GetRandomQuestion()
    {
      return this.GetRandomString(this._questions);
    }

    public void DisplayPrompt()
    {
      Console.WriteLine("Consider the following prompt:");
      Console.WriteLine(" ---- " + this.GetRandomPrompt() + " ----\n");
      Console.WriteLine("When you have something in mind, press Enter to continue");
      Console.WriteLine("Now reflect on the following questions as the relate the experience you have in mind");
      Console.WriteLine("\nYou may begin in: ");
      this.ShowCountDown(3);
    }
   
    public void DisplayQuestion()
    {
      Console.Clear();
      Console.WriteLine(this.GetRandomQuestion());
    }
  }
}