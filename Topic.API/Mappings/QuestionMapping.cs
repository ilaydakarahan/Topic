using AutoMapper;
using Topic.DTOLayer.DTOs.QuestionDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Mappings
{
    public class QuestionMapping : Profile
    {
        public QuestionMapping() 
        {
            CreateMap<CreateQuestionDto, Question>().ReverseMap();
            CreateMap<UpdateQuestionDto, Question>().ReverseMap();
            CreateMap<ResultQuestionDto, Question>().ReverseMap();
        }
    }
}
