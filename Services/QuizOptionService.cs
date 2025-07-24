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
    public class QuizOptionService : IQuizOptionService
    {
        private readonly IQuizOptionRepository _quizOptionRepository;

        public QuizOptionService(IQuizOptionRepository quizOptionRepository)
        {
            _quizOptionRepository = quizOptionRepository;
        }

        public void Add(QuizOption quizOption)
        {
            if (quizOption == null)
                throw new ArgumentNullException(nameof(quizOption));

            quizOption.OptionId = Guid.NewGuid();
            quizOption.CreatedAt = DateTime.Now;
            _quizOptionRepository.Create(quizOption);
        }

        public List<QuizOption> GetAll()
        {
            return _quizOptionRepository.GetAll().ToList();
        }

        public QuizOption GetById(Guid id)
        {
            var option = _quizOptionRepository.GetById(id);
            if (option == null)
                throw new KeyNotFoundException($"QuizOption with ID {id} not found.");

            return option;
        }

        public bool Update(QuizOption quizOption)
        {
            var existing = _quizOptionRepository.GetById(quizOption.OptionId);
            if (existing == null)
                return false;

            existing.OptionText = quizOption.OptionText;
            existing.IsCorrect = quizOption.IsCorrect;

            return _quizOptionRepository.Update(existing);
        }

        public bool Delete(Guid id)
        {
            var existing = _quizOptionRepository.GetById(id);
            if (existing == null)
                return false;

            return _quizOptionRepository.Delete(id);
        }
    }

}
