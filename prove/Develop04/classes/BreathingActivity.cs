
namespace Mindfulness.Activities
{
  class BreathingActivity: Activity
  {
    public BreathingActivity(string name, string description): base(name, description)
    {
      
    }

    public void Run()
    {
      DateTime startTime = DateTime.Now;
      DateTime futureTime = startTime.AddSeconds(this.GetDuration);
      
      while (startTime < futureTime)
      {
        Console.Clear();
        Console.Write("Breath In...");
        this.ShowCountDown(3);
        Console.Write("\nNow breath out...");
        this.ShowCountDown(3);
        startTime = startTime.AddSeconds(6);
      }
    }
  }
}