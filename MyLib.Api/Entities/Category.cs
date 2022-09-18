using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLib.Api.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
