using Microsoft.EntityFrameworkCore;

namespace DineDash.Models
{
  public class DineDashContext : DbContext
  {

    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Cuisine> Cuisines { get; set; }
    

    public DineDashContext(DbContextOptions options) : base(options) { }
  }
}