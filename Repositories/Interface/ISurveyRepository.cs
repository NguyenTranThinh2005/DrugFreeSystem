using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;


namespace Repositories.Interface.SurveyRepo
{
    public interface ISurveyRepository
    {
        Survey AddNewSurvey(Survey survey);
        List<Survey> GetAllSurvey();
        Survey? GetSurveyById(int id);
        Survey? GetSurveyByName(string surveyName);
        bool DeleteSurveyById(int id);
        bool UpdateSurvey(Survey survey);
    }
}
