using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.QuestionDtos;

namespace Topic.WebUI.ViewComponents.Default
{
	public class _DefaultQuestionComponent : ViewComponent
	{
		private readonly HttpClient _client;

        public _DefaultQuestionComponent(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7261/api/");
            _client = client;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
			var questions = await _client.GetFromJsonAsync<List<ResultQuestionDto>>("https://localhost:7261/api/questions");
			return View(questions);
		}
	}
}
