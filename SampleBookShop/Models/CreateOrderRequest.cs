using System.ComponentModel.DataAnnotations;

namespace SampleBookShop.Models;

public class CreateOrderRequest
{
    [Required(ErrorMessage = "仕入先名は必須です")]
    [Display(Name = "仕入先名")]
    public string SupplierName { get; set; } = string.Empty;
    
    [Display(Name = "仕入先連絡先")]
    public string SupplierContact { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "書籍タイトルは必須です")]
    [Display(Name = "書籍タイトル")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "著者名は必須です")]
    [Display(Name = "著者名")]
    public string Author { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "出版社名は必須です")]
    [Display(Name = "出版社")]
    public string Publisher { get; set; } = string.Empty;
    
    [Display(Name = "ISBN")]
    public string Isbn { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "単価は必須です")]
    [Range(0.01, double.MaxValue, ErrorMessage = "単価は0より大きい値を入力してください")]
    [Display(Name = "単価")]
    public decimal UnitPrice { get; set; }
    
    [Required(ErrorMessage = "数量は必須です")]
    [Range(1, int.MaxValue, ErrorMessage = "数量は1以上を入力してください")]
    [Display(Name = "数量")]
    public int Quantity { get; set; }
    
    [Display(Name = "ジャンル")]
    public string Genre { get; set; } = string.Empty;
    
    [Display(Name = "備考")]
    public string Notes { get; set; } = string.Empty;
    
    [Display(Name = "希望納期")]
    public DateTime? ExpectedDeliveryDate { get; set; }
}