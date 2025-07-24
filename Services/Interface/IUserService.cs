using BusinessObjects;
using System;
using System.Collections.Generic;

namespace DrugPreventionSystem.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
        User? GetById(Guid id);
        string Register(string username, string email, string password);
        bool Update(User user);
        bool Delete(Guid id);
        string Login(string emailOrUsername, string password);
    }
}
