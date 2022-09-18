using Microsoft.AspNetCore.Identity;
using MyLib.Api.Entities;

namespace MyLib.Api.Seeders
{
    public static class UsersSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<MyLibContext>();
            var hasher = serviceProvider.GetService<IPasswordHasher<User>>();

            var source = new List<User>()
            {
                new User
                {
                    Id = 1,
                    Name = "Kamil",
                    SName = "Nowak",
                    Login = "Admin",
                    Password = "Admin",
                    EMail = "kamil.nowak@lib.com",
                    RoleId = 1
                },
                new User
                {
                    Id = 2,
                    Name = "Oliwier",
                    SName = "Michałowski",
                    Login = "omichalowski",
                    Password = "omichalowski",
                    EMail = "oliwier.michalowski@lib.com",
                    RoleId = 2
                },
                new User
                {
                    Id = 3,
                    Name = "Józef",
                    SName = "Napierała",
                    Login = "jnaperala",
                    Password = "jnaperala",
                    EMail = "jozef.napierala@lib.com",
                    RoleId = 2
                },
                new User
                {
                    Id = 4,
                    Name = "Koralia",
                    SName = "Skowron",
                    Login = "kskowron",
                    Password = "kskowron",
                    EMail = "koralia.skowron@lib.com",
                    RoleId = 2
                },
                new User
                {
                    Id = 5,
                    Name = "Lilianna",
                    SName = "Nowak",
                    Login = "lnowak",
                    Password = "lnowak",
                    EMail = "lilianna.nowak@lib.com",
                    RoleId = 3
                },
                new User
                {
                    Id = 6,
                    Name = "Roksana",
                    SName = "Wójcik",
                    Login = "rwojcik",
                    Password = "rwojcik",
                    EMail = "roksana.wojcik@lib.com",
                    RoleId = 3
                },
                new User  
                {
                    Id = 7,
                    Name = "Walentyn",
                    SName = "Sawicki",
                    Login = "wsawicki",
                    Password = "wsawicki",
                    EMail = "walentyn.sawicki@lib.com",
                    RoleId = 3
                },
                new User
                {
                    Id = 8,
                    Name = "Szymon",
                    SName = "Lipiński",
                    Login = "slipinski",
                    Password = "slipinski",
                    EMail = "szymon.lipinski@lib.com",
                    RoleId = 3
                },
                new User
                {
                    Id = 9,
                    Name = "Beniamin",
                    SName = "Balcerzak",
                    Login = "bbalcerzak",
                    Password = "bbalcerzak",
                    EMail = "beniamin.balcerzak@lib.com",
                    RoleId = 3
                }  
            };

            foreach(var u in source)
            {
                u.Password = hasher.HashPassword(u, u.Password);
            }

            db.Users.AddRange(source);
            db.SaveChanges();
        }
    }
}
