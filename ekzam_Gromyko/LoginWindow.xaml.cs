using ekzam_Gromyko.AppDataFile;
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

namespace ekzam_Gromyko
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private User _currentuser = new User();
        public LoginWindow()
        {
            InitializeComponent();
            nowDate.Text = nowDate.Text + " " + DateTime.Now.ToString("dd MMMM yyyy");
            ZPNow.Text = ZPNow.Text + " " + DateTime.Now.AddMonths(1).ToString("5 MMMM yyyy");
            var db = GromykoEntities.GetContext().Task.ToList();
            byte j = 0;
            foreach (var abc in db)
            {
                if(abc.Status == "запланирована")
                {
                    j += 1;
                }
            }
            TaskNow.Text = TaskNow.Text + " " + (j);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool log = false;
            foreach (var a in GromykoEntities.GetContext().User)
            {
                if (Login.Text == a.Login)
                {
                    log = true;
                    if (Password.Password == a.Password)
                    {
                        MessageBox.Show("Успешная авторизация");
                        ShowMain(a.ID, a.FirstName, a.LastName, a.MiddleName);
                        Close();

                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль");

                    }
                }
            }
            if (log == false)
            {
                MessageBox.Show("Неверный логин");
            }
        }
        public void ShowMain(int _ID, string _FirstName, string _LastName, string _MiddleName)
        {
            MainWindow mainWindow = new MainWindow(_ID, _FirstName, _LastName, _MiddleName);
            mainWindow.Show();
        }

    }
}
