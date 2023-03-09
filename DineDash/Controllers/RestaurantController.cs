using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using DineDash.Models;


namespace DineDash.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly DineDashContext _db;
    public RestaurantsController(DineDashContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Restaurant> model = _db.Restaurants
                                  .Include(restaurant => restaurant.Cuisine)
                                  .ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Restaurant restaurant)
    {
      if (restaurant.CuisineId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Restaurants.Add(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }
    // [HttpPost , ActionName("Details")]
    // public ActionResult AddFavorite(int id)
    // {
    //   Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
    //   thisRestaurant.Favorite=1;
    //   _db.SaveChanges();
    //   return RedirectToAction("Favorites");
    // }
     [HttpPost , ActionName("Details")]
    public ActionResult AddFavorite(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
     
        thisRestaurant.Favorite=1;
      _db.SaveChanges();
      return RedirectToAction("Favorites");
    }
     [HttpPost, ActionName("Ratings")] 
     public ActionResult AddRating(int id, int rating)
     {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);

      thisRestaurant.Rating = rating;  
      
      _db.SaveChanges();
  
      return RedirectToAction("Details", new { id = id});
    }

    public ActionResult Delete(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
    Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
    _db.Restaurants.Remove(thisRestaurant);
    _db.SaveChanges();
    return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
      return View(thisRestaurant);
    }

    [HttpPost]
    public ActionResult Edit(Restaurant restaurant)
    {
      _db.Restaurants.Update(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

     public ActionResult Favorites()
    {
      List<Restaurant> model = _db.Restaurants
                                  .Where(restaurant => restaurant.Favorite > 0)
                                  .ToList();
      return View(model);
    }

     public ActionResult Ratings()
    {
      List<Restaurant> model = _db.Restaurants
                                  .Where(restaurant => restaurant.Rating > 0)
                                  .ToList();
      return View(model);
    }
    // [HttpPost ]
    // public ActionResult Favorites(int id)
    // {
    //   Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
    //   thisRestaurant.Favorite++; 
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
    
  }
}