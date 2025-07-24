using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories.Interface.UserRepo
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User? GetById(Guid id);
        User? GetByEmail(string email);
        User? GetByUsername(string username);
        void Add(User user);
        bool Update(User user);
        bool Delete(Guid id);
        Role? GetRoleByName(string roleName);
    }
}
