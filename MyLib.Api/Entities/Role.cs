using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLib.Api.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public Role()
        {
            Users = new HashSet<User>();
        }
    }
}
