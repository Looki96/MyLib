using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLib.Api.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string? Login { get; set; }

        public string? Password { get; set; }

        public string? Name { get; set; }

        public string? SName { get; set; }

        public string? EMail { get; set; }

        public int RoleId { get; set; }

        public virtual Role? Role { get; set; }

        public bool Active { get; set; }

        public bool ChangePassword { get; set; }
    }
}
