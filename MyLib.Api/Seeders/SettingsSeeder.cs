using MyLib.Api.Entities;

namespace MyLib.Api.Seeders
{
    public static class SettingsSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<MyLibContext>();

            var source = new List<Setting>()
            {
                new Setting
                {
                    Key = "MinReturnDays",
                    Value = "14"
                },
                new Setting
                {
                    Key = "MaxReturnDays",
                    Value = "112"
                },
                new Setting
                {
                    Key = "MaxBorrowBooks",
                    Value = "5"
                }
            };

            db.Settings.AddRange(source);
            db.SaveChanges();
        }
    }
}
