using  JournalItems;
using System.IO;

namespace Storage 
{
    class JournalStorage
    {
        private string FilePath = "./";
        private string ItemsSeparator = "---------";
        private string LineBreak = " | ";

        public void Save(List<JournalItem> Items)
        {
            Console.WriteLine("What would you like to call your journal [Don't include file extension or special characters]");
            String Filename = Console.ReadLine();

            using (StreamWriter file =  new StreamWriter(this.FilePath + Filename + ".txt")){
                foreach (JournalItem item in Items)
                {
                    file.WriteLine("Date: " + item.Timestamp + LineBreak);
                    file.WriteLine("Prompt: " + item.Question + LineBreak);
                    file.WriteLine("Response: " + item.Response);
                    file.WriteLine("---------");
                }
            }

        }

        public List<JournalItem> Load()
        {   
            List<JournalItem>  AllItems = new List<JournalItem>(){};

            Console.WriteLine("What is your journal's filename [Don't include file extension or special characters]");
            string Filename = Console.ReadLine();

            string[] lines = System.IO.File.ReadAllLines(this.FilePath + Filename + ".txt");
            JournalItem Item = new JournalItem("", "", DateTime.Now);

            foreach (string line in lines)
            {
                if(line.StartsWith("Date:")){
                    Item.Timestamp = DateTime.Parse(line.Split(": ")[1].Trim().Replace("|", ""));
                }else if(line.StartsWith("Prompt:")){
                    Item.Question = line.Split(": ")[1].Trim().Replace("|", "");
                }else if(line.StartsWith("Response:")){
                    Item.Response = line.Split(": ")[1].Trim().Replace("|", "");
                    AllItems.Add(Item);
                }else if(line.StartsWith(this.ItemsSeparator)){
                    Item = new JournalItem("", "", DateTime.Now);
                }
            }

            return AllItems;
        }
    }

}