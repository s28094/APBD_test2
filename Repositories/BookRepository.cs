using APBD_test2.Data;
using APBD_test2.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_test2.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryContext _context;

    public BookRepository(LibraryContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync(DateTime? releaseDate = null)
    {
        var query = _context.Books
            .Include(b => b.PublishingHouse)
            .Include(b => b.BookAuthors).ThenInclude(ba => ba.Author)
            .Include(b => b.BookGenres).ThenInclude(bg => bg.Genre)
            .AsQueryable();

        if (releaseDate.HasValue)
        {
            query = query.Where(b => b.ReleaseDate == releaseDate.Value);
        }

        return await query
            .OrderByDescending(b => b.ReleaseDate)
            .ThenBy(b => b.PublishingHouse.Name)
            .ToListAsync();
    }

    public async Task AddBookAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
    }

    public async Task<PublishingHouse> GetPublishingHouseAsync(int id)
    {
        return await _context.PublishingHouses.FindAsync(id);
    }

    public async Task AddPublishingHouseAsync(PublishingHouse publishingHouse)
    {
        _context.PublishingHouses.Add(publishingHouse);
        await _context.SaveChangesAsync();
    }
}
