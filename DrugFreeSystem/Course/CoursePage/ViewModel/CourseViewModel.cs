using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using System.Windows.Media.Imaging;

namespace ThePresentation.CoursePage.ViewModel
{
    public class CourseViewModel
    {
        public Course Course { get; set; }
        public BitmapImage ThumbnailImage { get; set; }

        public CourseViewModel(Course course)
        {
            Course = course;
            ThumbnailImage = ConvertBase64ToImage(course.ThumbnailUrl);
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
    }
}
