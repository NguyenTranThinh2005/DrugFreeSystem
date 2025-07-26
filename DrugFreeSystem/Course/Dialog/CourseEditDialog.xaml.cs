using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using Microsoft.Win32;

namespace ThePresentation.Dialog
{
    /// <summary>
    /// Interaction logic for CourseEditDialog.xaml
    /// </summary>
    public partial class CourseEditDialog : Window, INotifyPropertyChanged
    {
        public Course Course { get; set; }
        public bool IsEditMode { get; set; }

        private BitmapImage _imagePreview;
        public BitmapImage ImagePreview
        {
            get => _imagePreview;
            set
            {
                _imagePreview = value;
                OnPropertyChanged(nameof(ImagePreview));
            }
        }

        public CourseEditDialog()
        {
            InitializeComponent();
            Course = new Course();
            IsEditMode = false;
            DataContext = this;
        }

        public CourseEditDialog(Course courseToEdit)
        {
            InitializeComponent();
            Course = new Course
            {
                CourseId = courseToEdit.CourseId,
                Title = courseToEdit.Title,
                Description = courseToEdit.Description,
                AgeGroup = courseToEdit.AgeGroup,
                ThumbnailUrl = courseToEdit.ThumbnailUrl
            };

            IsEditMode = true;
            if (!string.IsNullOrEmpty(Course.ThumbnailUrl))
                ImagePreview = LoadImageFromBase64(Course.ThumbnailUrl);

            DataContext = this;
        }

        private void ChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg"
            };

            if (dialog.ShowDialog() == true)
            {
                byte[] imageBytes = File.ReadAllBytes(dialog.FileName);
                Course.ThumbnailUrl = Convert.ToBase64String(imageBytes);
                ImagePreview = LoadImageFromBase64(Course.ThumbnailUrl);
            }
        }

        private BitmapImage LoadImageFromBase64(string base64)
        {
            if (string.IsNullOrEmpty(base64)) return null;

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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Course.Title))
            {
                MessageBox.Show("Vui lòng nhập tên khóa học.");
                return;
            }

            this.DialogResult = true;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string prop) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
