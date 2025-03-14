using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var value = _categoryService.TGetAll();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _categoryService.TAdd(category);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category) 
        {
            _categoryService.TUpdate(category);
            return Ok("Güncelleme işlemi başarılı");
        }
    }
}
