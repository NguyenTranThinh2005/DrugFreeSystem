using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessObjects;
using DataAccessLayer;
using DrugPreventionSystem.BusinessLogic.Services;
using DrugPreventionSystem.BusinessLogic.Services.Interfaces;
using DrugPreventionSystem.BusinessLogic.Services.Interfaces.Quizzes;
using DrugPreventionSystem.BusinessLogic.Services.Quizzes;
using DrugPreventionSystem.DataAccess.Repositories;
using Repositories;

namespace ThePresentation.Admin
{
    /// <summary>
    /// Interaction logic for AdminScreen.xaml
    /// </summary>
    public partial class AdminScreen : Window
    {
        private readonly ICourseService _courseService;
        private readonly IUserService _userService;
        private readonly IQuizService _quizService;
        private readonly IQuizQuestionService _quizQuestionService;
        private readonly ICourseCertificateService _courseCertificateService;
        private readonly ILessonService _lessonService;
        private readonly IQuizOptionService _quizOptionService;




        private User currentUser;
        private Course? selectedCourse;
        private Lesson? selectedLesson;
        private Quiz? selectedQuiz;
        private QuizQuestion? selectedQuizQuestion;


        public AdminScreen(User admin)
        {
            InitializeComponent();
            var context = new DrugPreventSystemContext();
            _courseService = new CourseService(new CourseRepository(context));
            _userService = new UserService(new UserRepository(context));
            _quizService = new QuizService(new QuizRepository(context));
            _courseCertificateService = new CourseCertificateService(new CourseCertificateRepository(context));
            _lessonService = new LessonService(new LessonRepository(context));
            _quizQuestionService = new QuizQuestionService(new QuizQuestionRepository(context));
            _quizOptionService = new QuizOptionService(new QuizOptionRepository(context));


            currentUser = admin;
            LoadUserList();
            LoadCourses();
            LoadLessons();
            LoadQuizzes();
            LoadQuizQuestions();
            LoadLessonsForQuizCombo();
            LoadCoursesToComboBox();
            LoadQuizzesToComboBoxForQuestions();
        }
        private void LoadCourses()
        {
            var courses = _courseService.GetAll();
            lvProduct.ItemsSource = courses;
            lvProduct.SelectedIndex = -1;
            ClearCourseInputs();
        }
        private void LoadLessons()
        {
            var lessons = _lessonService.GetAll()
                .Where(l => l.Course != null)
                .ToList();

            lvLesson.ItemsSource = lessons;
            lvLesson.SelectedIndex = -1;
            ClearLessonInputs();
        }
        private void LoadRoles()
        {
            var roles = _userService.GetAllRoles();
            cbRole.ItemsSource = roles;
            cbRole.DisplayMemberPath = "RoleName";
            cbRole.SelectedValuePath = "RoleId";
        }
        private void LoadUserList()
        {
            lvUsers.ItemsSource = _userService.GetAll();
            lvUsers.Items.Refresh();
        }


        private void LoadCoursesToComboBox()
        {
            var courses = _courseService.GetAll();
            cmbLessonCourse.ItemsSource = courses;
            cmbLessonCourse.DisplayMemberPath = "Title";
            cmbLessonCourse.SelectedValuePath = "CourseId";
        }
        private void LoadQuizzes()
        {
            var quizzes = _quizService.GetAll();

            var displayList = quizzes.Select(q => new
            {
                q.QuizId,
                q.Title,
                LessonTitle = _lessonService.GetById(q.LessonId)?.Title ?? "Unknown"
            }).ToList();

            lvQuiz.ItemsSource = displayList;

            // Reset form
            txtQuizId.Clear();
            txtQuizTitle.Clear();
            cmbQuizLesson.SelectedIndex = -1;
            selectedQuiz = null;
        }
        private void LoadLessonsForQuizCombo()
        {
            cmbQuizLesson.ItemsSource = _lessonService.GetAll();
            cmbQuizLesson.DisplayMemberPath = "Title";
            cmbQuizLesson.SelectedValuePath = "LessonId";
        }
        private void LoadCertificates()
        {
            var certificates = _courseCertificateService.GetAll();

            var displayList = certificates.Select(c => new
            {
                c.CertificateId,
                UserName = _userService.GetById(c.UserId)?.Username ?? "Unknown",
                CourseTitle = _courseService.GetById(c.CourseId)?.Title ?? "Unknown",
                c.IssuedAt
            }).ToList();

            lvCertificate.ItemsSource = displayList;
        }
        private void LoadQuizQuestions()
        {
            // Lấy tất cả quiz 1 lần duy nhất và tạo từ điển
            var quizDict = _quizService.GetAll()
                             .ToDictionary(q => q.QuizId, q => q.Title);

            var questions = _quizQuestionService.GetAll();

            var displayList = questions.Select(q => new
            {
                q.QuestionId,
                q.QuestionText,
                q.QuestionType,
                q.Sequence,
                q.CreatedAt,
                Title = quizDict.ContainsKey(q.QuizId) ? quizDict[q.QuizId] : "Unknown"
            }).ToList();

            lvQuizQuestion.ItemsSource = displayList;

            ClearQuizQuestionForm();
        }
        private void LoadQuizzesToComboBoxForQuestions()
        {
            var quizzes = _quizService.GetAll();
            cmbQuestionQuiz.ItemsSource = quizzes;
            cmbQuestionQuiz.DisplayMemberPath = "Title";
            cmbQuestionQuiz.SelectedValuePath = "QuizId";
        }
        private void LoadUsers()
        {
            var userList = _userService.GetAll();
            lvUsers.ItemsSource = null;
            lvUsers.ItemsSource = userList;
        }


        private void ClearCourseInputs()
        {
            txtCourseId.Text = "";
            txtTitle.Text = "";
            txtAgeGroup.Text = "";
            txtTotalDuration.Text = "";
            txtIsActive.Text = "";
            selectedCourse = null;
        }
        private void ClearQuizQuestionForm()
        {
            txtQuestionId.Text = "";
            txtQuestionContent.Text = "";
            txtSequence.Text = "";
            dpCreatedAt.SelectedDate = DateTime.Now;
            cmbQuestionQuiz.SelectedIndex = -1;
            cmbQuestionType.SelectedIndex = 0;
            selectedQuizQuestion = null;
        }
        private void ClearUserForm()
        {
            txtUserId.Text = "";
            txtUsername.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            cbRole.SelectedIndex = -1;
            txtIsActive.Text = "";
            txtCreatedAt.Text = "";
        }
        private void ClearLessonInputs()
        {
            txtLessonId.Text = "";
            txtLessonTitle.Text = "";
            cmbLessonCourse.SelectedIndex = -1;
            selectedLesson = null;
        }

        private void lvLesson_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvLesson.SelectedItem is Lesson item)
            {
                int lessonId = item.LessonId;
                selectedLesson = _lessonService.GetById(lessonId);
                if (selectedLesson != null)
                {
                    txtLessonId.Text = selectedLesson.LessonId.ToString();
                    txtLessonTitle.Text = selectedLesson.Title;
                    cmbLessonCourse.SelectedValue = selectedLesson.CourseId;
                }
            }
        }
        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvProduct.SelectedItem is Course course)
            {
                selectedCourse = course;
                txtCourseId.Text = course.CourseId.ToString();
                txtTitle.Text = course.Title;
                txtAgeGroup.Text = course.AgeGroup ?? "";
                txtTotalDuration.Text = course.TotalDuration?.ToString() ?? "";
                txtIsActive.Text = course.IsActive ? "true" : "false";
            }
        }
        private void lvQuiz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvQuiz.SelectedItem is Quiz item)
            {
                int quizId = item.QuizId;
                selectedQuiz = _quizService.GetById(quizId);
                if (selectedQuiz != null)
                {
                    txtQuizId.Text = selectedQuiz.QuizId.ToString();
                    txtQuizTitle.Text = selectedQuiz.Title;
                    cmbQuizLesson.SelectedValue = selectedQuiz.LessonId;
                }
            }
        }
        private void lvQuizQuestion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvQuizQuestion.SelectedItem != null)
            {
                var selected = (dynamic)lvQuizQuestion.SelectedItem;
                selectedQuizQuestion = _quizQuestionService.GetById((int)selected.QuestionId);

                if (selectedQuizQuestion != null)
                {
                    txtQuestionId.Text = selectedQuizQuestion.QuestionId.ToString();
                    txtQuestionContent.Text = selectedQuizQuestion.QuestionText;
                    cmbQuestionQuiz.SelectedValue = selectedQuizQuestion.QuizId;
                    txtSequence.Text = selectedQuizQuestion.Sequence.ToString();
                    dpCreatedAt.SelectedDate = selectedQuizQuestion.CreatedAt;
                    cmbQuestionType.SelectedIndex = 0; // luôn là Multiple Choice
                }
            }
        }
        private void lvUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvUsers.SelectedItem is User user)
            {
                var selectedUser = user;
                txtUserId.Text = user.UserId.ToString();
                txtUsername.Text = user.Username;
                txtEmail.Text = user.Email;
                txtPassword.Text = user.Password;
                cbRole.Text = user.RoleId.ToString();
                txtIsActive.Text = user.IsActive.ToString();
                txtCreatedAt.Text = user.CreatedAt.ToString("yyyy-MM-dd");
            }
        }


        private void btnAddCourse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newCourse = new Course
                {
                    Title = txtTitle.Text,
                    AgeGroup = txtAgeGroup.Text,
                    TotalDuration = int.TryParse(txtTotalDuration.Text, out int duration) ? duration : null,
                    IsActive = bool.TryParse(txtIsActive.Text, out bool isActive) && isActive,
                    CreatedAt = DateTime.Now
                };

                _courseService.Add(newCourse);
                LoadCourses();
                MessageBox.Show("Course added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding course: " + ex.Message);
            }
        }
        private void btnUpdateCourse_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCourse == null)
            {
                MessageBox.Show("Please select a course to update.");
                return;
            }

            try
            {
                selectedCourse.Title = txtTitle.Text;
                selectedCourse.AgeGroup = txtAgeGroup.Text;
                selectedCourse.TotalDuration = int.TryParse(txtTotalDuration.Text, out int duration) ? duration : null;
                selectedCourse.IsActive = bool.TryParse(txtIsActive.Text, out bool isActive) && isActive;
                selectedCourse.UpdatedAt = DateTime.Now;

                bool updated = _courseService.Update(selectedCourse);
                if (updated)
                {
                    LoadCourses();
                    MessageBox.Show("Course updated successfully.");
                }
                else
                {
                    MessageBox.Show("Update failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating course: " + ex.Message);
            }
        }
        private void btnDeleteCourse_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCourse == null)
            {
                MessageBox.Show("Please select a course to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this course?", "Confirm Delete", MessageBoxButton.YesNo);
            if (confirm == MessageBoxResult.Yes)
            {
                try
                {
                    bool deleted = _courseService.Delete(selectedCourse.CourseId);
                    if (deleted)
                    {
                        LoadCourses();
                        MessageBox.Show("Course deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Delete failed.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting course: " + ex.Message);
                }
            }
        }

        // LESSON EVENTS
        private void btnAddLesson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbLessonCourse.SelectedItem is Course selectedCourse)
                {
                    var newLesson = new Lesson
                    {
                        Title = txtLessonTitle.Text,
                        CourseId = selectedCourse.CourseId
                    };

                    _lessonService.Add(newLesson);
                    LoadLessons();
                    MessageBox.Show("Lesson added successfully.");
                }
                else
                {
                    MessageBox.Show("Please select a course.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding lesson: " + ex.Message);
            }
        }
        private void btnUpdateLesson_Click(object sender, RoutedEventArgs e)
        {
            if (selectedLesson == null)
            {
                MessageBox.Show("Please select a lesson to update.");
                return;
            }

            try
            {
                if (cmbLessonCourse.SelectedItem is Course selectedCourse)
                {
                    selectedLesson.Title = txtLessonTitle.Text;
                    selectedLesson.CourseId = selectedCourse.CourseId;

                    bool updated = _lessonService.Update(selectedLesson);
                    if (updated)
                    {
                        LoadLessons();
                        MessageBox.Show("Lesson updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Update failed.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a course.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating lesson: " + ex.Message);
            }
        }
        private void btnDeleteLesson_Click(object sender, RoutedEventArgs e)
        {
            if (selectedLesson == null)
            {
                MessageBox.Show("Please select a lesson to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this lesson?", "Confirm Delete", MessageBoxButton.YesNo);
            if (confirm == MessageBoxResult.Yes)
            {
                try
                {
                    bool deleted = _lessonService.Delete(selectedLesson.LessonId);
                    if (deleted)
                    {
                        LoadLessons();
                        MessageBox.Show("Lesson deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Delete failed.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting lesson: " + ex.Message);
                }
            }
        }

        // QUIZ EVENTS
        private void btnAddQuiz_Click(object sender, RoutedEventArgs e)
        {
            int lessonId = (int)cmbQuizLesson.SelectedValue;

            try
            {
                var quiz = new Quiz
                {
                    Title = txtQuizTitle.Text,
                    LessonId = lessonId
                };

                _quizService.Add(quiz);
                MessageBox.Show("Quiz added successfully.");
                LoadQuizzes();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message); // "Each lesson can have only one quiz."
            }
        }
        private void btnUpdateQuiz_Click(object sender, RoutedEventArgs e)
        {
            if (selectedQuiz == null)
            {
                MessageBox.Show("Please select a quiz to update.");
                return;
            }

            try
            {
                if (cmbQuizLesson.SelectedItem is Lesson selectedLesson)
                {
                    selectedQuiz.Title = txtQuizTitle.Text;
                    selectedQuiz.LessonId = selectedLesson.LessonId;

                    bool updated = _quizService.Update(selectedQuiz);
                    if (updated)
                    {
                        LoadQuizzes();
                        MessageBox.Show("Quiz updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Update failed.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a lesson.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating quiz: " + ex.Message);
            }
        }
        private void btnDeleteQuiz_Click(object sender, RoutedEventArgs e)
        {
            if (selectedQuiz == null)
            {
                MessageBox.Show("Please select a quiz to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this quiz?", "Confirm Delete", MessageBoxButton.YesNo);
            if (confirm == MessageBoxResult.Yes)
            {
                try
                {
                    bool deleted = _quizService.Delete(selectedQuiz.QuizId);
                    if (deleted)
                    {
                        LoadQuizzes();
                        MessageBox.Show("Quiz deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Delete failed.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting quiz: " + ex.Message);
                }
            }
        }


        // QUIZ QUESTION EVENTS
        private void btnAddQuestion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbQuestionQuiz.SelectedItem is Quiz quiz)
                {
                    var questionText = txtQuestionContent.Text.Trim();
                    var sequenceText = txtSequence.Text.Trim();
                    var createdAt = dpCreatedAt.SelectedDate ?? DateTime.Now;

                    if (string.IsNullOrWhiteSpace(questionText))
                    {
                        MessageBox.Show("Question content is required.");
                        return;
                    }

                    if (!int.TryParse(sequenceText, out int sequence))
                    {
                        MessageBox.Show("Invalid sequence number.");
                        return;
                    }

                    var newQuestion = new QuizQuestion
                    {
                        QuestionText = questionText,
                        QuizId = quiz.QuizId,
                        QuestionType = "Multiple Choice",
                        Sequence = sequence,
                        CreatedAt = createdAt
                    };

                    _quizQuestionService.Add(newQuestion);
                    LoadQuizQuestions();
                    ClearQuizQuestionForm();
                    MessageBox.Show("Question added successfully.");
                }
                else
                {
                    MessageBox.Show("Please select a quiz.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding question: " + ex.Message);
            }
        }
        private void btnUpdateQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (selectedQuizQuestion == null)
            {
                MessageBox.Show("Please select a question to update.");
                return;
            }

            try
            {
                if (cmbQuestionQuiz.SelectedItem is Quiz quiz)
                {
                    var questionText = txtQuestionContent.Text.Trim();
                    var sequenceText = txtSequence.Text.Trim();
                    var createdAt = dpCreatedAt.SelectedDate ?? DateTime.Now;

                    if (string.IsNullOrWhiteSpace(questionText))
                    {
                        MessageBox.Show("Question content is required.");
                        return;
                    }

                    if (!int.TryParse(sequenceText, out int sequence))
                    {
                        MessageBox.Show("Invalid sequence number.");
                        return;
                    }

                    selectedQuizQuestion.QuestionText = questionText;
                    selectedQuizQuestion.QuizId = quiz.QuizId;
                    selectedQuizQuestion.QuestionType = "Multiple Choice";
                    selectedQuizQuestion.Sequence = sequence;
                    selectedQuizQuestion.CreatedAt = createdAt;

                    bool updated = _quizQuestionService.Update(selectedQuizQuestion);
                    if (updated)
                    {
                        LoadQuizQuestions();
                        ClearQuizQuestionForm();
                        MessageBox.Show("Question updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Update failed.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a quiz.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating question: " + ex.Message);
            }
        }
        private void btnDeleteQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (selectedQuizQuestion == null)
            {
                MessageBox.Show("Please select a question to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this question?", "Confirm Delete", MessageBoxButton.YesNo);
            if (confirm == MessageBoxResult.Yes)
            {
                try
                {
                    bool deleted = _quizQuestionService.Delete(selectedQuizQuestion.QuestionId);
                    if (deleted)
                    {
                        LoadQuizQuestions();
                        ClearQuizQuestionForm();
                        MessageBox.Show("Question deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Delete failed.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting question: " + ex.Message);
                }
            }
        }

        //QUIZ OPTION
        private void btnViewOptions_Click(object sender, RoutedEventArgs e)
        {
            if (lvQuizQuestion.SelectedItem == null)
            {
                MessageBox.Show("Please select a question to view its options.");
                return;
            }

            dynamic selected = lvQuizQuestion.SelectedItem;
            int questionId = selected.QuestionId;

            var optionWindow = new QuizOptionsWindow(_quizOptionService, questionId);
            optionWindow.ShowDialog();
        }
        // USER EVENT
        private void btnUpdateUser_Click(object sender, RoutedEventArgs e)
        {
            if (lvUsers.SelectedItem is not User user) return;

            user.Username = txtUsername.Text;
            user.Email = txtEmail.Text;
            user.Password = txtPassword.Text;
            user.RoleId = (int)(cbRole.SelectedValue ?? 0);
            user.IsActive = chkUserIsActive.IsChecked == true;

            _userService.Update(user);
            LoadUsers();
        }
        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (lvUsers.SelectedItem is User selectedUser)
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa người dùng '{selectedUser.Username}'?",
                    "Xác nhận xóa",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    bool deleted = _userService.Delete(selectedUser.UserId);
                    if (deleted)
                    {
                        MessageBox.Show("Xóa người dùng thành công.");
                        LoadUserList(); // viết thêm hàm này để reload lại danh sách
                        ClearUserForm(); // xóa dữ liệu khỏi textbox
                    }
                    else
                    {
                        MessageBox.Show("Xóa người dùng thất bại.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn người dùng để xóa.");
            }
        }



        // CERTIFICATE EVENTS
        private void btnSearchCertificate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Search Certificate clicked (not yet implemented)");
        }

    }
}
