// See https://aka.ms/new-console-template for more information

namespace LibraryCatalogNS
{
    public record Book
    {
        //constructor to initialize the book
        public Book(string Title, string Author, string ISBN, int PublicationYear)
        {
            this.Title = Title;
            this.Author = Author;
            this.ISBN = ISBN;
            this.PublicationYear = PublicationYear;
        }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
    }

    public enum MediaType
    {
        DVD,
        CD
    }

    public class MediaItem
    {

        public MediaItem(string title, MediaType mediaType, int Duration)
        {
            Title = title;
            this.mediaType = mediaType;
            this.Duration = Duration;
        }

        public string Title { get; set; }
        public MediaType mediaType { set; get; }
        public int Duration { get; set; }
    }

    public class Library
    {

        //constructor to get the name address
        public Library(string name, string address)
        {
            Name = name;
            Addresss = address;
            books = new List<Book>();
            mediaItem = new List<MediaItem>();
        }

        public string Name { get; set; }
        public string Addresss { get; set; }
        public List<Book> books { get; set; }
        public List<MediaItem> mediaItem { get; set; }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public bool RemoveBook(Book book)
        {
            return books.Remove(book);
        }

        public void AddMediaItem(MediaItem mdItem)
        {
            mediaItem.Add(mdItem);
        }

        public bool RemoveMediaItem(MediaItem mdItem)
        {
            return mediaItem.Remove(mdItem);
        }

        public void PrintCatalog()
        {
            Console.WriteLine("books");
            foreach (var book in books)
            {
                Console.WriteLine($"Title : {book.Title} \nAuthor : {book.Author}");
            }

            Console.WriteLine("mediaItem");
            foreach (var item in mediaItem)
            {
                Console.WriteLine($"Title : {item.Title} \nMediaType : {item.mediaType} \nDuration : {item.Duration}");
            }

        }

        public Book SearchBook(string searchQuery)
        {
            //search for the title, author or isbn
            foreach (var book in books)
            {
                if (book.Title.Contains(searchQuery) || book.Author.Contains(searchQuery) || book.ISBN.Contains(searchQuery))
                {
                    return book;
                }
            }
            return null;
        }

        public MediaItem SearchMediaItem(string searchQuery)
        {
            // search for the title
            foreach (var item in mediaItem)
            {
                if (item.Title.Contains(searchQuery))
                {
                    return item;
                }
            }
            return null;
        }


    }
}

namespace Application
{
    using LibraryCatalogNS;
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("LIBRARY CATALOG");
            Console.WriteLine("Input the Name of Library");
            string name;
            string address;

            while (true)
            {
                name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    break;
                }
                Console.WriteLine("Input Correct Name Please: ");
            }

            Console.WriteLine("Input the Address of Library");
            while (true)
            {
                address = Console.ReadLine();
                if (!string.IsNullOrEmpty(address))
                {
                    break;
                }
                Console.WriteLine("Input Correct address Please: ");
            }

            Library library = new Library(name, address);

            bool quit = false;
            Console.Clear();

            while (!quit)
            {

                Console.WriteLine("Choose A Number:");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. Add Media Item");
                Console.WriteLine("4. Remove Media Item");
                Console.WriteLine("5. Print Catalog");
                Console.WriteLine("6. Search Book");
                Console.WriteLine("7. Search Media Item");
                Console.WriteLine("8. Clear");
                Console.WriteLine("9. Exit");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        while (true)
                        {
                            Console.WriteLine("Input Title Author ISBN Publication Year separated by(-)");
                            string inputbook = Console.ReadLine();
                            string[] bkSplit = inputbook.Split('-');
                            if (bkSplit.Length == 4)
                            {
                                try
                                {
                                    Book newBook = new Book(bkSplit[0], bkSplit[1], bkSplit[2], int.Parse(bkSplit[3]));
                                    Console.WriteLine($"{newBook.Title} - {newBook.Author}");
                                    library.AddBook(newBook);
                                    break;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Invalid Input");
                                }
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Input Title");
                        string title = Console.ReadLine();
                        foreach (var book in library.books)
                        {
                            if (book.Title == title)
                            {
                                library.RemoveBook(book);
                            }
                        }
                        break;
                    case 3:
                        while (true)
                        {
                            Console.WriteLine("Input Title Media Type Duration separated by(-)");
                            string inputMedia = Console.ReadLine();
                            string[] mdSplit = inputMedia.Split('-');
                            if (mdSplit.Length == 3)
                            {
                                try
                                {
                                    MediaType mdType;
                                    if (mdSplit[1] == "DVD")
                                    {
                                        mdType = MediaType.DVD;
                                    }
                                    else
                                    {
                                        mdType = MediaType.CD;
                                    }

                                    library.AddMediaItem(new MediaItem(mdSplit[0], mdType, int.Parse(mdSplit[2])));
                                    break;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Invalid Input");
                                }
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("Input Title");
                        string mdTitle = Console.ReadLine();

                        foreach (var mdItem in library.mediaItem)
                        {
                            if (mdItem.Title == mdTitle)
                            {
                                library.RemoveMediaItem(mdItem);
                            }
                        }
                        break;
                    case 5:
                        library.PrintCatalog();
                        break;
                    case 6:
                        Console.WriteLine("Search Query for Book:");
                        string bookQuery = Console.ReadLine();
                        Book bk = library.SearchBook(bookQuery);
                        if (bk != null)
                        {
                            Console.WriteLine(bk.Title);
                        }
                        break;
                    case 7:
                        Console.WriteLine("Search Query for Media Type:");
                        string mediaQuery = Console.ReadLine();
                        MediaItem md = library.SearchMediaItem(mediaQuery);
                        if (md != null)
                        {
                            Console.WriteLine(md.Title);
                        }
                        break;
                    case 8:
                        Console.Clear();
                        break;
                    case 9:
                        quit = true;
                        break;
                }

            }



        }
    }
}
