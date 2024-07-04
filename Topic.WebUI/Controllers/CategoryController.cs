using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.CategoryDtos;

namespace Topic.WebUI.Controllers
{
	public class CategoryController : Controller
	{
		private readonly HttpClient _client;

		public CategoryController(HttpClient client)
		{
			client.BaseAddress = new Uri("https://localhost:7261/api/");
			_client = client;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _client.GetFromJsonAsync<List<ResultCategoryDto>>("categories");
			return View(values);
		}
	}
}
