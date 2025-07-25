using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface.SurveyRepo;

namespace Repositories
{
    public class SurveyOptionRepository : ISurveyOptionRepository
    {
        private readonly DrugPreventSystemContext _context;

        public SurveyOptionRepository(DrugPreventSystemContext context)
        {
            _context = context;
        }

        public List<SurveyOption> GetAll()
        {
            return _context.SurveyOptions
                .Include(so => so.Question)
                .ToList();
        }

        public SurveyOption? GetById(int id)
        {
            return _context.SurveyOptions
                .Include(so => so.Question)
                .FirstOrDefault(so => so.OptionId == id);
        }

        public SurveyOption Create(SurveyOption surveyOption)
        {
            _context.SurveyOptions.Add(surveyOption);
            _context.SaveChanges();
            return surveyOption;
        }

        public bool Update(SurveyOption surveyOption)
        {
            var existing = _context.SurveyOptions.Find(surveyOption.OptionId);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(surveyOption);
            existing.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var option = _context.SurveyOptions.FirstOrDefault(o => o.OptionId == id);
            if (option == null) return false;

            _context.SurveyOptions.Remove(option);
            _context.SaveChanges();
            return true;
        }

        public List<SurveyOption> GetByQuestionId(int questionId)
        {
            return _context.SurveyOptions
                .Where(so => so.QuestionId == questionId)
                .ToList();
        }
    }
}
