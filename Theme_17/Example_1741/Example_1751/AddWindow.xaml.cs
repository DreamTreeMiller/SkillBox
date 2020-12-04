using System;
using System.Collections.Generic;
using System.Data;
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

namespace Example_1751
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private AddWindow() { InitializeComponent(); }

        public AddWindow(DataRow row):this()
        {
            cancelBtn.Click += delegate { this.DialogResult = false; };
            okBtn.Click += delegate
            {
                row["WorkerName"] = txtWorkerName.Text;
                row["IdBoss"] = txtIdBoss.Text;
                row["idDescription"] = txtDescription.Text;
                this.DialogResult = !false;
            };

        }

    }
}
