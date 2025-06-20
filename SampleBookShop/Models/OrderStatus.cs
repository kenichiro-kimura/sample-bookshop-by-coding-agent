namespace SampleBookShop.Models;

public enum OrderStatus
{
    Pending = 0,        // 発注中
    Confirmed = 1,      // 注文確定
    Processing = 2,     // 処理中
    Shipped = 3,        // 発送済み
    Delivered = 4,      // 配送完了
    Cancelled = 5       // キャンセル
}