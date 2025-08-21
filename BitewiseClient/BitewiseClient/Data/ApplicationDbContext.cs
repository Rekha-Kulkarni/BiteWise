using BitewiseClient.Models;
using Microsoft.EntityFrameworkCore;

namespace BitewiseClient.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Receipe> Recipes { get; set; } = null!;
        public DbSet<Ingredient> Ingredients { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Optional: configure relationship
            modelBuilder.Entity<Receipe>()
                        .HasMany(r => r.Ingredients)
                        .WithOne(i => i.Recipe)
                        .HasForeignKey(i => i.RecipeId)
                        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
