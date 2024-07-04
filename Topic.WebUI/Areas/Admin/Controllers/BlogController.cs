using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Topic.WebUI.Dtos.BlogDtos;
using Topic.WebUI.Dtos.CategoryDtos;

namespace Topic.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BlogController : Controller
    {
        private readonly HttpClient _client;

        public BlogController(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7261/api/");
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>("blogs"); //controller adı yazılır.api deki.  category kontrollerdaki metodla aynı şey bu daha kısa.

            return View(values);
        }
        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _client.DeleteAsync("blogs/" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CreateBlog()
        {
            var categoryList = await _client.GetFromJsonAsync<List<ResultCategoryDto>>("categories");   //Getirme işleminde getfromjson, değiştirmede post

            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();

            ViewBag.categories = categories;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
        {
            await _client.PostAsJsonAsync("blogs",createBlogDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
		public async Task<IActionResult> UpdateBlog(int id)
        {
			var categoryList = await _client.GetFromJsonAsync<List<ResultCategoryDto>>("categories");

			List<SelectListItem> categories = (from x in categoryList
											   select new SelectListItem
											   {
												   Text = x.CategoryName,
												   Value = x.CategoryId.ToString()
											   }).ToList();

			ViewBag.categories = categories;

			var values = await _client.GetFromJsonAsync<UpdateBlogDto>("blogs/" + id);
            return View(values);
        }

        [HttpPost]
		public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlogDto)
        {
            await _client.PutAsJsonAsync("blogs", updateBlogDto);
            return RedirectToAction("Index");
        }

	}
}
