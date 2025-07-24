using BusinessObjects;
using DrugPreventionSystem.BusinessLogic.Services.Interfaces;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Repositories.Interface.UserRepo;
using System;
using System.Collections.Generic;

namespace DrugPreventionSystem.BusinessLogic.Services
{
    public class UserSurveyAnswerService : IUserSurveyAnswerService
    {
        private readonly IUserSurveyAnswerRepository _userSurveyAnswerRepository;

        public UserSurveyAnswerService(IUserSurveyAnswerRepository userSurveyAnswerRepository)
        {
            _userSurveyAnswerRepository = userSurveyAnswerRepository;
        }

        public string Add(UserSurveyAnswer userSurveyAnswer)
        {
            if (userSurveyAnswer == null || string.IsNullOrEmpty(userSurveyAnswer.AnswerText))
            {
                return "Invalid survey answer data";
            }

            var result = _userSurveyAnswerRepository.AddNewUserSurveyAnswer(userSurveyAnswer);
            return result != null ? "User survey answer added successfully" : "Failed to add user survey answer";
        }

        public bool Delete(Guid id)
        {
            var answer = _userSurveyAnswerRepository.GetUserSurveyAnswerById(id);
            if (answer == null)
            {
                return false;
            }

            _userSurveyAnswerRepository.DeleteUserSurveyAnswerById(id);
            return true;
        }

        public List<UserSurveyAnswer> GetAll()
        {
            return _userSurveyAnswerRepository.GetAllUserSurveyAnswers();
        }

        public UserSurveyAnswer? GetById(Guid id)
        {
            return _userSurveyAnswerRepository.GetUserSurveyAnswerById(id);
        }

        public List<UserSurveyAnswer> GetByUserId(Guid userId)
        {
            return _userSurveyAnswerRepository.GetUserSurveyAnswerByUserId(userId);
        }

        public bool Update(UserSurveyAnswer userSurveyAnswer)
        {
            var existing = _userSurveyAnswerRepository.GetUserSurveyAnswerById(userSurveyAnswer.AnswerId);
            if (existing == null)
            {
                return false;
            }

            _userSurveyAnswerRepository.UpdateUserSurveyAnswer(userSurveyAnswer);
            return true;
        }
    }
}
