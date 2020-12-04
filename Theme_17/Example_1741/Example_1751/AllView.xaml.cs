using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class AllView : Window
    {
        public AllView()
        {
            InitializeComponent();

            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "MSSQLLocalDemo"
            };

            SqlConnection  con = new SqlConnection(connectionStringBuilder.ConnectionString);
            DataTable dt = new DataTable();

           SqlDataAdapter da = new SqlDataAdapter();

            var sql = @"SELECT 
Workers.id as 'ID',
Workers.workerName as 'Имя сотрудника',
Bosses.workerName  as 'Имя начальника',
Bosses.departmentName  as 'Имя отдела',
[Description].[value] as 'Замечание'
FROM  Workers, Bosses, [Description]
WHERE Workers.idBoss = Bosses.id and Workers.idDescription = [Description].id
Order By Workers.Id";
            da.SelectCommand = new SqlCommand(sql, con);
            da.Fill(dt);

            gridAllView.DataContext = dt.DefaultView;
        }
    }
}
