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

    
  }
}