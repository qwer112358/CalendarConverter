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
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(valueTextBox.Text, out double value))
            {
                string fromUnit = ((ComboBoxItem)fromUnitComboBox.SelectedItem).Content.ToString();
                string toUnit = ((ComboBoxItem)toUnitComboBox.SelectedItem).Content.ToString();

                double result = ConvertUnits(value, fromUnit, toUnit);

                resultTextBlock.Text = result.ToString("N2");
            }
            else
            {
                MessageBox.Show("Некорректный ввод!", "Ошибка ввода!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private double ConvertUnits(double value, string fromUnit, string toUnit)
        {
            if (fromUnit == toUnit)
            {
                return value;
            }

            double fromUnitValue = GetUnitValue(fromUnit);
            double toUnitValue = GetUnitValue(toUnit);

            double convertedValue = value * fromUnitValue / toUnitValue;

            return convertedValue;
        }

        private double GetUnitValue(string unit)
        {
            switch (unit)
            {
                case "Век":
                    return 365.25 * 100;
                case "Год":
                    return 365.25;
                case "Месяц":
                    return 30.4375;
                case "День":
                    return 1;
                case "Час":
                    return 1.0 / 24;
                case "Минута":
                    return 1.0 / (24 * 60);
                case "Секунда":
                    return 1.0 / (24 * 60 * 60);
                default:
                    throw new ArgumentException("Ошибка ввода!");
            }
        }
    }
}
