using System.ComponentModel.DataAnnotations;

namespace Bilet16Trainers.Models
{
    public class Trainer
    {
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(32)]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        [Required, MinLength(5), MaxLength(100)]
        public string Description { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
