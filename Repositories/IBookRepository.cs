using APBD_test2.Models;

namespace APBD_test2.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllBooksAsync(DateTime? releaseDate = null);
    Task AddBookAsync(Book book);
    Task<PublishingHouse> GetPublishingHouseAsync(int id);
    Task AddPublishingHouseAsync(PublishingHouse publishingHouse);
}