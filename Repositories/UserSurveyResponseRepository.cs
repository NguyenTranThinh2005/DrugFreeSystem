using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using DataAccessLayer;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface.UserRepo;

namespace Repositories
{
    public class UserSurveyResponseRepository : IUserSurveyResponseRepository
    {
        private readonly DrugPreventSystemContext _context;

        public UserSurveyResponseRepository(DrugPreventSystemContext context)
        {
            _context = context;
        }

        public UserSurveyResponse Create(UserSurveyResponse response)
        {
            _context.UserSurveyResponses.Add(response);
            _context.SaveChanges();
            return response;
        }

        public List<UserSurveyResponse> GetAll()
        {
            return _context.UserSurveyResponses.ToList();
        }

        public UserSurveyResponse? GetById(int id)
        {
            return _context.UserSurveyResponses.FirstOrDefault(r => r.ResponseId == id);
        }

        public bool Update(UserSurveyResponse response)
        {
            _context.UserSurveyResponses.Update(response);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var response = _context.UserSurveyResponses.Find(id);
            if (response != null)
            {
                _context.UserSurveyResponses.Remove(response);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public UserSurveyResponse? GetByIdWithAnswers(int id)
        {
            return _context.UserSurveyResponses
                           .Include(r => r.UserSurveyAnswers)
                               .ThenInclude(a => a.Option)
                           .Include(r => r.UserSurveyAnswers)
                               .ThenInclude(a => a.Question)
                           .FirstOrDefault(r => r.ResponseId == id);
        }

        public UserSurveyResponse? GetByIdWithAnswersAndSurvey(int responseId)
        {
            return _context.UserSurveyResponses
                           .Include(usr => usr.UserSurveyAnswers)
                               .ThenInclude(usa => usa.Option)
                           .Include(usr => usr.UserSurveyAnswers)
                               .ThenInclude(usa => usa.Question)
                           .Include(usr => usr.Survey)
                           .FirstOrDefault(usr => usr.ResponseId == responseId);
        }

        public List<UserSurveyResponse> GetByUserIdWithSurvey(int userId)
        {
            return _context.UserSurveyResponses
                           .Where(usr => usr.UserId == userId)
                           .Include(usr => usr.Survey)
                           .Include(usr => usr.UserSurveyAnswers)
                               .ThenInclude(usa => usa.Option)
                           .OrderByDescending(usr => usr.TakenAt)
                           .ToList();
        }
    }
}
