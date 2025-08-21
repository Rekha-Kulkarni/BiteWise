using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BitewiseClient.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public double Quantity { get; set; }   // e.g., 100

        public string Unit { get; set; } = "g"; // e.g., g, ml, tsp

        // Foreign key
        public int RecipeId { get; set; }

        // Navigation property
        [ForeignKey("RecipeId")]
        public Receipe? Recipe { get; set; }
    }
}
