using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using DrugPreventionSystem.BusinessLogic.Services.Interfaces.Quizzes;
using Repositories;
using Repositories.Interface.LessonRepo;
using Repositories.Interface.QuizRepo;

namespace DrugPreventionSystem.BusinessLogic.Services.Quizzes
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;
        private readonly ILessonRepository _lessonRepository;

        public QuizService(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public void Add(Quiz quiz)
        {
            var existing = _quizRepository.GetQuizByLessonId(quiz.LessonId);
            if (existing != null)
            {
                throw new InvalidOperationException("Each lesson can have only one quiz.");
            }

            _quizRepository.Create(quiz);
        }

        public List<Quiz> GetAll()
        {
            return _quizRepository.GetAll();
        }

        public Quiz GetById(int id)
        {
            return _quizRepository.GetById(id);
        }

        public bool Update(Quiz quiz)
        {
            return _quizRepository.Update(quiz);
        }

        public bool Delete(int id)
        {
            return _quizRepository.Delete(id);
        }

        public Quiz GetQuizByLessonIdForEdit(int lessonId)
        {
            return _quizRepository.GetQuizWithQuestionsAndOptionsByLessonId(lessonId);
        }
    }
}
