using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using System.Windows.Input;
using System.Windows;
using ThePresentation.CoursePage.Command;

namespace ThePresentation.CoursePage.ViewModel
{
    public class LessonResourceViewModel
    {
        public Lesson Lesson { get; set; }
        public ObservableCollection<LessonResource> Resources { get; set; }

        public ICommand OpenResourceCommand { get; }

        public LessonResourceViewModel(Lesson lesson)
        {
            Lesson = lesson;
            Resources = new ObservableCollection<LessonResource>(
                lesson.LessonResources ?? new List<LessonResource>()
            );
            OpenResourceCommand = new RelayCommand<LessonResource>(OpenResource);
        }

        private void OpenResource(LessonResource resource)
        {
            if (!string.IsNullOrWhiteSpace(resource?.ResourceUrl))
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = resource.ResourceUrl,
                        UseShellExecute = true
                    });
                }
                catch
                {
                    MessageBox.Show("Không thể mở tài nguyên này.");
                }
            }
        }
    }
}
