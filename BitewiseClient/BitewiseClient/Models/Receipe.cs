using System.ComponentModel.DataAnnotations;

namespace BitewiseClient.Models
{
    public class Receipe
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int Calories { get; set; }

        // Navigation property for ingredients
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
