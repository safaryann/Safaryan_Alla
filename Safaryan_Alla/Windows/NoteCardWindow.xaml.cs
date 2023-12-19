using Safaryan_Alla.Infrastructure.Database;
using Safaryan_Alla.Infrastructure.ViewModels;
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

namespace Safaryan_Alla.Windows
{
    /// <summary>
    /// Логика взаимодействия для NoteCardWindow.xaml
    /// </summary>
    public partial class NoteCardWindow : Window
    {
        private NoteViewModel _selectedItem = null;
        private NoteRepository _repository;
        public NoteCardWindow()
        {
            InitializeComponent();
        }

        public NoteCardWindow(NoteViewModel selectedItem)
        {
            InitializeComponent();
            if (selectedItem != null)
            {
                _selectedItem = selectedItem;
                NoteDateTextBox.Text = selectedItem.NoteDate;
                CreatorNameTextBox.Text = selectedItem.CreatorName;
                ShortDescriptionTextBox.Text = selectedItem.ShortDescription;
                DetailedDescriptionTextBox.Text = selectedItem.DetailedDescription;
                ProjectIdTextBox.Text = selectedItem.ProjectId;
            }
            else
            {
                _selectedItem = selectedItem;
                NoteDateTextBox.Text = null;
                CreatorNameTextBox.Text = null;
                ShortDescriptionTextBox.Text = null;
                DetailedDescriptionTextBox.Text = null;
                ProjectIdTextBox.Text = null;
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _repository = new NoteRepository();
                if (ProjectIdTextBox.Text.Count() != 0)
                {
                    if (_selectedItem != null)
                    {
                        var entity = new NoteViewModel
                        {
                            NoteId = _selectedItem.NoteId,
                            NoteDate = NoteDateTextBox.Text,
                            CreatorName = CreatorNameTextBox.Text,
                            ShortDescription = ShortDescriptionTextBox.Text,
                            DetailedDescription = DetailedDescriptionTextBox.Text,
                            ProjectId = ProjectIdTextBox.Text,
                        };
                        if (_repository != null)
                        {
                            _repository.Update(entity);
                            Window.GetWindow(this).Close();
                        }
                        else
                        {
                            MessageBox.Show("Неизвестная ошибка.");
                        }
                    }
                    else
                    {
                        var entity = new NoteViewModel
                        {
                            NoteDate = NoteDateTextBox.Text,
                            CreatorName = CreatorNameTextBox.Text,
                            ShortDescription = ShortDescriptionTextBox.Text,
                            DetailedDescription = DetailedDescriptionTextBox.Text,
                            ProjectId = ProjectIdTextBox.Text,
                        };
                        if (_repository != null)
                        {
                            _repository.Add(entity);
                            Window.GetWindow(this).Close();
                        }
                        else
                        {
                            MessageBox.Show("Неизвестная ошибка.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Созранение не возможно без привязки к проекту!");
                }

            }
            catch
            {
                MessageBox.Show("Не все поля заполнены!");
            }
        }
    }
}
