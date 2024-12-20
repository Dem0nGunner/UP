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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;
using DataBaser;

namespace AppProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataBase _data = new DataBase();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender == this.Регистрация)
            {
                Registration window = new Registration();
                window.Show();
                this.Close();
            }
            if (sender == this.Войти)
            {
                string login = this.Login.Text;
                string password = this.Pass.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                string querystring = $"select Roles from Users where Username = '{login}' and Password = '{password}'";
                SqlCommand command = new SqlCommand(querystring, _data.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count == 1)
                {
                    byte mod;
                    if (table.Rows[0].ItemArray[0].Equals((byte)1))
                        mod =0;
                    else if(table.Rows[0].ItemArray[0].Equals((byte)2))
                        mod = 1;
                    else if(table.Rows[0].ItemArray[0].Equals((byte)3))
                        mod = 2;
                    else
                        mod = 3;
                    TableForm newForm = new TableForm(mod);
                    newForm.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Я не нашёл запись ►w◄");
            }
        }
    }
}
