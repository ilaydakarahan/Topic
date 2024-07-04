using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.QuestionDtos;

namespace Topic.WebUI.Areas.Admin.Controllers
{       
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class QuestionController : Controller
    {
        private readonly HttpClient _client;

        public QuestionController(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7261/api/");
            _client = client;
        }


        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultQuestionDto>>("Questions");
            return View(values);
        }

        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await _client.DeleteAsync("questions/" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateQuestion()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateQuestion(CreateQuestionDto createQuestionDto)
        {
            await _client.PostAsJsonAsync("Questions", createQuestionDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateQuestion(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateQuestionDto>("https://localhost:7261/api/questions/" + id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuestion(UpdateQuestionDto updateQuestionDto)
        {
            await _client.PutAsJsonAsync("Questions", updateQuestionDto);
            return RedirectToAction("Index");
        }

    }
}
