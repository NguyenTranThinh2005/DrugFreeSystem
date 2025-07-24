using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DrugPreventionSystem.BusinessLogic.Services.Interfaces.Quizzes;
using Repositories.Interface.QuizRepo;

namespace DrugPreventionSystem.BusinessLogic.Services.Quizzes
{
    public class QuizQuestionService : IQuizQuestionService
    {
        private readonly IQuizQuestionRepository _quizQuestionRepository;

        public QuizQuestionService(IQuizQuestionRepository quizQuestionRepository)
        {
            _quizQuestionRepository = quizQuestionRepository;
        }

        public void Add(QuizQuestion quizQuestion)
        {
            quizQuestion.QuestionId = Guid.NewGuid();
            quizQuestion.CreatedAt = DateTime.Now;
            _quizQuestionRepository.Create(quizQuestion);
        }

        public List<QuizQuestion> GetAll()
        {
            return _quizQuestionRepository.GetAll();
        }

        public QuizQuestion GetById(Guid id)
        {
            return _quizQuestionRepository.GetById(id);
        }

        public bool Update(QuizQuestion quizQuestion)
        {
            return _quizQuestionRepository.Update(quizQuestion);
        }

        public bool Delete(Guid id)
        {
            return _quizQuestionRepository.Delete(id);
        }
    }

}
