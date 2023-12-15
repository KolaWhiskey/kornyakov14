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

namespace kornyakov14
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        const string pass = "123";

        public Window1() => InitializeComponent();

        private void Window_Activated(object sender, EventArgs e)
        {
            Paroli.Focus();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Paroli.Password == pass)
            {
                MainWindow window = new();
                window.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Пароль неверен. Уходи вор");
                Paroli.Focus();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
