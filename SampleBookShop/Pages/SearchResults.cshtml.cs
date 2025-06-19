using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleBookShop.Models;
using SampleBookShop.Repositories;

namespace SampleBookShop.Pages;

public class SearchResultsModel : PageModel
{
    private readonly IBookRepository _bookRepository;

    public SearchResultsModel(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public IEnumerable<Book>? Books { get; set; }
    public BookSearchRequest? SearchRequest { get; set; }

    public async Task OnGetAsync(string? title, string? author, string? publisher, string? genre, string? isbn)
    {
        SearchRequest = new BookSearchRequest
        {
            Title = title,
            Author = author,
            Publisher = publisher,
            Genre = genre,
            Isbn = isbn
        };

        Books = await _bookRepository.SearchBooksAsync(SearchRequest);
    }
}