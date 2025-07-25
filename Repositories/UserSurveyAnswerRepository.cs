using BusinessObjects;
using DataAccessLayer;
using Repositories.Interface.UserRepo;
using Microsoft.EntityFrameworkCore;

public class UserSurveyAnswerRepository : IUserSurveyAnswerRepository
{
    private readonly DrugPreventSystemContext _context;

    public UserSurveyAnswerRepository(DrugPreventSystemContext context)
    {
        _context = context;
    }

    public UserSurveyAnswer AddNewUserSurveyAnswer(UserSurveyAnswer userSurveyAnswer)
    {
        _context.UserSurveyAnswers.Add(userSurveyAnswer);
        _context.SaveChanges();
        return userSurveyAnswer;
    }

    public void DeleteUserSurveyAnswerById(int id)
    {
        var answer = _context.UserSurveyAnswers.Find(id);
        if (answer != null)
        {
            _context.UserSurveyAnswers.Remove(answer);
            _context.SaveChanges();
        }
    }

    public List<UserSurveyAnswer> GetAllUserSurveyAnswers()
    {
        return _context.UserSurveyAnswers.ToList();
    }

    public UserSurveyAnswer? GetUserSurveyAnswerById(int id)
    {
        return _context.UserSurveyAnswers.FirstOrDefault(a => a.AnswerId == id);
    }

    public List<UserSurveyAnswer> GetUserSurveyAnswerByResponseId(int responseId)
    {
        return _context.UserSurveyAnswers
                       .Where(a => a.ResponseId == responseId)
                       .Include(a => a.Question)
                       .Include(a => a.Option)
                       .ToList();
    }

    public List<UserSurveyAnswer> GetUserSurveyAnswerByUserId(int userId)
    {
        return _context.UserSurveyAnswers
                       .Include(a => a.Response)
                       .Where(a => a.Response.UserId == userId)
                       .ToList();
    }

    public void UpdateUserSurveyAnswer(UserSurveyAnswer userSurveyAnswer)
    {
        _context.UserSurveyAnswers.Update(userSurveyAnswer);
        _context.SaveChanges();
    }
}
