using Microsoft.AspNetCore.Mvc;
using YemekKitabı.Data;
using YemekKitabı.Models;

namespace YemekKitabı.Controllers
{
    public class CountryController : Controller
    {
        

        private readonly AppDbContext _appDb;
        public CountryController(AppDbContext appDbContext)
        {
            _appDb = appDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddCountry([FromBody]Country country) {
            Console.WriteLine(country.Name);
            _appDb.Add(country);
            _appDb.SaveChanges();
            return null;
        }

        public IActionResult GetCountry() {
            
            return View();
        }



    }
}
