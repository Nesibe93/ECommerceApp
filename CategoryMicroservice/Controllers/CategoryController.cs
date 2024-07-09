using ECommerceApp.CategoryMicroservice.BusinessLayer.Abstract;
using ECommerceApp.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CategoryMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("GetAll")]
        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]

        public IActionResult CreateCategory(Category category)
        {
            _categoryService.TInsert(category);
            return Ok("Kategori başarıyla eklendi.");
        }

        [HttpDelete]

        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(id);
            return Ok("Kategori başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.TUpdate(category);
            return Ok("Kategori başarıyla güncellendi");
        }
        [HttpGet("GetByCategoryId/{categoryId}")]
        public IActionResult GetByCategoryId(int id)
        {
            var value = _categoryService.TGetById(id);
            return Ok(value);
        }
        [HttpGet("GetByCategoryName")]
        public IActionResult GetByCategoryName()
        {
            return Ok(_categoryService.TGetByCategoryName());
        }
    }
}
