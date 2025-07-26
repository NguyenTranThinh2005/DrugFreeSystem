using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ThePresentation.CoursePage.Converter
{
    public class ResourceTypeToIconConverter : IValueConverter
    {
        //public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    string resourceType = value as string;
        //    string iconPath = "pack://application:,,,/Images/default.png"; // fallback

        //    if (resourceType != null)
        //    {
        //        switch (resourceType.ToLower())
        //        {
        //            case "video":
        //                iconPath = "pack://application:,,,/Images/video.png";
        //                break;
        //            case "pdf":
        //                iconPath = "pack://application:,,,/Images/pdf.png";
        //                break;
        //            case "image":
        //                iconPath = "pack://application:,,,/Images/image.png";
        //                break;
        //            case "quiz":
        //                iconPath = "pack://application:,,,/Images/quiz.png";
        //                break;
        //            case "link":
        //                iconPath = "pack://application:,,,/Images/link.png";
        //                break;
        //        }
        //    }

        //    try
        //    {
        //        return new BitmapImage(new Uri(iconPath));
        //    }
        //    catch
        //    {
        //        // Tránh app crash nếu icon không tồn tại → fallback dùng default
        //        return new BitmapImage(new Uri("pack://application:,,,/Images/default.png"));
        //    }
        //}
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new BitmapImage(new Uri("pack://application:,,,/Images/default.png"));
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
