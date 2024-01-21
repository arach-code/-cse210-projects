namespace JournalItems
{
    class JournalItem
    {
        public string Question;
        public string Response;
        public DateTime Timestamp;

        public JournalItem( string Question,  string Response,  DateTime Timestamp)
        {
            this.Question = Question;
            this.Response = Response;
            this.Timestamp = Timestamp;
        }
    }

}