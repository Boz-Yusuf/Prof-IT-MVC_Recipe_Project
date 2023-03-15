using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
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
            string strJson = JsonSerializer.Serialize<Country>(country);
            return Json(strJson);
        }

        [HttpGet]
        public IActionResult GetCountries() {
            List<Country> countries = _appDb.Countries.ToList();
            if(countries.Count > 0)
            {
                return Ok(countries);
            }
            else
            {
                return Ok("Country listesi boş");
            }
            
        }



    }
}
