namespace MyLib.DataModels.Models.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? SName { get; set; }

        public string? EMail { get; set; }

        public UserRoles Role { get; set; }
    }
}