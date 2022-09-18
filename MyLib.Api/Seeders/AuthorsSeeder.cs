using MyLib.Api.Entities;

namespace MyLib.Api.Seeders
{
    public static class AuthorsSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<MyLibContext>();

            var source = new List<Author>()
            {
                new Author
                {
                    Id = 1,
                    Name = "Marijn",
                    SName = "Haverbeke"
                },
                new Author
                {
                    Id = 2,
                    Name = "Steve",
                    SName = "Krug"
                },
                new Author
                {
                    Id = 3,
                    Name = "Scott",
                    SName = "Oaks"
                },
                new Author
                {
                    Id = 4,
                    Name = "Neal",
                    SName = "Ford"
                },
                new Author
                {
                    Id = 5,
                    Name = "Mark",
                    SName = "Richards"
                },
                new Author
                {
                    Id = 6,
                    Name = "Pramod",
                    SName = "Sadalage"
                },
                new Author
                {
                    Id = 7,
                    Name = "Zhamak",
                    SName = "Dehghani"
                },
                new Author
                {
                    Id = 8,
                    Name = "Alvin",
                    SName = "Ashcraft"
                }
            };

            db.Authors.AddRange(source);
            db.SaveChanges();
        }
    }
}
