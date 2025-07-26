using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace ThePresentation.CoursePage.ViewModel
{
    public class LessonViewModel
    {
        public Lesson Lesson { get; }

        public string QuizOrPractice => Lesson.HasQuiz ? "Quiz" : "Luyện tập";

        public LessonViewModel(Lesson lesson)
        {
            Lesson = lesson;
        }
    }
}