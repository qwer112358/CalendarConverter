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

namespace CalendarConverter
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void AddDaysButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = datePicker.SelectedDate ?? DateTime.Today;

            if (long.TryParse(daysTextBox.Text, out long days))
            {
                DateTime resultDate = selectedDate.AddDays(days);

                resultTextBlock.Text = resultDate.ToString("yyyy-MM-dd");
            }
            else
            {
                MessageBox.Show("Некорректный ввод!", "Ошибка ввода!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SubtractDaysButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = datePicker.SelectedDate ?? DateTime.Today;

            if (long.TryParse(daysTextBox.Text, out long days))
            {
                DateTime resultDate = selectedDate.AddDays(-days);

                resultTextBlock.Text = resultDate.ToString("yyyy-MM-dd");
            }
            else
            {
                MessageBox.Show("Некорректный ввод!", "Ошибка ввода!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
