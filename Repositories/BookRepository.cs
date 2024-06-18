using APBD_test2.Data;
using APBD_test2.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_test2.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync(DateTime? releaseDate)
        {
            if (releaseDate.HasValue)
            {
                return await _context.Books
                    .Where(b => b.ReleaseDate == releaseDate.Value)
                    .Include(b => b.PublishingHouse)
                    .Include(b => b.BookAuthors)
                    .Include(b => b.BookGenres).ThenInclude(bg => bg.Genre)
                    .ToListAsync();
            }
            return await _context.Books
                .Include(b => b.PublishingHouse)
                .Include(b => b.BookAuthors)
                .Include(b => b.BookGenres).ThenInclude(bg => bg.Genre)
                .ToListAsync();
        }

        public async Task<Book> GetBookAsync(int id)
        {
            return await _context.Books
                .Include(b => b.PublishingHouse)
                .Include(b => b.BookAuthors)
                .Include(b => b.BookGenres).ThenInclude(bg => bg.Genre)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<PublishingHouse> GetPublishingHouseAsync(int id)
        {
            return await _context.PublishingHouses.FindAsync(id);
        }

        public async Task AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task AddPublishingHouseAsync(PublishingHouse publishingHouse)
        {
            _context.PublishingHouses.Add(publishingHouse);
            await _context.SaveChangesAsync();
        }

        public async Task AddBookAuthorAsync(BookAuthor bookAuthor)
        {
            var book = _context.Books.Find(bookAuthor.BookId);
            var author = _context.Authors.Find(bookAuthor.AuthorId);
            book.BookAuthors.Add(author);
            await _context.SaveChangesAsync();
        }

        public async Task AddBookGenreAsync(BookGenre bookGenre)
        {
            _context.BookGenres.Add(bookGenre);
            await _context.SaveChangesAsync();
        }
    }
}
