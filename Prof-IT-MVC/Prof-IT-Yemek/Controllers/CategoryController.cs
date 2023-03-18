using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using YemekKitabı.Data;
using YemekKitabı.Models;

namespace YemekKitabı.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _appDb;
        public CategoryController(AppDbContext appDbContext)
        {
            _appDb = appDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddCategory([FromBody] Category category)
        {
            Console.WriteLine(category.Name);
            _appDb.Add(category);
            _appDb.SaveChanges();
            string strJson = JsonSerializer.Serialize<Category>(category);
            return Json(strJson);
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            List<Category> categories = _appDb.Categories.ToList();
            if (categories.Count > 0)
            {
                return Ok(categories);
            }
            else
            {
                return Ok("Category listesi boş");
            }

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var category = _appDb.Categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                _appDb.Categories.Remove(category);
                _appDb.SaveChanges();
                return Ok("Kategori Silindi");
            }
            else
            {
                return NotFound("Kategori Bulunamadı");
            }


        }
        [HttpPut]
        public IActionResult Update(Category newCategory)
        {
            var category = _appDb.Categories.FirstOrDefault(c => c.Id == newCategory.Id);
            if (category != null)
            {
                category.Name = newCategory.Name;
                _appDb.Categories.Update(category);
                _appDb.SaveChanges(true);

                return Ok(category);
            }
            else
            {

                return BadRequest("Category bulunamadı!☺");
            }
        }


    }
}
