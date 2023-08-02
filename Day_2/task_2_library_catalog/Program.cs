// See https://aka.ms/new-console-template for more information

namespace LibraryCatalogNS{
    public record Book{
        public string? Title{get; set;}
        public string? Author{get; set;}
        public string? ISBN{get; set;}
        public int PublicationYear{get; set;}
    }

    public enum MediaType{
        DVD,
        CD
    }

    public class MediaItem{
        public string? Title{get; set;}
        public MediaType mediaType{set; get;}
        public int Duration{get;set;}
    }

    public class Library{
        public string Name{get; set;}
        public string Addresss{get; set;}
        public List<Book> books{get; set;}
        public List<MediaItem> mediaItem{get; set;}

        public void AddBook(Book book){
            books.Append(book);
        }

        public bool RemoveBook(Book book){
            return books.Remove(book);
        }

        public void AddMediaItem(MediaItem mdItem){
            mediaItem.Append(mdItem);
        }

        public bool RemoveMediaItem(MediaItem mdItem){
            return mediaItem.Remove(mdItem);
        }

        
    }
}

namespace Application{
    public class Program{
        public static void Main (string[] args){

        }
    }
}
