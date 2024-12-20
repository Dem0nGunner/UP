using AppProject.TablesRes;
using DataBaser;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace AppProject
{
    /// <summary>
    /// Логика взаимодействия для SearchForm.xaml
    /// </summary>
    public partial class SearchForm : Window
    {
        DataBase databace = new DataBase();
        byte _mod;
        int _type;
        TableForm _last;
        public SearchForm(int type, byte mod , TableForm last)
        {
            InitializeComponent();
            this._mod = mod;
            this._type = type;
            this._last = last;
            if (type == 0)
            {
                this.A_1.Visibility = Visibility.Visible;
                this.A_2.Visibility = Visibility.Visible;
                this.A_3.Visibility = Visibility.Visible;
                this.A_4.Visibility = Visibility.Visible;
                this.A_5.Visibility = Visibility.Visible;
                this.A_6.Visibility = Visibility.Visible;
                this.B_1.Visibility = Visibility.Hidden;
                this.B_2.Visibility = Visibility.Hidden;
                this.B_3.Visibility = Visibility.Hidden;
                this.B_4.Visibility = Visibility.Hidden;
                this.B_5.Visibility = Visibility.Hidden;
                this.B_6.Visibility = Visibility.Hidden;
                this.C_1.Visibility = Visibility.Hidden;
                this.C_2.Visibility = Visibility.Hidden;
                this.C_3.Visibility = Visibility.Hidden;
                this.C_4.Visibility = Visibility.Hidden;
                this.C_5.Visibility = Visibility.Hidden;
                this.C_6.Visibility = Visibility.Hidden;
                this.C_7.Visibility = Visibility.Hidden;
                this.C_8.Visibility = Visibility.Hidden;
                this.D_1.Visibility = Visibility.Hidden;
                this.D_2.Visibility = Visibility.Hidden;
                this.D_3.Visibility = Visibility.Hidden;
                this.D_4.Visibility = Visibility.Hidden;
                this.D_5.Visibility = Visibility.Hidden;
                this.D_6.Visibility = Visibility.Hidden;
                this.D_7.Visibility = Visibility.Hidden;
                this.D_8.Visibility = Visibility.Hidden;
            }
            if (type == 1)
            {
                this.A_1.Visibility = Visibility.Hidden;
                this.A_2.Visibility = Visibility.Hidden;
                this.A_3.Visibility = Visibility.Hidden;
                this.A_4.Visibility = Visibility.Hidden;
                this.A_5.Visibility = Visibility.Hidden;
                this.A_6.Visibility = Visibility.Hidden;
                this.B_1.Visibility = Visibility.Visible;
                this.B_2.Visibility = Visibility.Visible;
                this.B_3.Visibility = Visibility.Visible;
                this.B_4.Visibility = Visibility.Visible;
                this.B_5.Visibility = Visibility.Visible;
                this.B_6.Visibility = Visibility.Visible;
                this.C_1.Visibility = Visibility.Hidden;
                this.C_2.Visibility = Visibility.Hidden;
                this.C_3.Visibility = Visibility.Hidden;
                this.C_4.Visibility = Visibility.Hidden;
                this.C_5.Visibility = Visibility.Hidden;
                this.C_6.Visibility = Visibility.Hidden;
                this.C_7.Visibility = Visibility.Hidden;
                this.C_8.Visibility = Visibility.Hidden;
                this.D_1.Visibility = Visibility.Hidden;
                this.D_2.Visibility = Visibility.Hidden;
                this.D_3.Visibility = Visibility.Hidden;
                this.D_4.Visibility = Visibility.Hidden;
                this.D_5.Visibility = Visibility.Hidden;
                this.D_6.Visibility = Visibility.Hidden;
                this.D_7.Visibility = Visibility.Hidden;
                this.D_8.Visibility = Visibility.Hidden;
            }
            if (type == 2)
            {
                this.A_1.Visibility = Visibility.Hidden;
                this.A_2.Visibility = Visibility.Hidden;
                this.A_3.Visibility = Visibility.Hidden;
                this.A_4.Visibility = Visibility.Hidden;
                this.A_5.Visibility = Visibility.Hidden;
                this.A_6.Visibility = Visibility.Hidden;
                this.B_1.Visibility = Visibility.Hidden;
                this.B_2.Visibility = Visibility.Hidden;
                this.B_3.Visibility = Visibility.Hidden;
                this.B_4.Visibility = Visibility.Hidden;
                this.B_5.Visibility = Visibility.Hidden;
                this.B_6.Visibility = Visibility.Hidden;
                this.C_1.Visibility = Visibility.Visible;
                this.C_2.Visibility = Visibility.Visible;
                this.C_3.Visibility = Visibility.Visible;
                this.C_4.Visibility = Visibility.Visible;
                this.C_5.Visibility = Visibility.Visible;
                this.C_6.Visibility = Visibility.Visible;
                this.C_7.Visibility = Visibility.Visible;
                this.C_8.Visibility = Visibility.Visible;
                this.D_1.Visibility = Visibility.Hidden;
                this.D_2.Visibility = Visibility.Hidden;
                this.D_3.Visibility = Visibility.Hidden;
                this.D_4.Visibility = Visibility.Hidden;
                this.D_5.Visibility = Visibility.Hidden;
                this.D_6.Visibility = Visibility.Hidden;
                this.D_7.Visibility = Visibility.Hidden;
                this.D_8.Visibility = Visibility.Hidden;
            }
            if (type == 3)
            {
                this.A_1.Visibility = Visibility.Hidden;
                this.A_2.Visibility = Visibility.Hidden;
                this.A_3.Visibility = Visibility.Hidden;
                this.A_4.Visibility = Visibility.Hidden;
                this.A_5.Visibility = Visibility.Hidden;
                this.A_6.Visibility = Visibility.Hidden;
                this.B_1.Visibility = Visibility.Hidden;
                this.B_2.Visibility = Visibility.Hidden;
                this.B_3.Visibility = Visibility.Hidden;
                this.B_4.Visibility = Visibility.Hidden;
                this.B_5.Visibility = Visibility.Hidden;
                this.B_6.Visibility = Visibility.Hidden;
                this.C_1.Visibility = Visibility.Hidden;
                this.C_2.Visibility = Visibility.Hidden;
                this.C_3.Visibility = Visibility.Hidden;
                this.C_4.Visibility = Visibility.Hidden;
                this.C_5.Visibility = Visibility.Hidden;
                this.C_6.Visibility = Visibility.Hidden;
                this.C_7.Visibility = Visibility.Hidden;
                this.C_8.Visibility = Visibility.Hidden;
                this.D_1.Visibility = Visibility.Visible;
                this.D_2.Visibility = Visibility.Visible;
                this.D_3.Visibility = Visibility.Visible;
                this.D_4.Visibility = Visibility.Visible;
                this.D_5.Visibility = Visibility.Visible;
                this.D_6.Visibility = Visibility.Visible;
                this.D_7.Visibility = Visibility.Visible;
                this.D_8.Visibility = Visibility.Visible;
            }
            if (mod == 0)
            {
                this.Продолжение.Content = "Поиск";
            }
            if (mod == 1)
            {
                this.Продолжение.Content = "Добавить";
            }
            if (mod == 2)
            {
                this.Продолжение.Content = "Изменить";
            }
            if (mod == 3)
            {
                this.Продолжение.Content = "Удалить";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender == this.Отмена)
            {
                this.Close();
            }
            if (sender == this.Продолжение)
            {
                string query;
                if (_mod == 0)
                {
                    if (_type == 0)
                    {
                        _last.DetailsCollection = new ObservableCollection<Details>();
                        query = $"SELECT * FROM Details WHERE CAST(Prod_date AS NVARCHAR) LIKE '%{A_4.Text}%' AND CAST(Prod_count AS NVARCHAR) LIKE '%{A_5.Text}%' AND Serial_num LIKE '%{A_6.Text}%';";
                    }
                    else if (_type == 1)
                    {
                        _last.ActiveDetailCollection = new ObservableCollection<ActiveDetail>();
                        query = $"SELECT * FROM Active_details WHERE CAST (ID_details AS NVARCHAR) LIKE '%{B_4.Text}%' AND CAST(Sell AS NVARCHAR) LIKE '%{B_5.Text}%' AND Detail_name LIKE '%{B_6.Text}%';";
                    }
                    else if (_type == 2)
                    {
                        _last.SupplyCollection = new ObservableCollection<Supply>();
                        query = $"SELECT * FROM Supply WHERE CAST(ID_details AS NVARCHAR) LIKE '%{C_1.Text}%' AND CAST(Real_date AS NVARCHAR) LIKE '%{C_2.Text}%' AND Target_pl LIKE '%{C_3.Text}%' AND Out_pl LIKE '%{C_6.Text}%';";
                    }
                    else
                    {
                        _last.SellCollection = new ObservableCollection<Sell>();
                        query = $"SELECT * FROM Sells WHERE CAST(ID_details AS NVARCHAR) LIKE '%{D_2.Text}%' AND CAST(Sell_date AS NVARCHAR) LIKE '%{D_5.Text}%' AND Sell_place LIKE '%{D_6.Text}%' AND CAST(Time_sell AS NVARCHAR) LIKE '%{D_1.Text}%';";
                    }
                    _last.ClearTable(_type);
                    SqlCommand command = new SqlCommand(query, databace.getConnection());
                    databace.openConnection();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        _last.ReadRow(reader, _type);
                    }
                    reader.Close();
                }
                else if (_mod == 1)
                {
                    if (_type == 0)
                    {
                        _last.DetailsCollection = new ObservableCollection<Details>();
                        query = $"INSERT INTO Details (Prod_date, Prod_count, Serial_num) VALUES (@Prod_date, @Prod_count, @Serial_num)";
                        
                    }
                    else if (_type == 1)
                    {
                        _last.ActiveDetailCollection = new ObservableCollection<ActiveDetail>();
                        query = $"INSERT INTO Active_details (ID_details, Sell, Detail_name) VALUES (@ID_details, @Sell, @Detail_name)";
                    }
                    else if (_type == 2)
                    {
                        _last.SupplyCollection = new ObservableCollection<Supply>();
                        query = $"INSERT INTO Supply (ID_details, Real_date, Target_pl, Out_pl) VALUES (@ID_details, @Real_date, @Target_pl, @Out_pl)";
                    }
                    else
                    {
                        _last.SellCollection = new ObservableCollection<Sell>();
                        query = $"INSERT INTO Sell (ID_details, Sell_date, Sell_place, Time_sell) VALUES (@ID_details, @Sell_date, @Sell_place, @Time_sell)";
                    }
                    _last.ClearTable(_type);
                    SqlCommand command = new SqlCommand(query, databace.getConnection());
                    if (_type == 0)
                    {
                        command.Parameters.AddWithValue("@Prod_date", DateTime.ParseExact(A_4.Text, "yyyy.dd.MM", null));
                        command.Parameters.AddWithValue("@Prod_count", int.Parse(A_5.Text));
                        command.Parameters.AddWithValue("@Serial_num", A_6.Text);
                        databace.openConnection();
                        command.ExecuteNonQuery();
                        query = $"SELECT * from Details";
                    }
                    else if (_type == 1)
                    {
                        command.Parameters.AddWithValue("@ID_details", int.Parse(B_4.Text));
                        command.Parameters.AddWithValue("@Sell", int.Parse(B_5.Text));
                        command.Parameters.AddWithValue("@Detail_name", B_6.Text);
                        databace.openConnection();
                        command.ExecuteNonQuery();
                        query = $"SELECT * from Active_details";
                    }
                    else if (_type == 2)
                    {
                        command.Parameters.AddWithValue("@ID_details", int.Parse(C_3.Text));
                        command.Parameters.AddWithValue("@Real_date", DateTime.ParseExact(C_6.Text, "yyyy.dd.MM", null));
                        command.Parameters.AddWithValue("@Target_pl", C_1.Text);
                        command.Parameters.AddWithValue("@Out_pl", C_2.Text);
                        databace.openConnection();
                        command.ExecuteNonQuery();
                        query = $"SELECT * from Supply";
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ID_details", int.Parse(D_2.Text));
                        command.Parameters.AddWithValue("@Sell_date", DateTime.ParseExact(D_1.Text, "yyyy.dd.MM", null));
                        command.Parameters.AddWithValue("@Sell_place", D_5.Text);
                        command.Parameters.AddWithValue("@Time_sell", TimeSpan.Parse(D_6.Text));
                        databace.openConnection();
                        command.ExecuteNonQuery();
                        query = $"SELECT * from Sells";
                    }
                    command = new SqlCommand(query, databace.getConnection());
                    databace.openConnection();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        _last.ReadRow(reader, _type);
                    }
                    reader.Close();
                }
                else
                {
                    databace.openConnection();
                    if (_type == 0 && _last.mySel != null)
                    {
                        Details sel = (Details)_last.mySel;
                        query = $"update Details set Prod_date = '{DateTime.ParseExact(A_4.Text, "yyyy.dd.MM", null)}',Prod_count = '{int.Parse(A_5.Text)}',Serial_num = '{A_6.Text}' where ID = '{sel.ID}'";
                        SqlCommand command = new SqlCommand(query, databace.getConnection());
                        command.ExecuteNonQuery();
                        query = $"SELECT * from Details";
                        _last.ClearTable(0);
                        command = new SqlCommand(query, databace.getConnection());
                        databace.openConnection();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            _last.ReadRow(reader, _type);
                        }
                        reader.Close();
                    }
                    else if (_type == 1 && _last.mySel!=null)
                    {
                        ActiveDetail sel = (ActiveDetail)_last.mySel;
                        query = $"update Active_details set ID_details = '{int.Parse(B_4.Text)}',Sell = '{int.Parse(B_5.Text)}',Detail_name = '{B_6.Text}' where ID_details = '{sel.ID_details}'";
                        SqlCommand command = new SqlCommand(query, databace.getConnection());
                        command.ExecuteNonQuery();
                        query = $"SELECT * from Active_details";
                        _last.ClearTable(1);
                        command = new SqlCommand(query, databace.getConnection());
                        databace.openConnection();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            _last.ReadRow(reader, _type);
                        }
                        reader.Close();
                    }
                    else if (_type == 2 && _last.mySel != null)
                    {
                        Supply sel = (Supply)_last.mySel;
                        query = $"update Supply set ID_details = '{int.Parse(C_3.Text)}',Real_date = '{DateTime.ParseExact(C_6.Text, "yyyy.dd.MM", null)}',Target_pl = '{C_1.Text},Out_pl = '{C_2.Text}' where ID_details = '{sel.ID_details}'";
                        SqlCommand command = new SqlCommand(query, databace.getConnection());
                        command.ExecuteNonQuery();
                        query = $"SELECT * from Supply";
                        _last.ClearTable(2);
                        command = new SqlCommand(query, databace.getConnection());
                        databace.openConnection();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            _last.ReadRow(reader, _type);
                        }
                        reader.Close();
                    }
                    else if (_type == 3 && _last.mySel != null)
                    {
                        Sell sel = (Sell)_last.mySel;
                        query = $"update Sells set ID_details = '{int.Parse(D_2.Text)}',Real_date = '{DateTime.ParseExact(D_1.Text, "yyyy.dd.MM", null)}',Target_pl = '{D_5.Text},Out_pl = '{TimeSpan.Parse(D_6.Text)}' where ID_details = '{sel.ID_details}'";
                        SqlCommand command = new SqlCommand(query, databace.getConnection());
                        command.ExecuteNonQuery();
                        query = $"SELECT * from Sells";
                        _last.ClearTable(3);
                        command = new SqlCommand(query, databace.getConnection());
                        databace.openConnection();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            _last.ReadRow(reader, _type);
                        }
                        reader.Close();
                    }
                    else
                    {}
                }
            }
        }
    }
}
