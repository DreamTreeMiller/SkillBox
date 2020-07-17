﻿using System;
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
using Homework_01;

namespace Example_1041
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository rep;
        public MainWindow()
        {
            InitializeComponent();

            rep = new Repository(50);
            listView.ItemsSource = rep.Workers;

            this.Title = $"Всего сотрудников: {rep.Workers.Count}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            rep.DeleteWorkerBySalary(30000);
            this.Title = $"Всего сотрудников: {rep.Workers.Count}";
            listView.Items.Refresh();
        }
    }
}