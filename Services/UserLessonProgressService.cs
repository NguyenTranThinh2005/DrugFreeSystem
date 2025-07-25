using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DrugPreventionSystem.BusinessLogic.Services.Interfaces;
using Repositories.Interface.LessonRepo;
using Repositories.Interface.UserRepo;

namespace DrugPreventionSystem.BusinessLogic.Services
{
    public class UserLessonProgressService : IUserLessonProgressService
    {
        private readonly IUserLessonProgressRepository _userLessonProgressRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly IUserRepository _userRepository;

        public UserLessonProgressService(
            IUserLessonProgressRepository userLessonProgressRepository,
            ILessonRepository lessonRepository,
            IUserRepository userRepository)
        {
            _userLessonProgressRepository = userLessonProgressRepository;
            _lessonRepository = lessonRepository;
            _userRepository = userRepository;
        }

        public void Add(UserLessonProgress request)
        {
            var progress = new UserLessonProgress
            {

                UserId = request.UserId,
                LessonId = request.LessonId,
                CompletedAt = request.CompletedAt,
                QuizScore = request.QuizScore,
                Passed = request.Passed,
                UpdatedAt = DateTime.Now
            };

            _userLessonProgressRepository.AddUserLessonProgress(progress);
        }

        public bool Delete(int progressId)
        {
            return _userLessonProgressRepository.DeleteUserLessonProgress(progressId);
        }

        public UserLessonProgress? GetById(int progressId)
        {
            return _userLessonProgressRepository.GetUserLessonProgressById(progressId);
        }

        public List<UserLessonProgress> GetByLessonId(int lessonId)
        {
            return _userLessonProgressRepository.GetUserLessonProgressByLessonId(lessonId);
        }

        public List<UserLessonProgress> GetByUserId(int userId)
        {
            return _userLessonProgressRepository.GetUserLessonProgressByUserId(userId);
        }

        public List<UserLessonProgress> GetAll()
        {
            return _userLessonProgressRepository.GetUserLessonProgresses();
        }

        public bool Update(UserLessonProgress request)
        {
            var existing = _userLessonProgressRepository.GetUserLessonProgressById(request.ProgressId);
            if (existing == null) return false;

            existing.UserId = request.UserId;
            existing.LessonId = request.LessonId;
            existing.CompletedAt = request.CompletedAt;
            existing.QuizScore = request.QuizScore;
            existing.Passed = request.Passed;
            existing.UpdatedAt = DateTime.Now;

           _userLessonProgressRepository.UpdateUserLessonProgress(existing);
            return true;
        }
    }
}
