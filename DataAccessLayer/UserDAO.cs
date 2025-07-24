using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class UserDAO
    {
        private readonly DrugFreeSystemDbContext _context;

        public UserDAO(DrugFreeSystemDbContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.Include(u => u.Role).ToList();
        }

        public User? GetUserById(Guid id)
        {
            return _context.Users.Include(u => u.Role).FirstOrDefault(u => u.UserId == id);
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == email);
        }

        public User? GetUserByUsername(string username)
        {
            return _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Username == username);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(Guid id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public Role? GetRoleById(int roleId)
        {
            return _context.Roles.FirstOrDefault(r => r.RoleId == roleId);
        }

        public Role? GetRoleByName(string roleName)
        {
            return _context.Roles.FirstOrDefault(r => r.RoleName == roleName);
        }

        public List<Role> GetSpecificRoles(params string[] roleNames)
        {
            return _context.Roles
                           .Where(r => roleNames.Contains(r.RoleName))
                           .ToList();
        }
    }
}
