using MyLib.Api.Entities;

namespace MyLib.Api.Seeders
{
    public static class CategoriesSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<MyLibContext>();
            var source = new List<Category>()
            {
                new Category
                {
                    Id = 1,
                    Name = "Biographies"
                },
                new Category
                {
                    Id = 2,
                    Name = "Horror"
                },
                new Category
                {
                    Id = 3,
                    Name = "Programming"
                },
                new Category
                {
                    Id = 4,
                    Name = "Kitchen"
                },
                new Category
                {
                    Id = 5,
                    Name = "Thriller"
                },
                new Category
                {
                    Id = 6,
                    Name = "Mystery"
                },
                new Category
                {
                    Id = 7,
                    Name = "Medicine"
                },
                new Category
                {
                    Id = 8,
                    Name = "Religion"
                },
            };

            db.Categories.AddRange(source);
            db.SaveChanges();
        }
    }
}
