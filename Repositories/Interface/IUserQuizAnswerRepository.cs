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
        UserQuizAnswer? GetUserQuizAnswerById(int userQuizAnswerId);
        List<UserQuizAnswer> GetUserQuizAnswersByUserId(int userId);
        List<UserQuizAnswer> GetUserQuizAnswersByQuestionId(int questionId);
        UserQuizAnswer AddUserQuizAnswer(UserQuizAnswer userQuizAnswer);
        UserQuizAnswer UpdateUserQuizAnswer(UserQuizAnswer userQuizAnswer);
        bool DeleteUserQuizAnswer(int userQuizAnswerId);
        List<UserQuizAnswer> GetUserQuizAnswersByUserIdAndQuizId(int userId, int quizId);
        List<UserQuizAnswer> GetUserQuizAnswersForQuizAttempt(int userId, int quizId, DateTime takenAt);
    }

}
