﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Page1());

        }

        private void calendarConvertion(object sender, RoutedEventArgs e)
        {
            //MainFrame.Content = new Page1();
            MainFrame.Navigate(new Page1());
        }

        private void dateCalculator(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Page2());
        }
        private void dayConvertion(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Page3());
        }
    }
}
