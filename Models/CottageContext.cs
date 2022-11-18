using Microsoft.EntityFrameworkCore;

namespace CottageApp.Models;

public class CottageContext : DbContext
{
    public CottageContext(DbContextOptions<CottageContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CottageItem>().HasData(
            new CottageItem {
                Id = 1,
                Title = "Foo",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                PictureUrl = "img/log-cabin-1886620_1920.jpg",
                DateAdded = DateTime.Now,
                Ratings = new int[] {1,2, 4, 1, 3}
            },
            new CottageItem {
                Id = 2,
                Title = "Bar",
                PictureUrl = "img/cabin-1082063__340.webp",
                DateAdded = new DateTime(2020, 12, 31),
                Ratings = new int[] {5}
            }
        );

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<CottageItem> CottageItems => Set<CottageItem>();
}