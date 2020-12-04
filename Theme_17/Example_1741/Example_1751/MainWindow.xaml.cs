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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Example_1751
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection   con;
        SqlDataAdapter  da;
        DataTable       dt;
        DataRowView     row;

        public MainWindow() { InitializeComponent(); Preparing(); }

        private void AA()
		{
            
		}
        private void Preparing()
        {
            #region Init

            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "MSSQLLocalDemo"
            };

            con = new SqlConnection(connectionStringBuilder.ConnectionString);
            da  = new SqlDataAdapter();
            dt  = new DataTable();

            #endregion

            #region select


            var sql = @"SELECT * FROM Workers Order By Workers.Id";
            da.SelectCommand = new SqlCommand(sql, con);

            #endregion

            #region insert

            sql = @"INSERT INTO Workers (workerName,  idBoss,  idDescription) 
                                 VALUES (@workerName, @idBoss, @idDescription); 
                     SET @id = @@IDENTITY;";

            da.InsertCommand = new SqlCommand(sql, con);

            da.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").Direction = ParameterDirection.Output;
            da.InsertCommand.Parameters.Add("@workerName", SqlDbType.NVarChar, 20, "workerName");
            da.InsertCommand.Parameters.Add("@idBoss", SqlDbType.Int, 4, "idBoss");
            da.InsertCommand.Parameters.Add("@idDescription", SqlDbType.Int, 4, "idDescription");

            #endregion

            #region update

            sql = @"UPDATE Workers SET 
                           workerName = @workerName,
                           idBoss = @idBoss, 
                           idDescription = @idDescription 
                    WHERE id = @id";

            da.UpdateCommand = new SqlCommand(sql, con);
            da.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id").SourceVersion = DataRowVersion.Original;
            da.UpdateCommand.Parameters.Add("@workerName", SqlDbType.NVarChar, 20, "workerName");
            da.UpdateCommand.Parameters.Add("@idBoss", SqlDbType.Int, 4, "idBoss");
            da.UpdateCommand.Parameters.Add("@idDescription", SqlDbType.Int, 4, "idDescription");

            #endregion

            #region delete

            sql = "DELETE FROM Workers WHERE id = @id";

            da.DeleteCommand = new SqlCommand(sql, con);
            da.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id");

            #endregion

            da.Fill(dt);

            gridView.DataContext = dt.DefaultView;
        }
         
        /// <summary>
        /// Начало редактирования 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GVCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            row = (DataRowView)gridView.SelectedItem;
            row.BeginEdit();
            //da.Update(dt);
        }

        /// <summary>
        /// Редактирование записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GVCurrentCellChanged(object sender, EventArgs e)
        {
            if (row == null) return;
            row.EndEdit();
            da.Update(dt);
        }
 
        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemDeleteClick(object sender, RoutedEventArgs e)
        {
            row = (DataRowView)gridView.SelectedItem;
            row.Row.Delete();
            da.Update(dt);
        }

        /// <summary>
        /// Добавление записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemAddClick(object sender, RoutedEventArgs e)
        {
            DataRow r = dt.NewRow();
            AddWindow add = new AddWindow(r);
            add.ShowDialog();


            if (add.DialogResult.Value)
            {
                dt.Rows.Add(r);
                da.Update(dt);
            }
        }

        private void AllViewShow(object sender, RoutedEventArgs e)
        {
            new AllView().ShowDialog();
        }

        
    }
}
