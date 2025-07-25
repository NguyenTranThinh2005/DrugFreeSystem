using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using DataAccessLayer;
using Repositories.Interface.QuizRepo;

namespace Repositories
{
    public class QuizOptionRepository : IQuizOptionRepository
    {
        private readonly DrugPreventSystemContext _context;

        public QuizOptionRepository(DrugPreventSystemContext context)
        {
            _context = context;
        }

        public List<QuizOption> GetAll()
        {
            return _context.QuizOptions.ToList();
        }

        public QuizOption? GetById(int id)
        {
            return _context.QuizOptions.FirstOrDefault(q => q.OptionId == id);
        }

        public QuizOption Create(QuizOption option)
        {
            _context.QuizOptions.Add(option);
            _context.SaveChanges();
            return option;
        }

        public bool Update(QuizOption option)
        {
            var existing = _context.QuizOptions.Find(option.OptionId);
            if (existing == null)
                return false;

            _context.Entry(existing).CurrentValues.SetValues(option);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var option = _context.QuizOptions.FirstOrDefault(q => q.OptionId == id);
            if (option == null)
                return false;

            _context.QuizOptions.Remove(option);
            _context.SaveChanges();
            return true;
        }
    }
}
