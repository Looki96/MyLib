using MyLib.Api.Entities;
using System.Text.Json;

namespace MyLib.Api.Seeders
{
    public static class BooksSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<MyLibContext>();

            var source = new List<Book>()
            {
                new Book
                {
                    Id = 1,
                    Title = "Eloquent JavaScript, 3rd Edition",
                    Subtitle = "A Modern Introduction to Programming",
                    ISBN = "9781593279509",
                    URL = "https://images-na.ssl-images-amazon.com/images/W/WEBP_402378-T1/images/I/51InjRPaF7L._SX258_BO1,204,203,200_.jpg",
                    Pages = 472,
                    Quantity = 5,
                    PublishDate = DateTime.Parse("2018-12-04"),
                    Description = "JavaScript lies at the heart of almost every modern web application, from social apps like Twitter to browser-based game frameworks like Phaser and Babylon. Though simple for beginners to pick up and play with, JavaScript is a flexible, complex language that you can use to build full-scale applications.",
                    CategoryId = 3,
                    PublisherId = 1,
                    Authors = new List<Author>
                    {
                        db.Authors.First(a => a.Id == 1)
                    }
                },
                new Book
                {
                    Id = 2,
                    Title = "Don't Make Me Think",
                    Subtitle = "A Common Sense Approach to Web Usability",
                    ISBN = "9780321965516",
                    URL = "https://images-na.ssl-images-amazon.com/images/W/WEBP_402378-T1/images/I/51WS36aA2BL._SX258_BO1,204,203,200_.jpg",
                    Pages = 200,
                    Quantity = 4,
                    PublishDate = DateTime.Parse("2013-12-24"),
                    Description = "Since Don't Make Me Think was first published in 2000, hundreds of thousands of Web designers and developers have relied on usability guru Steve Krug's guide to help them understand the principles of intuitive navigation and information design. Witty, commonsensical, and eminently practical, it's one of the best-loved and most recommended books on the subject.\r\nNow Steve returns with fresh perspective to reexamine the principles that made Don't Make Me Think a classic-with updated examples and a new chapter on mobile usability. And it's still short, profusely illustrated...and best of all-fun to read.",
                    CategoryId = 3,
                    PublisherId = 2,
                    Authors = new List<Author>
                    {
                        db.Authors.First(a => a.Id == 2)
                    }
                },
                new Book
                {
                    Id = 3,
                    Title = "Java Performance",
                    Subtitle = "In-depth Advice for Tuning and Programming Java 8, 11, and Beyond",
                    ISBN = "9781492056119",
                    URL = "https://images-na.ssl-images-amazon.com/images/W/WEBP_402378-T1/images/I/51CSCTcX-TL._SX258_BO1,204,203,200_.jpg",
                    Pages = 433,
                    Quantity = 1,
                    PublishDate = DateTime.Parse("2020-03-01"),
                    Description = "Coding and testing are generally considered separate areas of expertise. In this practical book, Java expert Scott Oaks takes the approach that anyone who works with Java should be adept at understanding how code behaves in the Java Virtual Machine--including the tunings likely to help performance. This updated second edition helps you gain in-depth knowledge of Java application performance using both the JVM and the Java platform.",
                    CategoryId = 3,
                    PublisherId = 3,
                    Authors = new List<Author>
                    {
                        db.Authors.First(a => a.Id == 3)
                    }
                },
                new Book
                {
                    Id = 4,
                    Title = "Software Architecture",
                    Subtitle = "The Hard Parts: Modern Tradeoff Analysis for Distributed Architectures",
                    ISBN = "9781492086895",
                    URL = "https://images-na.ssl-images-amazon.com/images/W/WEBP_402378-T1/images/I/51qZnL+B63L._SX258_BO1,204,203,200_.jpg",
                    Pages = 441,
                    Quantity = 2,
                    PublishDate = DateTime.Parse("2021-12-01"),
                    Description = "There are no easy decisions in software architecture. Instead, there are many hard parts--difficult problems or issues with no best practices--that force you to choose among various compromises. With this book, you'll learn how to think critically about the trade-offs involved with distributed architectures.",
                    CategoryId = 3,
                    PublisherId = 3,
                    Authors = new List<Author>
                    {
                        db.Authors.First(a => a.Id == 4),
                        db.Authors.First(a => a.Id == 5),
                        db.Authors.First(a => a.Id == 6),
                        db.Authors.First(a => a.Id == 7)
                    }
                },
                new Book
                {
                    Id = 5,
                    Title = "Parallel Programming and Concurrency with C# 10 and .NET 6",
                    Subtitle = "A modern approach to building faster, more responsive, and asynchronous .NET applications using C#",
                    ISBN = "9781803243672",
                    URL = "https://images-na.ssl-images-amazon.com/images/W/WEBP_402378-T1/images/I/41LVLQEMyRL._SX258_BO1,204,203,200_.jpg",
                    Pages = 320,
                    Quantity = 12,
                    PublishDate = DateTime.Parse("2022-08-31"),
                    Description = "Leverage the latest parallel and concurrency features in .NET 6 when building your next application and explore the benefits and challenges of asynchrony, parallelism, and concurrency in .NET via practical examples",
                    CategoryId = 3,
                    PublisherId = 4,
                    Authors = new List<Author>
                    {
                        db.Authors.First(a => a.Id == 8)
                    }
                },
            };        

            db.Books.AddRange(source);
            db.SaveChanges();
        }
    }
}
