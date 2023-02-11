using EFCoreMigrationNet7SqlLite.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreMigrationNet7SqlLite.Controllers;

[Route("api")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBooksRepository _booksRepository;

    public BooksController(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    [HttpGet("books")]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _booksRepository.GetBooksAsync();
        return Ok(books);
    }

    [HttpGet("books/{id}")]
    public async Task<IActionResult> GetBook(Guid id)
    {
        var book = await _booksRepository.GetBookAsync(id);
        
        return book == null ? NotFound() : Ok(book);
    }
}