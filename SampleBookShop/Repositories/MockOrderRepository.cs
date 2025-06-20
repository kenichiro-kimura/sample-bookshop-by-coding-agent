using SampleBookShop.Models;

namespace SampleBookShop.Repositories;

public class MockOrderRepository : IOrderRepository
{
    private static List<Order> _orders = new()
    {
        new Order
        {
            Id = 1,
            OrderNumber = "ORD-2024-001",
            OrderDate = new DateTime(2024, 1, 15),
            Status = OrderStatus.Delivered,
            SupplierName = "東京書籍流通株式会社",
            SupplierContact = "03-1234-5678",
            Notes = "月例定期発注",
            ExpectedDeliveryDate = new DateTime(2024, 1, 25),
            Items = new List<OrderItem>
            {
                new OrderItem
                {
                    Id = 1,
                    OrderId = 1,
                    Title = "ソフトウェア設計の原則",
                    Author = "Robert C. Martin",
                    Publisher = "技術評論社",
                    Isbn = "978-4-7741-8001-1",
                    UnitPrice = 2800,
                    Quantity = 5,
                    Genre = "技術書"
                },
                new OrderItem
                {
                    Id = 2,
                    OrderId = 1,
                    Title = "Clean Code",
                    Author = "Robert C. Martin",
                    Publisher = "技術評論社",
                    Isbn = "978-4-7741-8001-2",
                    UnitPrice = 3200,
                    Quantity = 3,
                    Genre = "技術書"
                }
            }
        },
        new Order
        {
            Id = 2,
            OrderNumber = "ORD-2024-002",
            OrderDate = new DateTime(2024, 1, 20),
            Status = OrderStatus.Processing,
            SupplierName = "中央書店配送センター",
            SupplierContact = "06-9876-5432",
            Notes = "新刊緊急発注",
            ExpectedDeliveryDate = new DateTime(2024, 2, 5),
            Items = new List<OrderItem>
            {
                new OrderItem
                {
                    Id = 3,
                    OrderId = 2,
                    Title = "吾輩は猫である",
                    Author = "夏目漱石",
                    Publisher = "岩波書店",
                    Isbn = "978-4-00-311501-1",
                    UnitPrice = 680,
                    Quantity = 10,
                    Genre = "文学"
                }
            }
        },
        new Order
        {
            Id = 3,
            OrderNumber = "ORD-2024-003",
            OrderDate = new DateTime(2024, 1, 25),
            Status = OrderStatus.Confirmed,
            SupplierName = "関西図書配給",
            SupplierContact = "078-1111-2222",
            Notes = "お客様リクエスト対応",
            ExpectedDeliveryDate = new DateTime(2024, 2, 10),
            Items = new List<OrderItem>
            {
                new OrderItem
                {
                    Id = 4,
                    OrderId = 3,
                    Title = "料理の基本",
                    Author = "田中シェフ",
                    Publisher = "料理出版社",
                    Isbn = "978-4-12-345678-9",
                    UnitPrice = 1500,
                    Quantity = 7,
                    Genre = "料理"
                }
            }
        }
    };

    private static int _nextOrderId = 4;
    private static int _nextItemId = 5;

    public Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return Task.FromResult<IEnumerable<Order>>(_orders.OrderByDescending(o => o.OrderDate));
    }

    public Task<Order?> GetOrderByIdAsync(int id)
    {
        var order = _orders.FirstOrDefault(o => o.Id == id);
        return Task.FromResult(order);
    }

    public Task<Order> CreateOrderAsync(CreateOrderRequest request)
    {
        var order = new Order
        {
            Id = _nextOrderId++,
            OrderNumber = $"ORD-{DateTime.Now.Year}-{_nextOrderId - 1:D3}",
            OrderDate = DateTime.Now,
            Status = OrderStatus.Pending,
            SupplierName = request.SupplierName,
            SupplierContact = request.SupplierContact,
            Notes = request.Notes,
            ExpectedDeliveryDate = request.ExpectedDeliveryDate,
            Items = new List<OrderItem>
            {
                new OrderItem
                {
                    Id = _nextItemId++,
                    OrderId = _nextOrderId - 1,
                    Title = request.Title,
                    Author = request.Author,
                    Publisher = request.Publisher,
                    Isbn = request.Isbn,
                    UnitPrice = request.UnitPrice,
                    Quantity = request.Quantity,
                    Genre = request.Genre
                }
            }
        };

        _orders.Add(order);
        return Task.FromResult(order);
    }
}