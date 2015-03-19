using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace deadcode.DeepSearch
{
    /// <summary>
    /// Interaction logic for DeepSearchControl.xaml
    /// </summary>
    public partial class DeepSearchControl : UserControl
    {
        public DeepSearchControl()
        {
            InitializeComponent();
        }

        private DataTable GetDataTable(string connectionString, string sql)
        {
            try
            {
                using (OleDbConnection myConnection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand myCommand = new OleDbCommand(sql, myConnection))
                    {
                        myConnection.Open();
                        using (OleDbDataReader myReader = myCommand.ExecuteReader())
                        {
                            DataTable myTable = new DataTable();
                            myTable.Load(myReader);
                            myConnection.Close();
                            return myTable;
                        }
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Exception: {0}",
                            e.Message),
                           "DeepSearch");
            }

            return null;
        }

        private void r2_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.Contains('.') && e.Column is DataGridBoundColumn)
            {
                DataGridBoundColumn dataGridBoundColumn = e.Column as DataGridBoundColumn;
                dataGridBoundColumn.Binding = new Binding("[" + e.PropertyName + "]");
            }
        }

        public DataTable MyDataTable { get; private set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string queryString = queryText.Text;

            if (gridResults.IsEnabled)
            {
                gridResults.IsEnabled = false;
                new Thread(() =>
                {
                    try
                    {
                        this.Dispatcher.Invoke((Action)(() =>
                        {
                            MyDataTable = GetDataTable("Provider=Search.CollatorDSO;Extended Properties='Application=Windows';", queryString);
                            
                            if(MyDataTable != null) gridResults.ItemsSource = MyDataTable.DefaultView;

                            gridResults.IsEnabled = true;
                        }));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Exception: {0}",
                            ex.Message),
                           "DeepSearch");
                    }
                }).Start();
            }
            else
            {
                MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Search is running"),
                           "DeepSearch");
            }
        }
    }
}