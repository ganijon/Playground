namespace Playground.Data
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }
}
