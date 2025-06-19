using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleBookShop.Models;
using SampleBookShop.Repositories;

namespace SampleBookShop.Pages;

public class BookDetailModel : PageModel
{
    private readonly IBookRepository _bookRepository;

    public BookDetailModel(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public Book? Book { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Book = await _bookRepository.GetBookByIdAsync(id.Value);

        if (Book == null)
        {
            return NotFound();
        }

        return Page();
    }
}