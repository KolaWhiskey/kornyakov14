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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Zap_Click(object sender, RoutedEventArgs e)
        {
            int value;
            if (Int32.TryParse(Columns1.Text, out value))
                Class2.Column22 = value;
            else
            {
                MessageBox.Show("Ошибка");
                Columns1.Focus();
                return;
            }

            if (Int32.TryParse(Rows1.Text, out value))
                Class2.Row22 = value;
            else
            {
                MessageBox.Show("Ошибка");
                Rows1.Focus();
                return;
            }

            if (Int32.TryParse(MinZnach1.Text, out value))
                Class2.Min22 = value;
            else
            {
                MessageBox.Show("Ошибка");
                MinZnach1.Focus();
                return;
            }

            if (Int32.TryParse(MaxZnach1.Text, out value))
                Class2.Max22 = value;
            else
            {
                MessageBox.Show("Ошибка");
                MaxZnach1.Focus();
                return;
            }
            Close();
        }
    }
}
