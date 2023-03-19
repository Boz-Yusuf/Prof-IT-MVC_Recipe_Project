using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using YemekKitabı.Data;
using YemekKitabı.Models;

namespace YemekKitabı.Controllers
{
    public class CookController : Controller
    {
        private readonly AppDbContext _appDb;
        public CookController(AppDbContext appDbContext)
        {
            _appDb = appDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Cook/GetCooks")]
        public IActionResult GetCooks()
        {
            var cooks = from c in _appDb.Cooks
                        join ca in _appDb.Categories
                        on c.CategoryId equals ca.Id
                        join co in _appDb.Countries
                        on c.CountryId equals co.Id
                        select new CookDto
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Date = c.Date,
                            Recipe = c.Recipe,
                            CategoryName = ca.Name,
                            CountryName = co.Name,
                            Materials = c.Materials,
                            Images = ((from ui in _appDb.Images
                                       where (ui.CookId == c.Id)
                                       select new Image
                                       {
                                           Id = ui.Id,
                                           CookId = c.Id,
                                           ImagePath = ui.ImagePath
                                       }).ToList()).Count == 0
                                                     ? new List<Image> { new Image { Id = -1, CookId = c.Id, ImagePath = "default.png" } }
                                                     : (from ui in _appDb.Images
                                                        where (ui.CookId == c.Id)
                                                        select new Image
                                                        {

                                                            Id = ui.Id,
                                                            CookId = c.Id,
                                                            ImagePath = ui.ImagePath
                                                        }).ToList()
                        };

          
            return View(cooks);


        }
        [HttpPost]
        [Route("Cook/AddCook")]
        public JsonResult AddCook([FromBody] Cook cook)
        {

            Console.WriteLine(cook.Name);
            _appDb.Add(cook);
            _appDb.SaveChanges();
            string strJson = JsonSerializer.Serialize<Cook>(cook);
            return Json(strJson);
        }


    }
}
