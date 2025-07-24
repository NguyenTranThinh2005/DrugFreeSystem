using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using DrugPreventionSystem.BusinessLogic.Services.Interfaces.Quizzes;
using Repositories.Interface.LessonRepo;
using Repositories.Interface.QuizRepo;

namespace DrugPreventionSystem.BusinessLogic.Services.Quizzes
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;
        private readonly ILessonRepository _lessonRepository;

        public QuizService(IQuizRepository quizRepository, ILessonRepository lessonRepository)
        {
            _quizRepository = quizRepository;
            _lessonRepository = lessonRepository;
        }

        public void Add(Quiz quiz)
        {
            _quizRepository.Create(quiz);
        }

        public List<Quiz> GetAll()
        {
            return _quizRepository.GetAll();
        }

        public Quiz GetById(Guid id)
        {
            return _quizRepository.GetById(id);
        }

        public bool Update(Quiz quiz)
        {
            return _quizRepository.Update(quiz);
        }

        public bool Delete(Guid id)
        {
            return _quizRepository.Delete(id);
        }

        public Quiz GetQuizByLessonIdForEdit(Guid lessonId)
        {
            return _quizRepository.GetQuizWithQuestionsAndOptionsByLessonId(lessonId);
        }
    }
}
