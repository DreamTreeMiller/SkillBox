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

namespace WPF_test
{
    public partial class MainWindow : Window
    {

        class Str
        { public string Text { get; set; } };
        List<Str> listOfStrings = new List<Str>(10);
        Random r = new Random();
        public MainWindow()
        {
            InitializeComponent();
           for (int i = 0; i< 10; i++)
                    listOfStrings.Add(new Str()
                    {
                        Text = "".PadLeft(r.Next(1, 100), (char)r.Next((int)'A', (int)'Z'))
                    }
                                     );
                showList.ItemsSource = listOfStrings;
        }

    }
}
