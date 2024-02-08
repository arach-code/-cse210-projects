using Mindfulness.Activities;

class Program
{
    static void Main(string[] args)
    {   bool status = true;

        while (status)
        {
            status = Menu();
        }
    }




    static bool Menu(){
        bool Status = true;

        Console.Clear();
        Console.WriteLine("Menu options:"); 
        Console.WriteLine(" 1.Start A Breathing Activity"); 
        Console.WriteLine(" 2.Start A Listing Activity"); 
        Console.WriteLine(" 3.Start A Reflecting Activity"); 
        Console.WriteLine(" 4.Quit\n"); 
        Console.WriteLine("Make a choice from the above menu:"); 

        int option = int.Parse(Console.ReadLine());
        
        string name;
        string description;
        
        switch(option)
        {
            case 1:
                name = "Breathing Activity\n";
                description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing\n";

                BreathingActivity breathingActivity = new BreathingActivity(name, description);
                breathingActivity.DisplayStartingMessage();
                breathingActivity.Run();
                breathingActivity.DisplayEndingMessage();
                Menu();
                break;
            case 2:
                name = "Listing Activity";
                description = "Just Listing";

                ListingActivity listingActivity = new ListingActivity(name, description);
                listingActivity.DisplayStartingMessage();
                listingActivity.Run();
                listingActivity.DisplayEndingMessage();
                Console.WriteLine("You listed " + listingActivity.GetCount + " Items");
                listingActivity.ShowCountDown(5);
                Menu();
                break;

            case 3:
                name = "Reflecting Activity";
                description = "This activity will help your reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life";

                ReflectingActivity reflectingActivity = new ReflectingActivity(name, description);
                reflectingActivity.DisplayStartingMessage();
                reflectingActivity.Run();
                reflectingActivity.DisplayEndingMessage();
                Menu();
                break;

            case 4:
                Status = false;
                break;
            default:
                Console.WriteLine("Invalid choice made, please try again!!!");
                break;

        }

        return Status;
    }
}


