using ECommerceApp.EntityLayer.Dtos.CategoryDtos;
using ECommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerceApp.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //Categories API Consume
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7075/api/Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            else
            {
                // Hata durumunu loglama
                var errorContent = await responseMessage.Content.ReadAsStringAsync();
                // Hata durumunda kullanıcıya bilgi gösterme
                return View("Error", new ErrorViewModel { RequestId = errorContent });
            }
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDto categoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(categoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7075/api/Category", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Hata durumunu loglama
                var errorContent = await responseMessage.Content.ReadAsStringAsync();
                // Hata durumunda kullanıcıya bilgi gösterme
                return View("Error", new ErrorViewModel { RequestId = errorContent });
            }
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7075/api/Category?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Hata durumunu loglama
                var errorContent = await responseMessage.Content.ReadAsStringAsync();
                // Hata durumunda kullanıcıya bilgi gösterme
                return View("Error", new ErrorViewModel { RequestId = errorContent });
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7075/api/Category/GetCategory?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCategoryDto>(jsonData);
                return View(values);
            }
            else
            {
                // Hata durumunu loglama
                var errorContent = await responseMessage.Content.ReadAsStringAsync();
                // Hata durumunda kullanıcıya bilgi gösterme
                return View("Error", new ErrorViewModel { RequestId = errorContent });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(ResultCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7075/api/Category", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Hata durumunu loglama
                var errorContent = await responseMessage.Content.ReadAsStringAsync();
                // Hata durumunda kullanıcıya bilgi gösterme
                return View("Error", new ErrorViewModel { RequestId = errorContent });
            }
        }
    }
}
