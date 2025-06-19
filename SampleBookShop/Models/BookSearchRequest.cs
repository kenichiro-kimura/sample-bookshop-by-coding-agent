using System.ComponentModel.DataAnnotations;

namespace SampleBookShop.Models;

public class BookSearchRequest
{
    [Display(Name = "書籍名")]
    public string? Title { get; set; }
    
    [Display(Name = "著者名")]
    public string? Author { get; set; }
    
    [Display(Name = "出版社")]
    public string? Publisher { get; set; }
    
    [Display(Name = "ジャンル")]
    public string? Genre { get; set; }
    
    [Display(Name = "ISBN")]
    public string? Isbn { get; set; }
}