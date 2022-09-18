using MyLib.Api.Entities;

namespace MyLib.Api.Seeders
{
    public static class RolesSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<MyLibContext>();
            var source = new List<Role>()
            {
                new Role
                {
                    Id = 1,
                    Name = "Admin"
                },
                new Role
                {
                    Id = 2,
                    Name = "Librarrian"
                },
                new Role
                {
                    Id = 3,
                    Name = "Borrower"
                }
            };

            db.Roles.AddRange(source);
            db.SaveChanges();
        }
    }
}
