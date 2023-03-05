using System.Collections.Generic;

namespace DineDash.Models
{
  public class Cuisine
  {
    public int CuisineId { get; set; }
    public string Name { get; set; }
    public List<Restaurant> Restaurants { get; set; }
  }

}