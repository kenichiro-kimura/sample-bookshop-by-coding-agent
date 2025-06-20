using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleBookShop.Models;
using SampleBookShop.Repositories;

namespace SampleBookShop.Pages.Orders;

public class CreateModel : PageModel
{
    private readonly IOrderRepository _orderRepository;

    public CreateModel(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    [BindProperty]
    public CreateOrderRequest OrderRequest { get; set; } = new();

    public void OnGet()
    {
        // 初期値設定
        OrderRequest.ExpectedDeliveryDate = DateTime.Now.AddDays(14);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            await _orderRepository.CreateOrderAsync(OrderRequest);
            TempData["SuccessMessage"] = "発注が正常に完了しました。";
            return RedirectToPage("/Orders/Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "発注処理中にエラーが発生しました: " + ex.Message);
            return Page();
        }
    }
}