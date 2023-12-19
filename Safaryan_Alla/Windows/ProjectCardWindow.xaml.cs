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
    /// Логика взаимодействия для ProjectCardWindow.xaml
    /// </summary>
    public partial class ProjectCardWindow : Window
    {
        private ProjectViewModel _selectedItem = null;
        private ProjectRepository _repository;
        public ProjectCardWindow()
        {
            InitializeComponent();
        }

        public ProjectCardWindow(ProjectViewModel selectedItem)
        {
            InitializeComponent();
            if (selectedItem != null)
            {
                _selectedItem = selectedItem;
                NameTextBox.Text = selectedItem.Name;
                DescriptionTextBox.Text = selectedItem.Description;
                ProjectLeaderTextBox.Text = selectedItem.ProjectLeader;
                StartDateTextBox.Text = selectedItem.StartDate;
                PlanEndDateTextBox.Text = selectedItem.PlanEndDate;
                GroupIdTextBox.Text = selectedItem.GroupId;
            }
            else
            {
                _selectedItem = selectedItem;
                NameTextBox.Text = null;
                DescriptionTextBox.Text = null;
                ProjectLeaderTextBox.Text = null;
                StartDateTextBox.Text = null;
                PlanEndDateTextBox.Text = null;
                GroupIdTextBox.Text = null;
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
                _repository = new ProjectRepository();
                if (NameTextBox.Text.Count() != 0)
                {
                    if (_selectedItem != null)
                    {
                        var entity = new ProjectViewModel
                        {
                            ProjectId = _selectedItem.ProjectId,
                            Name = NameTextBox.Text,
                            Description = DescriptionTextBox.Text,
                            ProjectLeader = ProjectLeaderTextBox.Text,
                            StartDate = StartDateTextBox.Text,
                            PlanEndDate = PlanEndDateTextBox.Text,
                            GroupId = GroupIdTextBox.Text,
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
                        var entity = new ProjectViewModel
                        {
                            Name = NameTextBox.Text,
                            Description = DescriptionTextBox.Text,
                            ProjectLeader = ProjectLeaderTextBox.Text,
                            StartDate = StartDateTextBox.Text,
                            PlanEndDate = PlanEndDateTextBox.Text,
                            GroupId = GroupIdTextBox.Text,
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
                    MessageBox.Show("Поля не должны быть пустыми!");
                }

            }
            catch
            {
                MessageBox.Show("Не все поля заполнены!");
            }
        }
    }
}
