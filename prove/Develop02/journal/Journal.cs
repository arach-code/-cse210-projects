using System;
using JournalItems;
using Storage;

namespace Journals 
{
    class Journal
    {
        public List<JournalItem> Items = new List<JournalItem>{};
        public Boolean State;   
        private List<string> Prompts = new List<string>{
            "prompt 1",
            "prompt 2",
            "prompt 3",
            "What was the most exicity activity you were involved in today?",
            "prompt 4",
            "prompt 5",
            "prompt 6",
            "What made you reflect on your life choices today?"
        };




        public void Write(JournalItem item)
        {
            this.Items.Add(item);
        }


        public void display()
        {
            foreach (JournalItem item in this.Items)
            {
                Console.WriteLine("Date: " + item.Timestamp + " - Prompt: " + item.Question + "\n" + item.Response + "\n");
            }
        }
        
        public void Quit()
        {
            this.State = false;
        }


        public void Menu()
        {
            this.State = true;
            
            while(this.State){
                Console.WriteLine("Welcome to your Journal App!\nWhat would you like to do today? \n\n1.Write\n2.Save\n3.Load\n4.Display\n5.Quit\n\n");
            
                int choice =  int.Parse(Console.ReadLine());

                JournalStorage Storage = new JournalStorage();
                JournalItem Item ;

                switch (choice)
                {
                    case 1:
                        string Prompt;
                        DateTime Date =   DateTime.Now;

                        //GET RANDOM INDEX BASING OF THE ELEMENTS IN PROMPTS
                        Random random = new Random();
                        int RandomCoice = random.Next(this.Prompts.Count);
                        Prompt = this.Prompts[RandomCoice];
                        
                        Console.WriteLine(Prompt);

                        //RETRIEVE USER RESPONSE
                        string Response =  Console.ReadLine();

                        Item = new JournalItem(
                            Prompt,
                            Response,
                            Date
                        );

                        Write(Item);

                        break;

                    case 2:
                        Storage.Save(this.Items);
                        break;

                    case 3:
                        List<JournalItem> LoadedItems = Storage.Load();
                        this.Items = LoadedItems;
                        break;

                    case 4:
                        display();
                        break;

                    case 5:
                        Quit();
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        break;
                };

            }
            
        }

    }

}