using SampleBookShop.Models;

namespace SampleBookShop.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> SearchBooksAsync(BookSearchRequest searchRequest);
    Task<Book?> GetBookByIdAsync(int id);
    Task<IEnumerable<Book>> GetAllBooksAsync();
}