using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using AnimalShelter.Models;


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
      List<Restaurant> model = _db.Restaurants.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    public ActionResult Create(Restaurant restaurant)
    {
      _db.Restaurant.Add(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}