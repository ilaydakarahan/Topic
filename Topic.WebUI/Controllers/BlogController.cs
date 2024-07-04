using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.BlogDtos;

namespace Topic.WebUI.Controllers
{
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
			var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>("blogs");
			return View(values);
		}
		public async Task<IActionResult> GetBlogsByCategory(int id)	//bu metod kategoriye tıklayınca ona ait olan blogların listeleneceği sayfa.
		{
			var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>("https://localhost:7261/api/blogs/GetBlogsByCategoryId/" + id);
			return View(values);
		}

		public async Task<IActionResult> GetBlogDetails(int id)
		{
            var value = await _client.GetFromJsonAsync<ResultBlogDto>("https://localhost:7261/api/blogs/" + id);
            return View(value);
        }


    }
}
