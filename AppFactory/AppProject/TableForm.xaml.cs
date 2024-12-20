using AppProject.TablesRes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
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
using DataBaser;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;

namespace AppProject
{
    /// <summary>
    /// Логика взаимодействия для TableForm.xaml
    /// </summary>
    public partial class TableForm : Window
    {
        DataBase databace = new DataBase();
        public ObservableCollection<Details> DetailsCollection { get; set; } = new ObservableCollection<Details>();
        public ObservableCollection<ActiveDetail> ActiveDetailCollection { get; set; } = new ObservableCollection<ActiveDetail>();
        public ObservableCollection<Sell> SellCollection { get; set; } = new ObservableCollection<Sell>();
        public ObservableCollection<Supply> SupplyCollection { get; set; } = new ObservableCollection<Supply>();
        public DataGrid Grid1;
        public DataGrid Grid2;
        public DataGrid Grid3;
        public DataGrid Grid4;
        public object mySel;
        public TableForm(int role)
        {
            InitializeComponent();
            Button Rep = (Button)this.FindName("Отчёт");
            Button Add = (Button)this.FindName("Добавить");
            Button Red = (Button)this.FindName("Изменить");
            Button Del = (Button)this.FindName("Удалить");
            bool adm = false;
            if (role == 0)
                adm = true;
            else
                adm = false;
            if (adm)
            {
                Add.Visibility = Visibility.Hidden;
                Red.Visibility = Visibility.Hidden;
                Del.Visibility = Visibility.Hidden;
                Rep.Visibility = Visibility.Visible;
            }
            else
            {
                Rep.Visibility = Visibility.Hidden;
                Add.Visibility = Visibility.Visible;
                Red.Visibility = Visibility.Visible;
                Del.Visibility = Visibility.Visible;
            }
            DataGrid dataGrid1 = (DataGrid)this.FindName("Склад_таблица");
            DataGrid dataGrid2 = (DataGrid)this.FindName("В_продаже_таблица");
            DataGrid dataGrid3 = (DataGrid)this.FindName("Поставки_таблица");
            DataGrid dataGrid4 = (DataGrid)this.FindName("Продажи_таблица");
            Grid1 = dataGrid1;
            Grid2 = dataGrid2;
            Grid3 = dataGrid3;
            Grid4 = dataGrid4;
            dataGrid1.ItemsSource = DetailsCollection;
            dataGrid2.ItemsSource = ActiveDetailCollection;
            dataGrid3.ItemsSource = SupplyCollection;
            dataGrid4.ItemsSource = SellCollection;
            GridBlid(dataGrid1, 0);
            GridBlid(dataGrid2, 1);
            GridBlid(dataGrid3, 2);
            GridBlid(dataGrid4, 3);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   
            Button me = (Button)sender;
            Button Kostl1 = (Button)this.FindName("Склад_костыль");
            Button Kostl2 = (Button)this.FindName("В_продаже_костыль");
            Button Kostl3 = (Button)this.FindName("Поставки_костыль");
            Button Kostl4 = (Button)this.FindName("Продажи_костыль");
            DataGrid dataGrid1 = (DataGrid)this.FindName("Склад_таблица");
            DataGrid dataGrid2 = (DataGrid)this.FindName("В_продаже_таблица");
            DataGrid dataGrid3 = (DataGrid)this.FindName("Поставки_таблица");
            DataGrid dataGrid4 = (DataGrid)this.FindName("Продажи_таблица");
            if (me.Name == "Назад")
            {
                MainWindow newForm = new MainWindow();
                newForm.Show();
                this.Close();
            }
            if (me.Name == "Склад")
            {
                Kostl1.Visibility = Visibility.Visible;
                Kostl2.Visibility = Visibility.Hidden;
                Kostl3.Visibility = Visibility.Hidden;
                Kostl4.Visibility = Visibility.Hidden;
                dataGrid1.Visibility = Visibility.Visible;
                dataGrid2.Visibility = Visibility.Hidden;
                dataGrid3.Visibility = Visibility.Hidden;
                dataGrid4.Visibility = Visibility.Hidden;

            }
            if (me.Name == "В_продаже")
            {
                Kostl1.Visibility = Visibility.Hidden;
                Kostl2.Visibility = Visibility.Visible;
                Kostl3.Visibility = Visibility.Hidden;
                Kostl4.Visibility = Visibility.Hidden;
                dataGrid1.Visibility = Visibility.Hidden;
                dataGrid2.Visibility = Visibility.Visible;
                dataGrid3.Visibility = Visibility.Hidden;
                dataGrid4.Visibility = Visibility.Hidden;
            }
            if (me.Name == "Поставки")
            {
                Kostl1.Visibility = Visibility.Hidden;
                Kostl2.Visibility = Visibility.Hidden;
                Kostl3.Visibility = Visibility.Visible;
                Kostl4.Visibility = Visibility.Hidden;
                dataGrid1.Visibility = Visibility.Hidden;
                dataGrid2.Visibility = Visibility.Hidden;
                dataGrid3.Visibility = Visibility.Visible;
                dataGrid4.Visibility = Visibility.Hidden;
            }
            if (me.Name == "Продажи")
            {
                Kostl1.Visibility = Visibility.Hidden;
                Kostl2.Visibility = Visibility.Hidden;
                Kostl3.Visibility = Visibility.Hidden;
                Kostl4.Visibility = Visibility.Visible;
                dataGrid1.Visibility = Visibility.Hidden;
                dataGrid2.Visibility = Visibility.Hidden;
                dataGrid3.Visibility = Visibility.Hidden;
                dataGrid4.Visibility = Visibility.Visible;
            }
            if (me.Name == "Поиск")
            {
                byte mod;
                if (dataGrid1.Visibility == Visibility.Visible)
                    mod = 0;
                else if (dataGrid2.Visibility == Visibility.Visible)
                    mod = 1;
                else if (dataGrid3.Visibility == Visibility.Visible)
                    mod = 2;
                else
                    mod = 3;
                SearchForm newForm = new SearchForm(mod,0,this);
                newForm.ShowDialog();
            }
            if (me.Name == "Добавить")
            {
                byte mod;
                if (dataGrid1.Visibility == Visibility.Visible)
                    mod = 0;
                else if (dataGrid2.Visibility == Visibility.Visible)
                    mod = 1;
                else if (dataGrid3.Visibility == Visibility.Visible)
                    mod = 2;
                else
                    mod = 3;
                SearchForm newForm = new SearchForm(mod, 1,this);
                newForm.ShowDialog();
            }
            if (me.Name == "Изменить")
            {
                byte mod;
                if (dataGrid1.Visibility == Visibility.Visible)
                {
                    mod = 0;
                    mySel = Grid1.SelectedItem;
                }
                else if (dataGrid2.Visibility == Visibility.Visible)
                {
                    mod = 1;
                    mySel = Grid2.SelectedItem;
                }
                else if (dataGrid3.Visibility == Visibility.Visible)
                {
                    mod = 2;
                    mySel = Grid3.SelectedItem;
                }
                else
                {
                    mod = 3;
                    mySel = Grid4.SelectedItem;
                }
                SearchForm newForm = new SearchForm(mod, 2,this);
                newForm.ShowDialog();
                mySel = null;
            }
            if (me.Name == "Удалить")
            {
                DataGrid mod;
                databace.openConnection();
                if (dataGrid1.Visibility == Visibility.Visible && dataGrid1.SelectedItem != null)
                {   
                    Details Sel = dataGrid1.SelectedItem as Details;
                    string delQuery = $"delete from Details where ID = {Sel.ID}";
                    SqlCommand command = new SqlCommand(delQuery, databace.getConnection());
                    command.ExecuteNonQuery();
                    delQuery = $"SELECT * from Details";
                    command = new SqlCommand(delQuery, databace.getConnection());
                    databace.openConnection();
                    ClearTable(0);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ReadRow(reader, 0);
                    }
                    reader.Close();

                }
                else if (dataGrid2.Visibility == Visibility.Visible && dataGrid2.SelectedItem != null)
                {
                    ActiveDetail Sel = dataGrid2.SelectedItem as ActiveDetail;
                    string delQuery = $"delete from Active_details where ID_details = {Sel.ID_details}";
                    SqlCommand command = new SqlCommand(delQuery, databace.getConnection());
                    command.ExecuteNonQuery();
                    delQuery = $"SELECT * from Active_details";
                    command = new SqlCommand(delQuery, databace.getConnection());
                    databace.openConnection();
                    ClearTable(1);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ReadRow(reader, 1);
                    }
                    reader.Close();
                }
                else if (dataGrid3.Visibility == Visibility.Visible && dataGrid3.SelectedItem != null)
                {
                    Supply Sel = dataGrid3.SelectedItem as Supply;
                    string delQuery = $"delete from Supply where ID_details = {Sel.ID_details}";
                    SqlCommand command = new SqlCommand(delQuery, databace.getConnection());
                    command.ExecuteNonQuery();
                    delQuery = $"SELECT * from Supply";
                    command = new SqlCommand(delQuery, databace.getConnection());
                    databace.openConnection();
                    ClearTable(2);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ReadRow(reader, 2);
                    }
                    reader.Close();
                }
                else if(dataGrid4.Visibility == Visibility.Visible && dataGrid4.SelectedItem != null)
                {
                    Sell Sel = dataGrid4.SelectedItem as Sell;
                    string delQuery = $"delete from Sell where ID_details = {Sel.ID_details}";
                    SqlCommand command = new SqlCommand(delQuery, databace.getConnection());
                    command.ExecuteNonQuery();
                    delQuery = $"SELECT * from Sell";
                    command = new SqlCommand(delQuery, databace.getConnection());
                    databace.openConnection();
                    ClearTable(3);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ReadRow(reader, 3);
                    }
                    reader.Close();
                }
                else { }
                
            }
            if (me.Name == "Отчёт")
            {
                ReportForm reportForm = new ReportForm(this);
                reportForm.ShowDialog();
            }
        }
        private void GridBlid(DataGrid dataviewer,int moder)
        {
            //dataviewer.ItemsSource=null;
            string query;
            if (moder == 0)
                query = $"select * from Details";
            else if (moder == 1)
                query = $"select * from Active_details";
            else if (moder == 2)
                query = $"select * from Supply";
            else
                query = $"select * from Sells";
            SqlCommand command = new SqlCommand(query, databace.getConnection());
            databace.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadRow(reader,moder);
            }
            reader.Close();
        }
        public void ClearTable(int moder)
        {
            if (moder == 0)
            {
                DetailsCollection = new ObservableCollection<Details>();
                Grid1.ItemsSource = DetailsCollection;
            }
            else if (moder == 1)
            {
                ActiveDetailCollection = new ObservableCollection<ActiveDetail>();
                Grid2.ItemsSource = ActiveDetailCollection;
            }
            else if (moder == 3)
            {
                SellCollection = new ObservableCollection<Sell>();
                Grid4.ItemsSource = SellCollection;
            }   
            else
            {
                SupplyCollection = new ObservableCollection<Supply>();
                Grid3.ItemsSource = SupplyCollection;
            }
        }
        public void ReadRow(IDataRecord record,int moder)
        {
            if (moder == 0)
            {
                DetailsCollection.Add(new Details
                {
                    ID = record.GetInt32(0),
                    Prod_date = record.GetDateTime(1),
                    Prod_count = record.GetInt32(2),
                    Serial_num = record.GetString(3)
                });
            }
            else if (moder == 1)
            {
                ActiveDetailCollection.Add(new ActiveDetail
                {
                    ID_details = record.GetInt32(0),
                    Sell = record.GetDecimal(1),
                    Detail_name = record.GetString(2)
                });
            }
            else if (moder == 2)
            {
                SupplyCollection.Add(new Supply
                {
                    ID_details = record.GetInt32(0),
                    Real_date = record.GetDateTime(1),
                    Target_pl = record.GetString(2),
                    Out_pl = record.GetString(3)
                });
            }
            else
            {
                SellCollection.Add(new Sell
                {
                    ID_details = record.GetInt32(0),
                    Sell_date = record.GetDateTime(1),
                    Sell_place = record.GetString(2),
                    Time_sell = (TimeSpan)record.GetValue(3)
                });
            }
        }
    }
}
