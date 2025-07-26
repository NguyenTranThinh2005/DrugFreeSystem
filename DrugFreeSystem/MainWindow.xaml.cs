using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessObjects;
using DataAccessLayer;
using DrugPreventionSystem.BusinessLogic.Services.Interfaces;
using DrugPreventionSystem.DataAccess.Repositories;
using Repositories;
using ThePresentation.Admin;

namespace DrugFreeSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUserService _userService;
        public MainWindow()
        {
            InitializeComponent();
            var context = new DrugPreventSystemContext();
            _userService = new UserService(new UserRepository(context));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            var result = _userService.Login(email, password, out User? user);

            if (result == "Đăng nhập thành công.")
            {
                if (user!.RoleId == 1)
                {
                    AdminScreen admin = new AdminScreen(user);
                    admin.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền truy cập Admin.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show(result, "Lỗi đăng nhập", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}