using System.ComponentModel.DataAnnotations;

namespace Bilet16Trainers.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(32)]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
