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
using DrugPreventionSystem.BusinessLogic.Services.Interfaces.Quizzes;

namespace ThePresentation.Admin
{
    /// <summary>
    /// Interaction logic for QuizOptionsWindow.xaml
    /// </summary>
    public partial class QuizOptionsWindow : Window
    {
        private readonly int _questionId;
        private readonly IQuizOptionService _quizOptionService;
        private QuizOption? selectedOption;
        public QuizOptionsWindow(IQuizOptionService quizOptionService, int questionId)
        {
            InitializeComponent();
            _questionId = questionId;
            _quizOptionService = quizOptionService;

            LoadOptions();
        }
        private void LoadOptions()
        {
            var options = _quizOptionService.GetAll()
                             .Where(o => o.QuestionId == _questionId)
                             .ToList();

            lvOptions.ItemsSource = options;
            ClearForm();
        }

        private void ClearForm()
        {
            txtOptionText.Text = "";
            chkIsCorrect.IsChecked = false;
            selectedOption = null;
        }

        private void lvOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvOptions.SelectedItem is QuizOption option)
            {
                selectedOption = option;
                txtOptionText.Text = option.OptionText;
                chkIsCorrect.IsChecked = option.IsCorrect;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var newOption = new QuizOption
            {
                QuestionId = _questionId,
                OptionText = txtOptionText.Text.Trim(),
                IsCorrect = chkIsCorrect.IsChecked ?? false,
                CreatedAt = DateTime.Now
            };

            _quizOptionService.Add(newOption);
            LoadOptions();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (selectedOption == null) return;

            selectedOption.OptionText = txtOptionText.Text.Trim();
            selectedOption.IsCorrect = chkIsCorrect.IsChecked ?? false;

            _quizOptionService.Update(selectedOption);
            LoadOptions();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedOption != null)
            {
                _quizOptionService.Delete(selectedOption.OptionId);
                LoadOptions();
            }
        }
    }
}
