
using BusinessObjects;
using DrugPreventionSystem.BusinessLogic.Services.Interfaces;
using Repositories.Interface.UserRepo;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPreventionSystem.DataAccess.Repositories
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public List<User> GetAll() => _repo.GetAll();

        public User? GetById(int id) => _repo.GetById(id);

        public User? GetByEmail(string email) => _repo.GetByEmail(email);

        public User? GetByUsername(string username) => _repo.GetByUsername(username);

        public void Add(User user) => _repo.Add(user);

        public bool Update(User user) => _repo.Update(user);

        public bool Delete(int id) => _repo.Delete(id);

        public string Login(string email, string password)
        {
            var user = _repo.GetByEmail(email);
            if (user == null) return "Email không tồn tại.";

            if (user.Password != password )
                return "Mật khẩu không đúng.";

            if (!user.IsActive) return "Tài khoản bị khóa.";

            return "Đăng nhập thành công.";
        }

        public string Register(string username, string email, string password)
        {
            if (_repo.GetByUsername(username) != null)
                return "Username đã tồn tại.";

            if (_repo.GetByEmail(email) != null)
                return "Email đã tồn tại.";

            var role = _repo.GetRoleByName("Member");
            if (role == null)
                return "Không tìm thấy quyền 'Member'."; ;

            var user = new User
            {

                Username = username,
                Email = email,
                Password= password,
                IsActive = true,
                EmailVerified = false,
                CreatedAt = DateTime.Now,
                RoleId = role.RoleId,
                Role = role
            };

            _repo.Add(user);
            return "Đăng ký thành công.";
        }

    }
}
