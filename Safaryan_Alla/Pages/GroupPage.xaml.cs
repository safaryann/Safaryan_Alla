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
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для GroupPage.xaml
    /// </summary>
    public partial class GroupPage : Page
    {
        private GroupRepository _repository;

        public GroupPage()
        {
            InitializeComponent();
            _repository = new GroupRepository();
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            GroupsDataGrid.ItemsSource = _repository.GetList();
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
                var groupRepository = new GroupRepository();
                var searchResults = groupRepository.Search(search);

                var searchViewModels = searchResults.Select(result => new GroupViewModel
                {
                    GroupName = result.GroupName
                }).ToList();

                GroupsDataGrid.ItemsSource = searchViewModels;
            }
        }

        private void AddGroupButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Hide();
            var groupCard = new GroupCardWindow();
            groupCard.ShowDialog();
            UpdateGrid();
            mainWindow.Show();
        }

        private void UpdateGroupsButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateGrid();
        }

        private void DeleteGroupButton_Click(object sender, RoutedEventArgs e)
        {
            if (GroupsDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Ничего не выбрано для удаления");
            }
            var item = GroupsDataGrid.SelectedItem as GroupViewModel;
            if (item == null)
            {
                MessageBox.Show("Не удалось получить данные");
            }
            else
            {
                _repository.Delete(item.GroupId);
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
