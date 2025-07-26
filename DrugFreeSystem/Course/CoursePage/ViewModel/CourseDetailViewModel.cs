using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DrugPreventionSystem.BusinessLogic.Services.Interfaces;
using System.Windows.Input;
using DataAccessLayer;
using Repositories;
using Repositories.Interface;
using ThePresentation.CoursePage;
using ThePresentation.CoursePage.Command;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.IO;
namespace ThePresentation.CoursePage.ViewModel
{
    public class CourseDetailViewModel : INotifyPropertyChanged
    {
        public BitmapImage ThumbnailImage => ConvertBase64ToImage(Course?.ThumbnailUrl);
        public ICommand ForceOpenLessonCommand { get; }


        public Course Course { get; set; }
        public ObservableCollection<LessonViewModel> Lessons { get; set; } = new();
        public bool IsEnrolled { get; set; }

        public ICommand EnrollCommand { get; }
        public ICommand StartLessonCommand { get; }

        private readonly int _userId;

        // Dùng repository trực tiếp
        private readonly UserCourseEnrollmentRepository _enrollmentRepo;
        private readonly LessonRepository _lessonRepo;

        public CourseDetailViewModel(Course course, int userId)
        {
            Course = course;
            _userId = userId;

            // Khởi tạo context và repository (có thể DI nếu muốn)
            var context = new DrugPreventSystemContext();
            _enrollmentRepo = new UserCourseEnrollmentRepository(context);
            _lessonRepo = new LessonRepository(context);

            EnrollCommand = new RelayCommand(Enroll);
            StartLessonCommand = new RelayCommand<Lesson>(StartLesson);
            ForceOpenLessonCommand = new RelayCommand<Lesson>(ForceOpenLesson);

            LoadCourseDetails();
        }
        private void ForceOpenLesson(Lesson lesson)
        {
            var fullLesson = _lessonRepo.GetLessonWithResources(lesson.LessonId);
            if (fullLesson != null)
            {
                var window = new LessonResourseWindow(fullLesson);
                window.Show();
            }
        }


        private void LoadCourseDetails()
        {
            var enrolled = _enrollmentRepo.GetByUserIdAndCourseId(_userId, Course.CourseId);
            IsEnrolled = enrolled != null;
            OnPropertyChanged(nameof(IsEnrolled));

            var lessons = _lessonRepo.GetLessonsByCourseId(Course.CourseId);
            Lessons.Clear();
            foreach (var lesson in lessons.OrderBy(l => l.Sequence))
            {
                Lessons.Add(new LessonViewModel(lesson));
            }
        }

        private void Enroll()
        {
            var already = _enrollmentRepo.GetByUserIdAndCourseId(_userId, Course.CourseId);
            if (already == null)
            {
                _enrollmentRepo.Add(new UserCourseEnrollment
                {
                    UserId = _userId,
                    CourseId = Course.CourseId,
                    EnrolledAt = DateTime.Now
                });

                IsEnrolled = true;
                OnPropertyChanged(nameof(IsEnrolled));
            }
        }
        private BitmapImage ConvertBase64ToImage(string base64)
        {
            if (string.IsNullOrEmpty(base64)) return null;

            try
            {
                byte[] binaryData = Convert.FromBase64String(base64);
                BitmapImage bmp = new BitmapImage();
                using (MemoryStream stream = new MemoryStream(binaryData))
                {
                    bmp.BeginInit();
                    bmp.CacheOption = BitmapCacheOption.OnLoad;
                    bmp.StreamSource = stream;
                    bmp.EndInit();
                    bmp.Freeze();
                }
                return bmp;
            }
            catch
            {
                return null;
            }
        }

        private void StartLesson(Lesson lesson)
        {
            // Mở cửa sổ học bài
            var window = new LessonResourseWindow(lesson);
            window.Show();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
