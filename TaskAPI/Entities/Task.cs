namespace TaskAPI.Entities
{
    public class Task
    {
        public int id  { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public string creationDate { get; set; }

        public string statusUpdateDate { get; set; }

        public string author { get; set; }

        public string condition { get; set; }
    }
}
