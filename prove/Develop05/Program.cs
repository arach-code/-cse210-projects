using System;
using System.Collections;
using System.ComponentModel;

namespace GoalApp{
    class Program
    {
        static void Main()
        {
            bool IsRunning = true;
            GoalManager goalmanager = new GoalManager();
            
            while(IsRunning){
                Console.WriteLine("Total score is: " + goalmanager.score + "\n");
                goalmanager.Start();
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        goalmanager.CreateGoal();
                        break;

                    case 2:
                        goalmanager.SaveGoals();
                        break;

                    case 3:
                        goalmanager.ListGoalDetails();
                        break;
                    case 4:
                        goalmanager.LoadGoals();
                        break;

                    case 5:
                        goalmanager.RecordEvent();
                        break;

                    case 6:
                        IsRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid entry");
                        break;
                }

            }
        }
    }
        





    class GoalManager
    {
        private List<Goal> goals = new List<Goal>{};
        public int score ;


        public void Start()
        {
           
            Console.WriteLine("\nMenu options: ");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. Save Goals");
            Console.WriteLine(" 3. List Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Quit\n");
            Console.Write("Select An option from the menu: ");
                 
        }

        public void CreateGoal()
        {
            Console.WriteLine("\nThe Goal Types Are: ");
            Console.WriteLine(" 1. Simple Goal");
            Console.WriteLine(" 2. Eternal Goal");
            Console.WriteLine(" 3. Checklist Goal");

            Console.Write("\nWhat type of goal are you setting? ");
            int selected_goal = int.Parse(Console.ReadLine());
        
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description for this goal? ");
            string description = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

          

            switch (selected_goal)
            {
                case 1:
                    SimpleGoal goal = new SimpleGoal(name, description, points);
                    this.goals.Add(goal);
                    break;
            
                case 2:
                    EternalGoal goal1 = new EternalGoal(name, description, points);
                    this.goals.Add(goal1);

                    break;
            
                case 3:
                    Console.Write("How many times does this goal need to be accomplished for paying? ");
                    int times = int.Parse(Console.ReadLine());

                    Console.Write("What is the bonus for accomplishing this goal? ");
                    int bonus = int.Parse(Console.ReadLine());

                    ChecklistGoal goal2 = new ChecklistGoal(name, description, points, times, bonus);
                    this.goals.Add(goal2);
                    break;

                default:
                    Console.WriteLine("Invalid entry for type of goal");
                    break; 
            }

        }

        public void RecordEvent()
        {
            Console.Write("Which goal did you accomplish? ");
            string goalName = Console.ReadLine();   
            
            int count = 0;

           foreach (Goal goal in goals)
           {    
                count++;
                
                if(goal is SimpleGoal sm || goal is EternalGoal et){
                    if(goalName.ToLower().Trim().StartsWith(goal.Name.ToLower().Trim())) {
                            Console.WriteLine("\nCongs. You have earned " + goal.Points + " points");
                            this.score += goal.Points;
                            Console.WriteLine("\nYou now have " + this.score + " points");
                            return;
                    }
                }
                if(goal is ChecklistGoal chObject){
                    if(goalName.ToLower().Trim().StartsWith(goal.Name.ToLower().Trim())) {
                        if(chObject.AmountCompleted == chObject.target){
                            Console.WriteLine("\nCongs. You have earned " + goal.Points + " points");
                            Console.WriteLine("\nCongs. You have also earned extra " + chObject.bonus + " points in bonuses");
                            this.score += goal.Points + chObject.bonus;
                            Console.WriteLine("\nYou now have " + this.score + " points");
                            return;
                        }else{
                            
                            chObject.AmountCompleted+=1;
                            this.goals[count] = chObject;
                        }
                    }
                }
           }

            Console.WriteLine("Error: This goal was not found in your set goals");
        }


        public void SaveGoals()
        {
            Console.Write("Provide a suitable file name: ");
            string filename = Console.ReadLine() + ".txt";

            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Goal goal in goals)
                {
                    string line = goal.Name + "##" + goal.Description +"##" + goal.Points + "##" + goal.IsComplete(); 

                    if (goal is ChecklistGoal Chkobject)
                    {
                        line  = "ChecklistGoal::" + line + "##" + Chkobject.bonus + "##" +Chkobject.target +"##" + Chkobject.AmountCompleted;
                    }

                    if (goal is SimpleGoal SMobject)
                    {
                        line  = "SimpleGoal::" + line;
                    }

                    if (goal is EternalGoal Etobject)
                    {
                        line  =  "EternalGoal::" + line;
                    }

                    outputFile.WriteLine(line + "%%");
                }

                outputFile.WriteLine("Scores::" + this.score);

            }

        }


        public void LoadGoals()
        {
            Console.WriteLine("What is the file name: ");
            string filename = Console.ReadLine() + ".txt";
            string[] lines = System.IO.File.ReadAllLines(filename);


            Console.WriteLine("Your goals are: ");
            int count = 0;
            foreach (string line in lines)
            {
                string[] parts = line.Split("%%");
                string goal = parts[0];
                count++;

                string[] words;

                if(line.StartsWith("SimpleGoal")){
                    words = goal.Split("::")[1].Split("##");

                    SimpleGoal goal1 = new SimpleGoal(
                        words[0],
                        words[1],
                        int.Parse(words[2])
                    );
                    goal1.complete = bool.Parse(words[3].Trim());
                    this.goals.Add(goal1);
                }

                if(line.StartsWith("EternalGoal")){
                    words = goal.Split("::")[1].Split("##");

                    EternalGoal goal2 = new EternalGoal(
                        words[0],
                        words[1],
                        int.Parse(words[2])
                    );

                    goal2.complete = bool.Parse(words[3].Trim());

                    this.goals.Add(goal2);
                }

                if(line.StartsWith("ChecklistGoal")){
                    words = goal.Split("::")[1].Split("##");

                    ChecklistGoal goal3 = new ChecklistGoal(
                        words[0],
                        words[1],
                        int.Parse(words[2]),
                        int.Parse(words[4]),
                        int.Parse(words[5])
                    );
                    goal3.AmountCompleted = int.Parse(words[6]);
                    goal3.complete = bool.Parse(words[3].Trim());

                    this.goals.Add(goal3);
                }

                if(line.StartsWith("Scores")){
                    this.score = int.Parse(line.Split("::")[1].Trim());
                }

            }

            this.ListGoalDetails();
        }

        public void ListGoalNames()
        {

            Console.WriteLine("\n Your goals are: \n");
            int count = 0;
            foreach (Goal goal in goals)
            {
                    count++;
                    Console.WriteLine(count +". "+ goal.Name);
            }
        }

        public void ListGoalDetails()
        {
            Console.WriteLine("\n Your goals are:");
            int count = 0;
            foreach (Goal goal in this.goals)
            {
                count++;
                Console.WriteLine( count +". " + goal.GetStringPresentation());
            }

        }

        public void DisplayPlayerInfo()
        {

        }
    }




    abstract class Goal
    {
        public string Description;
        public string Name;
        public int Points;
       
        public Goal(string name, string Description, int points)
        {
            this.Name = name;
            this.Points = points;
            this.Description = Description;
        }


        
        public abstract void RecordEvent();
      
        public abstract bool  IsComplete();
       
        // public abstract string GetDetailsString();
       
        public string GetStringPresentation()
        {
            if(this.IsComplete()){
                return "[X] " + this.Name + " (" + this.Description +")";   
            }else{
                return "[] " + this.Name + " (" + this.Description +")";   
            }
        }
    
    }





    class SimpleGoal : Goal
    {
        public bool complete;
        public SimpleGoal(string Name, string Description, int Points) : base(Name, Description, Points)
        {
            
        }

        public override void RecordEvent()
        {
            this.complete = true;
        }
        public override bool  IsComplete()
        {
            return complete;
        }
    }



    class EternalGoal : Goal
    {
    
        public bool complete;

        public EternalGoal(string Name, string Description, int Points) : base(Name, Description, Points)
        {
            
        }
        
        public override void RecordEvent()
       {
           this.complete = true;
        }
        public override bool  IsComplete()
        {
            return complete;
        }

    }




    class ChecklistGoal : Goal
    {
        public int target;
        public int AmountCompleted;

        public int bonus;
        public bool complete;
    

        public ChecklistGoal(string Name, string Description, int Points, int target, int bonus) : base(Name, Description, Points)
        {
            this.target = target;
            this.bonus = bonus;
        }

        public override void RecordEvent()
        {
          this.complete = true;
        }
        public override bool  IsComplete()
        {
            return complete;
        }


        public string GetDetailsString()
        {
            return "";
        }
    }
}
    
