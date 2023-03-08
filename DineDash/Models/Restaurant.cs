namespace DineDash.Models
{
  public class Restaurant
  {
    public int RestaurantId {get; set;}
    public int CuisineId {get; set;}
    public string Name {get; set;}

    public int Favorite{get; set;}

    public int Rating{get; set;}
    public Cuisine Cuisine {get; set;}


  }
}