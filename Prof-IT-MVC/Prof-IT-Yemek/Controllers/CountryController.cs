﻿using Microsoft.AspNetCore.Mvc;
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
        public JsonResult AddCountry([FromBody] Country country)
        {
            Console.WriteLine(country.Name);
            _appDb.Add(country);
            _appDb.SaveChanges();
            string strJson = JsonSerializer.Serialize<Country>(country);
            return Json(strJson);
        }

        [HttpGet]
        public IActionResult GetCountries()
        {
            List<Country> countries = _appDb.Countries.ToList();
            if (countries.Count > 0)
            {
                return Ok(countries);
            }
            else
            {
                return Ok("Country listesi boş");
            }

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var country = _appDb.Countries.FirstOrDefault(c => c.Id == id);
            if (country != null)
            {
                _appDb.Countries.Remove(country);
                _appDb.SaveChanges();
                return Ok("Ülke Silindi");
            }
            else
            {
                return NotFound("Ülke Bulunamadı");
            }


        }
        [HttpPut]
        public IActionResult Update(Country newCountry)
        {
            var country = _appDb.Countries.FirstOrDefault(c => c.Id == newCountry.Id);
            if (country != null)
            {
                country.Name = newCountry.Name;
                _appDb.Countries.Update(country);
                _appDb.SaveChanges(true);

                return Ok(country);
            }
            else
            {

                return BadRequest("country bulunamadı!☺");
            }
        }



    }
}
