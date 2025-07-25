using BusinessObjects;
using DrugPreventionSystem.BusinessLogic.Services.Interfaces;
using DrugPreventionSystem.DataAccess.Repository;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Repositories.Interface.SurveyRepo;
using Repositories.Interface.UserRepo;

namespace DrugPreventionSystem.BusinessLogic.Services
{
    public class UserSurveyResponseService : IUserSurveyResponseService
    {
        private readonly IUserSurveyResponseRepository _userSurveyResponseRepository;

        public UserSurveyResponseService(IUserSurveyResponseRepository userSurveyResponseRepository)
        {
            _userSurveyResponseRepository = userSurveyResponseRepository;
        }

        public List<UserSurveyResponse> GetAll()
        {
            return _userSurveyResponseRepository.GetAll();
        }

        public UserSurveyResponse? GetById(int id)
        {
            return _userSurveyResponseRepository.GetById(id);
        }

        public string Add(UserSurveyResponse userSurveyResponse)
        {
            var added = _userSurveyResponseRepository.Create(userSurveyResponse);
            if (added != null)
            {
                return $"Created successfully with ID: {added.ResponseId}";
            }
            return "Failed to create UserSurveyResponse.";
        }

        public bool Update(UserSurveyResponse userSurveyResponse)
        {
            return _userSurveyResponseRepository.Update(userSurveyResponse);

        }

        public bool Delete(int id)
        {
            return _userSurveyResponseRepository.Delete(id);
        }
    }
}