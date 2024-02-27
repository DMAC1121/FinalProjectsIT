using System;
using System.Collections.Generic;
class BookIT
{
    static void Main(string[] args)
    {
        BookManager bookManager = new BookManager();

        while (true)
        {

            Console.WriteLine("1. axali wignis damateba");
            Console.WriteLine("2. yveal wignis naxva");
            Console.WriteLine("3. wignis modzebna satauris mixedvit");
            Console.WriteLine("4. dasruleba");

            Console.WriteLine("airchiet operacia ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("sheiyvanet wignis satauri: ");
                    string title = Console.ReadLine();
                    Console.Write("sheiyvanet wignis avtori: ");
                    string author = Console.ReadLine();
                    Console.Write("sheiyvanet gamocemis weli: ");
                    int year;
                    if (!int.TryParse(Console.ReadLine(), out year))
                    {
                        Console.WriteLine("sheiyvanet gamocemis weli sworad! ");
                        break;
                    }
                    bookManager.AddBook(title, author, year);
                    break;
                case "2":
                    Console.Write("yvela wignis chamonatvali:");
                    bookManager.ShowBooks();
                    break;
                case "3":
                    Console.Write("shiyvanet sadziebo wignis satauri: ");
                    string searchTitle = Console.ReadLine();
                    bookManager.SearchByTitle(searchTitle);
                    break;
                case "4":
                    Console.WriteLine("dasruleba");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("araswori operaciis archevani. ");
                    break;
            }
        }


    }
}


class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublicationYear { get; set; }

    public Book(string title, string author, int publicationYear)
    {
        Title = title;
        Author = author;
        PublicationYear = publicationYear;
    }

    public override string ToString()   //
    {
        return $"{Title}, avtori - {Author} ({PublicationYear} weli)";
    }
}


class BookManager
{
    private List<Book> books = new List<Book>();

    
    public void AddBook(string title, string author, int publicationYear)
    {
        Book book = new Book(title, author, publicationYear);
        books.Add(book);
        Console.WriteLine("wigni damatebulia bibliotekashi.");
    }

    
    public void ShowBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("wignebi ver moidzebna.");
            return;
        }

        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }

    
    public void SearchByTitle(string title)
    {
        bool found = false;
        foreach (var book in books)
        {
            if (book.Title.ToLower() == title.ToLower())
            {
                Console.WriteLine(book);
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("wigni ver moidzebna.");
        }
    }
}



