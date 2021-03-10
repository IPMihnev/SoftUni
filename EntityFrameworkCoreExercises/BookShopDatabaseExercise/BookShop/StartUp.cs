namespace BookShop
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Initializer;
    using BookShop.Models.Enums;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();

            DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetMostRecentBooks(db));
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(x => x.AgeRestriction == ageRestriction)
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToArray();

            var result = string.Join(Environment.NewLine, books);
            return result;
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.EditionType == EditionType.Gold &&
                x.Copies < 5000)
                .Select(x => new
                {
                    Id = x.BookId,
                    Title = x.Title
                })
                .OrderBy(x => x.Id)
                .ToArray();

            var result = string.Join(Environment.NewLine, books.Select(x => x.Title));
            return result;
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    x.Title,
                    x.Price
                })
                .OrderByDescending(x => x.Price)
                .ToArray();
            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.HasValue &&
                       x.ReleaseDate.Value.Year != year)
                .Select(x => new
                {
                    x.Title,
                    x.BookId
                })
                .OrderBy(x => x.BookId)
                .ToArray();

            var result = string.Join(Environment.NewLine, books.Select(x =>
             x.Title));

            return result;
        }
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToLower()).ToArray();

            var books = context.BooksCategories
                .Where(x => categories.Contains(x.Category.Name.ToLower()))
                .Select(x => x.Book.Title)
                .OrderBy(x => x)
                .ToArray();
            var result = string.Join(Environment.NewLine, books);
            return result;
        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var targetDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = context.Books
                .Where(x => x.ReleaseDate < targetDate)
                .Select(x => new
                {
                    Title = x.Title,
                    EditionType = x.EditionType,
                    Price = x.Price,
                    ReleaseDate = x.ReleaseDate.Value
                })
                .OrderByDescending(x => x.ReleaseDate)
                .ToArray();
            var result = string.Join(Environment.NewLine, books.Select(y => $"{y.Title} - {y.EditionType} - ${y.Price:f2}"));
            return result;
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(x => EF.Functions.Like(x.FirstName, $"%{input}"))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToArray();

            var result = string.Join(Environment.NewLine, authors.Select(x => $"{x.FirstName} {x.LastName}"));
            return result;
        }
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var titles = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => new
                {
                    x.Title
                })
                .OrderBy(x => x.Title)
                .ToArray();
            var result = string.Join(Environment.NewLine, titles.Select(x => x.Title));
            return result;
        }
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var titles = context.Books
                .Include(x => x.Author)
                .Where(x => EF.Functions.Like(x.Author.LastName, $"{input}%"))
                .Select(x => new
                {
                    x.Title,
                    x.BookId,
                    x.Author.FirstName,
                    x.Author.LastName
                })
                .OrderBy(x => x.BookId)
                .ToArray();
            var result = string.Join(Environment.NewLine,
                titles.Select(x => $"{x.Title} ({x.FirstName} {x.LastName})"));
            return result;
        }
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();
            return booksCount;
        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    totalCopies = x.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(x => x.totalCopies)
                .ToArray();
            var result = string.Join(Environment.NewLine,
                authors.Select(x => $"{x.FirstName} {x.LastName} - {x.totalCopies}"));
            return result;
        }
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var booksProfit = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Profit = x.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.Name)
                .ToArray();

            var result = string.Join(Environment.NewLine,
                booksProfit.Select(x => $"{x.Name} ${x.Profit:f2}"));

            return result;
        }
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    Name = x.Name,
                    Books = x.CategoryBooks.Select(y => new
                    {
                        y.Book.Title,
                        y.Book.ReleaseDate.Value
                    }).OrderByDescending(b => b.Value)
                    .Take(3)
                    .ToArray()
                })
                .OrderBy(x => x.Name)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var categorie in categories)
            {
                sb.AppendLine($"--{categorie.Name}")
                  .AppendLine(string.Join(Environment.NewLine,
                  categorie.Books.Select(x => $"{x.Title} ({x.Value.Year})")));
            }

            return sb.ToString().TrimEnd();
        }
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }
            context.SaveChanges();
        }
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(c => c.Copies < 4200)
                .ToList();
            context.Books.RemoveRange(books);
            context.SaveChanges();
            return books.Count;
        }
    }
}