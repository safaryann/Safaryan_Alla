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
    /// Логика взаимодействия для GroupCardWindow.xaml
    /// </summary>
    public partial class GroupCardWindow : Window
    {
        private GroupViewModel _selectedItem = null;
        private GroupRepository _repository;
        public GroupCardWindow()
        {
            InitializeComponent();
        }

        public GroupCardWindow(GroupViewModel selectedItem)
        {
            InitializeComponent();
            if (selectedItem != null)
            {
                _selectedItem = selectedItem;
                GroupNameTextBox.Text = selectedItem.GroupName;
                GroupLeaderTextBox.Text = selectedItem.GroupLeader;
            }
            else
            {
                _selectedItem = selectedItem;
                GroupNameTextBox.Text = null;
                GroupLeaderTextBox.Text = null;
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
                _repository = new GroupRepository();
                if (GroupNameTextBox.Text.Count() != 0)
                {
                    if (_selectedItem != null)
                    {
                        var entity = new GroupViewModel
                        {
                            GroupId = _selectedItem.GroupId,
                            GroupName = GroupNameTextBox.Text,
                            GroupLeader = GroupLeaderTextBox.Text,
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
                        var entity = new GroupViewModel
                        {
                            GroupName = GroupNameTextBox.Text,
                            GroupLeader = GroupLeaderTextBox.Text,
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
                    MessageBox.Show("Поле 'Название группы' должно быть заполнено!");
                }

            }
            catch
            {
                MessageBox.Show("Не все поля заполнены!");
            }
        }
    }
}
