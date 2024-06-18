using APBD_test2.Models;

namespace APBD_test2.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllBooksAsync(DateTime? releaseDate);
    Task<Book> GetBookAsync(int id);
    Task<PublishingHouse> GetPublishingHouseAsync(int id);
    Task AddBookAsync(Book book);
    Task AddPublishingHouseAsync(PublishingHouse publishingHouse);
    Task AddBookAuthorAsync(BookAuthor bookAuthor);
    Task AddBookGenreAsync(BookGenre bookGenre);
}