using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Topic.BusinessLayer.Abstract;
using Topic.DTOLayer.DTOs.QuestionDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;

        public QuestionsController(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllQuestions()
        {
            var values = _questionService.TGetList();
            var question = _mapper.Map<List<ResultQuestionDto>>(values);
            return Ok(question);
        }

        [HttpPost]
        public IActionResult CreateQuestion(CreateQuestionDto createQuestionDto)
        {
            var question = _mapper.Map<Question>(createQuestionDto);
            _questionService.TCreate(question);
            return Ok("Kayıt eklendi");
        }

        [HttpPut]
        public IActionResult UpdateQuestion(UpdateQuestionDto updateQuestionDto)
        {
            var question = _mapper.Map<Question>(updateQuestionDto);
            _questionService.TUpdate(question);
            return Ok("Kayıt başarıyla güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuestion(int id)
        {
            _questionService.TDelete(id);
            return Ok("Kayıt Silindi");
        }
    }
}
