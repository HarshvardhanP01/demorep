namespace Iterartor
{
    public interface IAgreegate<T>
    {
        IIterator<T> CreateIterator();
    }

    public interface IIterator<T>
    {
        T Next();
        T Currentitem { get; }
        bool IsDone { get;}
        T First();
    }

    public class Book
    {
        public string? Title{ get; set; }
        public string? Author { get; set; }

        public Book(string? Title, string? Author)
        {
            this.Title = Title;
            this.Author = Author;
        }

        public override string ToString()
        {
            return $"Title : {this.Title} , Author : {this.Author}";
        }
    }

    public class Library : IAgreegate<Book>
    {
        private List<Book> books = new List<Book>();
        public int count => books.Count;
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public Book GetBook(int ind)
        {
            if(ind>=0 && ind<count)
            {
                return books[ind];
            }
            return null;
        }
        public IIterator<Book> CreateIterator()
        {
            return new BookIterator(this);
        }
    }
    public class BookIterator : IIterator<Book>
    {
        private Library library;
        private int cur=0;

        public BookIterator(Library library)
        {
            this.library = library;
        }

        public Book Currentitem => library.GetBook(cur);
        public bool IsDone => cur >= library.count ? true : false;

    
        public Book First()
        {
            cur = 0;
            return library.GetBook(cur);
        }

        public Book Next()
        {
             cur++;
            if(!IsDone)
            {
                return library.GetBook(cur);
            }
            else
            {
                return null;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           Library library = new Library();
            library.AddBook(new Book("Wings of Fire", "A.P.J. Abdul Kalam")
                );
            library.AddBook(new Book("Wings of Fire", "A.P.J. Abdul Kalam")
                );
            library.AddBook(new Book("Wings of Fire", "A.P.J. Abdul Kalam")
                            );
            library.AddBook(new Book("Wings of Fire", "A.P.J. Abdul Kalam")
                            );


            IIterator<Book> iterator=library.CreateIterator();
            Console.WriteLine("Iterator");
            for(Book book=iterator.First();!iterator.IsDone;book=iterator.Next())
            {
                Console.WriteLine(book);
            }

        }
    }
}
