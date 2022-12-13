using ekzam_Gromyko.AppDataFile;
using ekzam_Gromyko.Pages;
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

namespace ekzam_Gromyko
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User _currentuser = new User();
        public static Frame MainFrame;
        public MainWindow(int _ID, string _FirstName, string _LastName, string _MiddleName)
        {
            InitializeComponent();
            if (_ID == 11 || _ID == 12 || _ID == 13)
            {
                
            }
            else
            {
                MainFrame.Navigate(new ExecutorPage());
            }
            FullName.Text = $"{_FirstName} {_LastName} {_MiddleName}";
        }

        
        private void autorizateBtn(object sender, RoutedEventArgs e)
        {
            LoginWindow mainWindow = new LoginWindow();
            mainWindow.Show();
            Close();
        }
    }
}
