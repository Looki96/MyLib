using MyLib.Api.Entities;
using System.Text.Json;

namespace MyLib.Api.Seeders
{
    public static class PublishersSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<MyLibContext>();
            var source = new List<Publisher>()
            {
                new Publisher
                {
                    Id = 1,
                    Name = "No Starch Press"
                },
                new Publisher
                {
                    Id = 2,
                    Name = "New Riders"
                },
                new Publisher
                {
                    Id = 3,
                    Name = "O'Reilly Media"
                },
                new Publisher
                {
                    Id = 4,
                    Name = "Packt Publishing"
                }
            };

            db.Publishers.AddRange(source); 
            db.SaveChanges(); 
        }
    }
}