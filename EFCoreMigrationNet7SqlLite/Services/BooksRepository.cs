using EFCoreMigrationNet7SqlLite.DbContexts;
using EFCoreMigrationNet7SqlLite.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMigrationNet7SqlLite.Services;

public class BooksRepository : IBooksRepository
{
    private readonly BooksContext _booksContext;

    public BooksRepository(BooksContext booksContext)
    {
        _booksContext = booksContext;
    }
    public IEnumerable<Book> GetBooks()
    {
        return _booksContext.Books
            .Include(i => i.Author)
            .ToList();
    }

    public Book? GetBook(Guid id)
    {
        return _booksContext.Books
            .Include(i => i.Author)
            .FirstOrDefault(f => f.Id == id);
    }

    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        return await _booksContext.Books
            .Include(i => i.Author)
            .ToListAsync();
    }

    public async Task<Book?> GetBookAsync(Guid id)
    {
        return await _booksContext.Books
            .Include(i => i.Author)
            .FirstOrDefaultAsync(f => f.Id == id);
    }
}