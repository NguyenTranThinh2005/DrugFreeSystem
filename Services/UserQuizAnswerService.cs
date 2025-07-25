﻿using System;
using System.Collections.Generic;
using System.Linq;
using DrugPreventionSystem.BusinessLogic.Services.Interfaces;
using Repositories.Interface.UserRepo;
using BusinessObjects;

namespace DrugPreventionSystem.BusinessLogic.Services
{
    public class UserQuizAnswerService : IUserQuizAnswerService
    {
        private readonly IUserQuizAnswerRepository _userQuizAnswerRepository;

        public UserQuizAnswerService(IUserQuizAnswerRepository userQuizAnswerRepository)
        {
            _userQuizAnswerRepository = userQuizAnswerRepository;
        }

        public void Add(UserQuizAnswer answer)
        {
            if (answer == null)
                throw new ArgumentNullException(nameof(answer));

            _userQuizAnswerRepository.AddUserQuizAnswer(answer);
        }

        public bool Delete(int id)
        {
            return _userQuizAnswerRepository.DeleteUserQuizAnswer(id);
        }

        public List<UserQuizAnswer> GetAll()
        {
            return _userQuizAnswerRepository.GetUserQuizAnswers();
        }

        public UserQuizAnswer? GetById(int id)
        {
            return _userQuizAnswerRepository.GetUserQuizAnswerById(id);
        }

        public List<UserQuizAnswer> GetByQuestionId(int questionId)
        {
            return _userQuizAnswerRepository.GetUserQuizAnswersByQuestionId(questionId);
        }

        public List<UserQuizAnswer> GetByUserId(int userId)
        {
            return _userQuizAnswerRepository.GetUserQuizAnswersByUserId(userId);
        }

        public bool Update(UserQuizAnswer answer)
        {
            if (answer == null)
                throw new ArgumentNullException(nameof(answer));

            var existing = _userQuizAnswerRepository.GetUserQuizAnswerById(answer.QuestionId);
            if (existing == null)
                return false;

            // Update fields
            existing.SelectedOptionId = answer.SelectedOptionId;
            existing.AnswerText = answer.AnswerText;
            existing.AnsweredAt = DateTime.Now;

            _userQuizAnswerRepository.UpdateUserQuizAnswer(existing);
            return true;
        }
        public List<UserQuizAnswer> GetByUserIdAndQuizId(int userId, int quizId)
        {
            return _userQuizAnswerRepository.GetUserQuizAnswersByUserIdAndQuizId(userId, quizId);
        }

        public List<UserQuizAnswer> GetForQuizAttempt(int userId, int quizId, DateTime takenAt)
        {
            return _userQuizAnswerRepository.GetUserQuizAnswersForQuizAttempt(userId, quizId, takenAt);
        }

    }
}
