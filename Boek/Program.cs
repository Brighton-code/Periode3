namespace Boek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> bookcase = new List<Book>();
            Book biggest = Book.BiggestBook(bookcase);
            Console.WriteLine(biggest.title);
            bookcase.Add(new Book("Harry Potter", 100));
            bookcase.Add(new Book("Lord of the rings", 500));

            biggest = Book.BiggestBook(bookcase);
            Console.WriteLine(biggest.title);
            Console.WriteLine(Book.TotalPages(bookcase));
            Console.WriteLine(Book.AveragePages(bookcase));
        }
    }

    internal class Book
    {
        public int pages;
        public string title;

        public static int TotalPages(List<Book> books)
        {
            int total = 0;
            foreach (Book book in books)
            {
                total += book.pages;
            }
            return total;
        }

        public static double AveragePages(List<Book> books)
        {
            int total = 0;
            foreach (Book book in books)
            {
                total += book.pages;
            }
            return total/books.Count;
        }

        public static Book BiggestBook(List<Book> books)
        {
            Book biggest = books.FirstOrDefault(new Book());
            foreach (Book book in books)
            {
                if (book.pages > biggest.pages)
                    biggest = book;
            }
            return biggest;
        }

        public Book()
        {
            pages = 0;
            title = string.Empty;
        }
        public Book(string title, int pages)
        {
            this.pages = pages;
            this.title = title;
        }
    }
}
