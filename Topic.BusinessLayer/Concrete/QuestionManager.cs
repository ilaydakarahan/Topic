using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Topic.BusinessLayer.Abstract;
using Topic.DataAccessLayer.Abstract;
using Topic.EntityLayer.Entities;

namespace Topic.BusinessLayer.Concrete
{
    public class QuestionManager : IQuestionService
    {
        private readonly IQuestionDal _questionDal;

        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        public void TCreate(Question entity)
        {
            _questionDal.Create(entity);
        }

        public void TDelete(int id)
        {
            _questionDal.Delete(id);
        }

        public Question TGetByFilter(Expression<Func<Question, bool>> filter)
        {
            return _questionDal.GetByFilter(filter);
        }

        public Question TGetById(int id)
        {
            return _questionDal.GetById(id);
        }

        public List<Question> TGetFilteredList(Expression<Func<Question, bool>> filter)
        {
            return _questionDal.GetFilteredList(filter);
        }

        public List<Question> TGetList()
        {
            return _questionDal.GetList();
        }

        public void TUpdate(Question entity)
        {
            _questionDal.Update(entity);
        }
    }
}
