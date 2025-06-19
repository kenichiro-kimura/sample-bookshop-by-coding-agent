using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleBookShop.Models;
using SampleBookShop.Repositories;

namespace SampleBookShop.Pages;

public class SearchModel : PageModel
{
    private readonly IBookRepository _bookRepository;

    public SearchModel(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [BindProperty]
    public BookSearchRequest SearchRequest { get; set; } = new();

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        return RedirectToPage("/SearchResults", new { 
            title = SearchRequest.Title,
            author = SearchRequest.Author,
            publisher = SearchRequest.Publisher,
            genre = SearchRequest.Genre,
            isbn = SearchRequest.Isbn
        });
    }
}