using SampleBookShop.Models;

namespace SampleBookShop.Repositories;

public class MockBookRepository : IBookRepository
{
    private static readonly List<Book> _books = new()
    {
        new Book
        {
            Id = 1,
            Title = "吾輩は猫である",
            Author = "夏目漱石",
            Publisher = "岩波書店",
            Isbn = "978-4-00-311401-0",
            PublishedDate = new DateTime(1906, 1, 1),
            Price = 1200,
            Genre = "文学",
            Description = "夏目漱石の代表的な長編小説。猫の視点から人間社会を風刺的に描いた名作です。",
            StockQuantity = 15,
            CoverImageUrl = "/images/neko.jpg"
        },
        new Book
        {
            Id = 2,
            Title = "こころ",
            Author = "夏目漱石",
            Publisher = "新潮社",
            Isbn = "978-4-10-101006-4",
            PublishedDate = new DateTime(1914, 9, 1),
            Price = 880,
            Genre = "文学",
            Description = "明治の終わりから大正にかけての時代背景の中で、人間の心の葛藤を描いた傑作小説。",
            StockQuantity = 8,
            CoverImageUrl = "/images/kokoro.jpg"
        },
        new Book
        {
            Id = 3,
            Title = "坊っちゃん",
            Author = "夏目漱石",
            Publisher = "角川書店",
            Isbn = "978-4-04-101201-1",
            PublishedDate = new DateTime(1906, 4, 1),
            Price = 680,
            Genre = "文学",
            Description = "江戸っ子気質の主人公が四国の中学校で繰り広げる痛快な物語。",
            StockQuantity = 12,
            CoverImageUrl = "/images/botchan.jpg"
        },
        new Book
        {
            Id = 4,
            Title = "人間失格",
            Author = "太宰治",
            Publisher = "新潮社",
            Isbn = "978-4-10-100601-2",
            PublishedDate = new DateTime(1948, 6, 25),
            Price = 770,
            Genre = "文学",
            Description = "太宰治の代表作。人間としての資格を失ったと感じる主人公の内面を描いた問題作。",
            StockQuantity = 6,
            CoverImageUrl = "/images/ningen.jpg"
        },
        new Book
        {
            Id = 5,
            Title = "走れメロス",
            Author = "太宰治",
            Publisher = "岩波書店",
            Isbn = "978-4-00-311501-7",
            PublishedDate = new DateTime(1940, 5, 1),
            Price = 550,
            Genre = "文学",
            Description = "友情と信頼をテーマにした太宰治の短編小説の名作。",
            StockQuantity = 20,
            CoverImageUrl = "/images/melos.jpg"
        },
        new Book
        {
            Id = 6,
            Title = "プログラミング入門",
            Author = "田中太郎",
            Publisher = "技術評論社",
            Isbn = "978-4-77-418001-3",
            PublishedDate = new DateTime(2023, 3, 15),
            Price = 2800,
            Genre = "技術書",
            Description = "初心者向けのプログラミング学習書。C#とJavaScriptの基礎から応用まで解説。",
            StockQuantity = 25,
            CoverImageUrl = "/images/programming.jpg"
        },
        new Book
        {
            Id = 7,
            Title = "日本の歴史",
            Author = "山田花子",
            Publisher = "中央公論新社",
            Isbn = "978-4-12-101801-9",
            PublishedDate = new DateTime(2022, 8, 10),
            Price = 1980,
            Genre = "歴史",
            Description = "古代から現代まで、日本の歴史を分かりやすく解説した総合的な歴史書。",
            StockQuantity = 18,
            CoverImageUrl = "/images/history.jpg"
        },
        new Book
        {
            Id = 8,
            Title = "料理の基本",
            Author = "佐藤春美",
            Publisher = "主婦の友社",
            Isbn = "978-4-07-285001-4",
            PublishedDate = new DateTime(2023, 1, 20),
            Price = 1650,
            Genre = "実用書",
            Description = "家庭料理の基本テクニックとレシピを豊富な写真で紹介する実用書。",
            StockQuantity = 14,
            CoverImageUrl = "/images/cooking.jpg"
        }
    };

    public Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return Task.FromResult<IEnumerable<Book>>(_books);
    }

    public Task<Book?> GetBookByIdAsync(int id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        return Task.FromResult(book);
    }

    public Task<IEnumerable<Book>> SearchBooksAsync(BookSearchRequest searchRequest)
    {
        var query = _books.AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchRequest.Title))
        {
            query = query.Where(b => b.Title.Contains(searchRequest.Title, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(searchRequest.Author))
        {
            query = query.Where(b => b.Author.Contains(searchRequest.Author, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(searchRequest.Publisher))
        {
            query = query.Where(b => b.Publisher.Contains(searchRequest.Publisher, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(searchRequest.Genre))
        {
            query = query.Where(b => b.Genre.Contains(searchRequest.Genre, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(searchRequest.Isbn))
        {
            query = query.Where(b => b.Isbn.Contains(searchRequest.Isbn, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult<IEnumerable<Book>>(query.ToList());
    }
}