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
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void ProjectButton_Click(object sender, RoutedEventArgs e)
        {
            ProjectPage projectPage = new ProjectPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = projectPage.Title;
            mainWindow.MainFrame.Navigate(projectPage);
        }

        private void GroupButton_Click(object sender, RoutedEventArgs e)
        {
            GroupPage groupPage = new GroupPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = groupPage.Title;
            mainWindow.MainFrame.Navigate(groupPage);
        }
        private void NotesButton_Click(object sender, RoutedEventArgs e)
        {
            NotePage notePage = new NotePage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = notePage.Title;
            mainWindow.MainFrame.Navigate(notePage);
        }
    }
}
