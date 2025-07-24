using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DrugFreeSystemDbContext _context;

        public UserRepository(DrugFreeSystemDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users.Include(u => u.Role).ToList();
        }

        public User? GetById(Guid id)
        {
            return _context.Users.Include(u => u.Role).FirstOrDefault(u => u.UserId == id);
        }

        public User? GetByEmail(string email)
        {
            return _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == email);
        }

        public User? GetByUsername(string username)
        {
            return _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Username == username);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool Update(User user)
        {
            _context.Users.Update(user);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(Guid id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            return _context.SaveChanges() > 0;
        }

        public Role? GetRoleByName(string roleName)
        {
            return _context.Roles.FirstOrDefault(r => r.RoleName == roleName);
        }
    }
}
