using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;


namespace Repositories.Interface.UserRepo
{
    public interface IUserQuizAnswerRepository
    {
        List<UserQuizAnswer> GetUserQuizAnswers();
        UserQuizAnswer? GetUserQuizAnswerById(Guid userQuizAnswerId);
        List<UserQuizAnswer> GetUserQuizAnswersByUserId(Guid userId);
        List<UserQuizAnswer> GetUserQuizAnswersByQuestionId(Guid questionId);
        UserQuizAnswer AddUserQuizAnswer(UserQuizAnswer userQuizAnswer);
        UserQuizAnswer UpdateUserQuizAnswer(UserQuizAnswer userQuizAnswer);
        bool DeleteUserQuizAnswer(Guid userQuizAnswerId);
        List<UserQuizAnswer> GetUserQuizAnswersByUserIdAndQuizId(Guid userId, Guid quizId);
        List<UserQuizAnswer> GetUserQuizAnswersForQuizAttempt(Guid userId, Guid quizId, DateTime takenAt);
    }

}
