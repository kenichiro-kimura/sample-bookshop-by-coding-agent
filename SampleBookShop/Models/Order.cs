namespace SampleBookShop.Models;

public class Order
{
    public int Id { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    public OrderStatus Status { get; set; }
    public string SupplierName { get; set; } = string.Empty;
    public string SupplierContact { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public List<OrderItem> Items { get; set; } = new();
    public decimal TotalAmount => Items.Sum(item => item.TotalPrice);
    public int TotalQuantity => Items.Sum(item => item.Quantity);
    public DateTime? ExpectedDeliveryDate { get; set; }
    
    public string StatusDisplayName => Status switch
    {
        OrderStatus.Pending => "発注中",
        OrderStatus.Confirmed => "注文確定",
        OrderStatus.Processing => "処理中", 
        OrderStatus.Shipped => "発送済み",
        OrderStatus.Delivered => "配送完了",
        OrderStatus.Cancelled => "キャンセル",
        _ => "不明"
    };
}