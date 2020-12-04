using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Example_1542_Library
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class BarChart : UserControl
    {
        public IEnumerable Data
        {
            get => list.ItemsSource;
            set => list.ItemsSource = value;
        }


        public BarChart()
        {
            InitializeComponent();
            list.ItemsSource = Data;
        }

         
    }

}
