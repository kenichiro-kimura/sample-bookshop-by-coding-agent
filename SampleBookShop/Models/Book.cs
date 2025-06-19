namespace SampleBookShop.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Publisher { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    public decimal Price { get; set; }
    public string Genre { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int StockQuantity { get; set; }
    public string CoverImageUrl { get; set; } = string.Empty;
}