namespace Prototype_Pattern
{
    public interface IPrototype<T>
    {
        T Clone();
    }

    public class Book : IPrototype<Book>
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }

        public Book(string title,string author,string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }

        public override string ToString()
        {
            return $"Book : [Title : {Title} , Author : {Author}] , ISBN : {ISBN}]";
        }
        public Book? Clone()
        {
            return this.MemberwiseClone() as Book;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Book o = new Book("CLR via C#", "Jeffrey Richter", "978-073-566-8768");
            Console.WriteLine($"Original Book : {o}");
            Book cloneBook= o.Clone();
            
            Console.WriteLine($"Before : Cloned : 1 Book : {cloneBook}");
            cloneBook.Title = "Object Oriented Programming Through CPP";
            cloneBook.Author = "Balaguruswami";
            cloneBook.ISBN = "546-754-349-8124";
            Console.WriteLine($"After : Cloned : 1 Book : {cloneBook}");


            Book cloneBook1 = o.Clone();
            Console.WriteLine($"Cloned : 2 Book : {cloneBook1}");

        }
    }
}
