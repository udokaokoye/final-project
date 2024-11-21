namespace Final_Project.Models
{
    public class Library
    {
        public int Id { get; set; } // Primary Key
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string availableCopies { get; set; }
    }
}
