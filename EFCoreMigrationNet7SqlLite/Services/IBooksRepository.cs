using EFCoreMigrationNet7SqlLite.Entities;

namespace EFCoreMigrationNet7SqlLite.Services;

public interface IBooksRepository
{
    IEnumerable<Book> GetBooks();
    Book? GetBook(Guid id);
    
    Task<IEnumerable<Book>> GetBooksAsync();
    Task<Book?> GetBookAsync(Guid id);
}