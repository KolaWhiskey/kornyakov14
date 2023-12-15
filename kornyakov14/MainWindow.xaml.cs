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

namespace kornyakov14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int[,] matrix;
        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Infa_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вариант 7. Корняков Д.Д " +
         "Дана матрица размера M * N. Найти номера строки и столбца для " +
         "элемента матрицы, наиболее близкого к среднему значению всех ее элементов.",
         "Задание",
         MessageBoxButton.OK,
         MessageBoxImage.Asterisk);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result;
            result = MessageBox.Show("Вы точно хотити уйти",
            "Выход",
            MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Rows.Clear();
            Columns.Clear();
            MinZnach.Clear();
            MaxZnach.Clear();
            ResultRow.Clear();
            ResultColumn.Clear();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            VisualArray.Save(matrix);
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            matrix = VisualArray.Open();

            Matrica.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
        }

        private void Zapolniti_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rows = Convert.ToInt32(Rows.Text),
                    colums = Convert.ToInt32(Columns.Text),
                    minValue = Convert.ToInt32(MinZnach.Text),
                    maxValue = Convert.ToInt32(MaxZnach.Text);


                matrix = new int[rows, colums];

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = rnd.Next(minValue, maxValue + 1);
                    }
                }

                Matrica.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
                TableSize.Text = $"{Convert.ToInt32(Rows.Text)}:{Convert.ToInt32(Columns.Text)}";

            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void Rechenie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double avg = GetAverage(matrix);

                int MinItem = matrix[0, 0],
                Row = 0,
                Colum = 0;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (Math.Abs(avg - matrix[i, j]) < Math.Abs(avg - MinItem))
                        {
                            MinItem = matrix[i, j];
                            Row = i;
                            Colum = j;
                        }
                    }
                }
                Row++;
                Colum++;
                ResultRow.Text = Row.ToString();
                ResultColumn.Text = Colum.ToString();
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!");
            }


        }

        private double GetAverage(int[,] matrix)
        {
            int summ = 0;

            foreach (int i in matrix)
            {
                summ += i;
            }

            return summ / matrix.Length;
        }

        private void Matrica_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Matrica_PreparingCellForEdit(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            int index0 = e.Column.DisplayIndex;
            int index1 = e.Row.GetIndex();
            Number.Text = $"{index0 + 1}:{index1 + 1}";
        }

        private void Matrica_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Char var = Convert.ToChar(e.Text);
            if (Char.IsDigit(var)) ;
            else
            {
                MessageBox.Show("gg");
                e.Handled = true;
            }
        }

        private void btnPr_Click(object sender, RoutedEventArgs e)
        {
            Window2 wpr = new();
            wpr.Show();
        }



        private void Window_Activated(object sender, EventArgs e)
        {
            Rows.Text = Class2.Row22.ToString();
            Columns.Text = Class2.Column22.ToString();
            MaxZnach.Text = Class2.Max22.ToString();
            MinZnach.Text = Class2.Min22.ToString();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Вы желаете завершить работу с программой", "Выход из программы", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }
    }
}
