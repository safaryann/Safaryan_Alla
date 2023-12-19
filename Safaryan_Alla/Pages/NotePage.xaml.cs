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
    /// Логика взаимодействия для NotePage.xaml
    /// </summary>
    public partial class NotePage : Page
    {
        private NoteRepository _repository;

        public NotePage()
        {
            InitializeComponent();
            _repository = new NoteRepository();
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            NotesDataGrid.ItemsSource = _repository.GetList();
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
                var noteRepository = new NoteRepository();
                var searchResults = noteRepository.Search(search);

                var searchViewModels = searchResults.Select(result => new NoteViewModel
                {
                    ShortDescription = result.ShortDescription
                }).ToList();

                NotesDataGrid.ItemsSource = searchViewModels;
            }
        }

        private void AddNoteButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Hide();
            var noteCard = new NoteCardWindow();
            noteCard.ShowDialog();
            UpdateGrid();
            mainWindow.Show();
        }

        private void UpdateNotesButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateGrid();
        }
        private void DeleteNoteButton_Click(object sender, RoutedEventArgs e)
        {
            if (NotesDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Ничего не выбрано для удаления");
            }
            var item = NotesDataGrid.SelectedItem as NoteViewModel;
            if (item == null)
            {
                MessageBox.Show("Не удалось получить данные");
            }
            else
            {
                _repository.Delete(item.NoteId);
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
