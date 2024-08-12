using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    /// 
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            selectDate1.ItemsSource = calendars;
            selectDate2.ItemsSource = calendars;
        }

        public string[] calendars = new string[]
        {
            "Григорианская дата", "Юлианская дата", "Исламская дата"
        };


        private void btnConvert(object sender, RoutedEventArgs e)
        {
            if (selectDate1.Text == calendars[0] && selectDate2.Text == calendars[1]) txtdata2.Text = gregorianToJulian();
            else if (selectDate1.Text == calendars[0] && selectDate2.Text == calendars[2]) txtdata2.Text = gregorianToIslamic();
            else if (selectDate1.Text == calendars[1] && selectDate2.Text == calendars[0]) txtdata2.Text = julianToGregorian();
            else if (selectDate1.Text == calendars[1] && selectDate2.Text == calendars[2]) txtdata2.Text = julianToIslamic();
            else if (selectDate1.Text == calendars[2] && selectDate2.Text == calendars[0]) txtdata2.Text = islamicToGregorian();
            else if (selectDate1.Text == calendars[2] && selectDate2.Text == calendars[1]) txtdata2.Text = islamicToJulian();
        }

        private string gregorianToJulian()
        {
            string gregorianDateStr = txtdata1.Text.Trim();
            // Convert the input Gregorian date to DateTime
            if (DateTime.TryParse(gregorianDateStr, out DateTime gregorianDate))
            {
                // Convert the Gregorian date to Julian
                double julianDate = (gregorianDate.ToOADate() + 2415018.5);
                leepYear1.Text = DateTime.IsLeapYear(gregorianDate.Year) ? "Високосный" : "Невисокосный год";

                // Get the day of the week
                weekday1.Text = gregorianDate.DayOfWeek.ToString();
                return julianDate.ToString();
            }
            else
            {
                MessageBox.Show("Некорректный ввод даты!", "Ошибка ввода!", MessageBoxButton.OK, MessageBoxImage.Error);
                return string.Empty;
            }
        }

        private string gregorianToIslamic()
        {
            string gregorianDateStr = txtdata1.Text.Trim();
            if (DateTime.TryParse(gregorianDateStr, out DateTime gregorianDate))
            {
                CultureInfo hijriCulture = new CultureInfo("ar-SA");
                DateTimeFormatInfo hijriFormat = hijriCulture.DateTimeFormat;
                leepYear1.Text = DateTime.IsLeapYear(gregorianDate.Year) ? "Високосный" : "Невисокосный год";
                // Get the day of the week
                weekday1.Text = gregorianDate.DayOfWeek.ToString();
                return gregorianDate.ToString("d", hijriFormat);
            }
            else
            {
                MessageBox.Show("Некорректный ввод даты!", "Ошибка ввода!", MessageBoxButton.OK, MessageBoxImage.Error);
                return string.Empty;
            }
        }

        private string julianToGregorian()
        {
            string julianDateStr = txtdata1.Text.Trim();
            // Convert the input Julian date to double
            if (double.TryParse(julianDateStr, out double julianDate))
            {
                // Convert the Gregorian date to Julian
                double gregorianDateDouble = julianDate - 2415018.5;
                DateTime gregorianDate = DateTime.FromOADate(gregorianDateDouble);
                leepYear1.Text = DateTime.IsLeapYear(gregorianDate.Year) ? "Високосный" : "Невисокосный год";
                // Get the day of the week
                weekday1.Text = gregorianDate.DayOfWeek.ToString();
                return gregorianDate.ToString();
            }
            else
            {
                MessageBox.Show("Некорректный ввод даты!", "Ошибка ввода!", MessageBoxButton.OK, MessageBoxImage.Error);
                return string.Empty;
            }
        }

        private string julianToIslamic()
        {
            string julianDateStr = txtdata1.Text.Trim();
            if (double.TryParse(julianDateStr, out double julianDate))
            {
                string gregorian = julianToGregorian();
                txtdata1.Text = gregorian;
                string islamicDate = gregorianToIslamic();
                txtdata2.Text = islamicDate;
                txtdata1.Text = julianDateStr;

                return islamicDate;
            }
            else
            {
                MessageBox.Show("Некорректный ввод даты!", "Ошибка ввода!", MessageBoxButton.OK, MessageBoxImage.Error);
                return string.Empty;
            }
        }

        private string islamicToGregorian()
        {
            // Get the input Hijri date
            string hijriDateStr = txtdata1.Text.Trim();

            // Convert the input Hijri date to DateTime
            CultureInfo hijriCulture = new CultureInfo("ar-SA");
            DateTimeFormatInfo hijriFormat = hijriCulture.DateTimeFormat;
            hijriFormat.Calendar = new HijriCalendar();
            if (DateTime.TryParseExact(hijriDateStr, "d", hijriFormat, DateTimeStyles.None, out DateTime hijriDate))
            {
                // Convert the Hijri date to Gregorian
                DateTime gregorianDate = hijriDate;
                leepYear1.Text = DateTime.IsLeapYear(hijriDate.Year) ? "Високосный" : "Невисокосный год";
                // Get the day of the week
                weekday1.Text = hijriDate.DayOfWeek.ToString();
                return gregorianDate.ToString();
            }
            else
            {
                MessageBox.Show("Некорректный ввод даты!", "Ошибка ввода!", MessageBoxButton.OK, MessageBoxImage.Error);
                return string.Empty;
            }
        }

        private string islamicToJulian()
        {
            string hijriDateStr = txtdata1.Text.Trim();
            CultureInfo hijriCulture = new CultureInfo("ar-SA");
            DateTimeFormatInfo hijriFormat = hijriCulture.DateTimeFormat;
            hijriFormat.Calendar = new HijriCalendar();
            if (DateTime.TryParseExact(hijriDateStr, "d", hijriFormat, DateTimeStyles.None, out DateTime hijriDate))
            {
                string gregorian = islamicToGregorian();
                txtdata1.Text = gregorian;
                string isJulianDate = gregorianToJulian();
                txtdata2.Text = isJulianDate;
                txtdata1.Text = hijriDateStr;
                leepYear1.Text = DateTime.IsLeapYear(hijriDate.Year) ? "Високосный" : "Невисокосный год";
                // Get the day of the week
                weekday1.Text = hijriDate.DayOfWeek.ToString();
                return isJulianDate;
            }
            else
            {
                MessageBox.Show("Некорректный ввод даты!", "Ошибка ввода!", MessageBoxButton.OK, MessageBoxImage.Error);
                return string.Empty;
            }
        }
        private bool isLeapYear(int year)
        {
            if (year % 4 != 0 || year % 400 != 0)
                return false;
            else if (year % 100 != 0)
                return true;
            else
                return true;
        }
    }
}
