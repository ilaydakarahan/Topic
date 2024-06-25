using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Topic.WebUI.Dtos.CategoryDtos;

namespace Topic.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CategoryController : Controller
    {
        private readonly HttpClient _client;    //Bu sınıf yani class olan versiyon. Httpclient ın bir de interface şekli var.

        public CategoryController(HttpClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()    //client nesneleri genelde asenkron metodlarla çalışır. get isteği atınca json tipinde veriler çekilir.sonra (deserialize)json dan stringe çevirilecek.
        {
            var responseMessage = await _client.GetAsync("https://localhost:7261/api/categories");   //yazılı olan url'e client nesnesi ile get isteği atıyoruz. Geriye durum kodu dönüyor(responsemessage).
            if (responseMessage.IsSuccessStatusCode) //eğer durum kodu başarılı olursa(200-299) jsondatayı alıcaz.
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();   //yukarıdan gelen değerleri jsondata formatında okuduk.Gelen değerleri deserialize ediyoruz.jsondan->stringe.
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = JsonConvert.SerializeObject(createCategoryDto);

            var stringContent = new StringContent(category, Encoding.UTF8, "application/json");

            var responseMessage = await _client.PostAsync("https://localhost:7261/api/categories", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var responseMessage = await _client.DeleteAsync("https://localhost:7261/api/categories/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }


            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var responseMessage = await _client.GetAsync("https://localhost:7261/api/categories/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }
            return View("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var category = JsonConvert.SerializeObject(updateCategoryDto);

            var stringContent = new StringContent(category, Encoding.UTF8, "application/json");

            var responseMessage = await _client.PutAsync("https://localhost:7261/api/categories", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
