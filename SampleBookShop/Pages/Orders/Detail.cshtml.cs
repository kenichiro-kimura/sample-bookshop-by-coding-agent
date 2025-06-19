using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleBookShop.Models;
using SampleBookShop.Repositories;

namespace SampleBookShop.Pages.Orders;

public class DetailModel : PageModel
{
    private readonly IOrderRepository _orderRepository;

    public DetailModel(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Order? Order { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Order = await _orderRepository.GetOrderByIdAsync(id.Value);

        if (Order == null)
        {
            return NotFound();
        }

        return Page();
    }
}