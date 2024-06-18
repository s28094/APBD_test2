using APBD_test2.Dtos;
using APBD_test2.Models;
using APBD_test2.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace APBD_test2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks([FromQuery] DateTime? releaseDate)
        {
            var books = await _bookRepository.GetAllBooksAsync(releaseDate);
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookDto bookDto)
        {
            var publishingHouse = await _bookRepository.GetPublishingHouseAsync(bookDto.PublishingHouseId);

            if (publishingHouse == null)
            {
                publishingHouse = new PublishingHouse
                {
                    Id = bookDto.PublishingHouseId,
                    Name = bookDto.PublishingHouseName,
                    Country = bookDto.PublishingHouseCountry,
                    City = bookDto.PublishingHouseCity
                };

                await _bookRepository.AddPublishingHouseAsync(publishingHouse);
            }

            var book = new Book
            {
                Title = bookDto.Title,
                ReleaseDate = bookDto.ReleaseDate,
                PublishingHouseId = publishingHouse.Id
            };

            await _bookRepository.AddBookAsync(book);

            foreach (var authorId in bookDto.AuthorIds)
            {
                var bookAuthor = new BookAuthor
                {
                    BookId = book.Id,
                    AuthorId = authorId
                };

                await _bookRepository.AddBookAuthorAsync(bookAuthor);
            }

            foreach (var genreId in bookDto.GenreIds)
            {
                var bookGenre = new BookGenre
                {
                    BookId = book.Id,
                    GenreId = genreId
                };

                await _bookRepository.AddBookGenreAsync(bookGenre);
            }

            return CreatedAtAction(nameof(GetBooks), new { id = book.Id }, book);
        }
    }
}