using System;
using System.Collections.Generic;
using DrugPreventionSystem.BusinessLogic.Services.Interfaces;
using BusinessObjects;
using Repositories.Interface.UserRepo;

namespace DrugPreventionSystem.BusinessLogic.Services
{
    public class UserModuleQuizResultService : IUserModuleQuizResultService
    {
        private readonly IUserModuleQuizResultRepository _userModuleQuizResultRepository;

        public UserModuleQuizResultService(IUserModuleQuizResultRepository userModuleQuizResultRepository)
        {
            _userModuleQuizResultRepository = userModuleQuizResultRepository;
        }

        public List<UserModuleQuizResult> GetAll()
        {
            return _userModuleQuizResultRepository.GetUserModuleQuizResults();
        }

        public UserModuleQuizResult? GetById(int resultId)
        {
            return _userModuleQuizResultRepository.GetUserModuleQuizResultById(resultId);
        }

        public List<UserModuleQuizResult> GetByUserId(int userId)
        {
            return _userModuleQuizResultRepository.GetUserModuleQuizResultsByUserId(userId);
        }

        public List<UserModuleQuizResult> GetByLessonId(int lessonId)
        {
            return _userModuleQuizResultRepository.GetUserModuleQuizResultsByLessonId(lessonId);
        }

        public void Add(UserModuleQuizResult result)
        {
            _userModuleQuizResultRepository.AddUserModuleQuizResult(result);
        }

        public bool Update(UserModuleQuizResult result)
        {
            var existing = _userModuleQuizResultRepository.GetUserModuleQuizResultById(result.ResultId);
            if (existing == null) return false;

            existing.UserId = result.UserId;
            existing.LessonId = result.LessonId;
            existing.TotalScore = result.TotalScore;
            existing.CorrectCount = result.CorrectCount;
            existing.TotalQuestions = result.TotalQuestions;
            existing.Status = result.Status;
            existing.TakenAt = DateTime.Now;

            _userModuleQuizResultRepository.UpdateUserModuleQuizResult(existing);
            return true;
        }

        public bool Delete(int resultId)
        {
            return _userModuleQuizResultRepository.DeleteUserModuleQuizResult(resultId);
        }

        public UserModuleQuizResult? GetLatestForLesson(int userId, int lessonId)
        {
            return _userModuleQuizResultRepository.GetLatestUserModuleQuizResultForLesson(userId, lessonId);
        }
    }
}
