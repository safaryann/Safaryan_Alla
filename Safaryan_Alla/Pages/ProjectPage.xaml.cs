using Safaryan_Alla.Infrastructure.Database;
using Safaryan_Alla.Infrastructure.ViewModels;
using Safaryan_Alla.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Safaryan_Alla.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProjectPage.xaml
    /// </summary>
    public partial class ProjectPage : Page
    {
        private ProjectRepository _repository;

        public ProjectPage()
        {
            InitializeComponent();
            _repository = new ProjectRepository();
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            ProjectsDataGrid.ItemsSource = _repository.GetList();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string search = SearchTextBox.Text;

            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Поисковый запрос не может быть пустым.");
            }
            else
            {
                var projectRepository = new ProjectRepository();
                var searchResults = projectRepository.Search(search);

                var searchViewModels = searchResults.Select(result => new ProjectViewModel
                {
                    Name = result.Name
                }).ToList();

                ProjectsDataGrid.ItemsSource = searchViewModels;
            }
        }

        private void AddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Hide();
            var projectCard = new ProjectCardWindow();
            projectCard.ShowDialog();
            UpdateGrid();
            mainWindow.Show();
        }
        private void UpdateProjectsButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateGrid();
        }

        private void DeleteProjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectsDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Ничего не выбрано для удаления");
            }
            var item = ProjectsDataGrid.SelectedItem as ProjectViewModel;
            if (item == null)
            {
                MessageBox.Show("Не удалось получить данные");
            }
            else
            {
                _repository.Delete(item.ProjectId);
                UpdateGrid();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MenuPage menuPage = new MenuPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = menuPage.Title;
            mainWindow.MainFrame.Navigate(menuPage);
        }
    }
}
