using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
using System.Windows.Threading;
using DataBaser;

namespace AppProject
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        bool list_mod = false;
        int role;
        DataBase _data = new DataBase();
        public Registration()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Button me = (Button)sender;
            if (me.Name == "Лист")
            {
                Button But1 = (Button)this.FindName("Продавец");
                Button But2 = (Button)this.FindName("Поставщик");
                Button But3 = (Button)this.FindName("Сборщик");
                if (!list_mod)
                {
                    But3.Visibility = Visibility.Visible;
                    await Task.Delay(200);
                    But2.Visibility = Visibility.Visible;
                    await Task.Delay(200);
                    But1.Visibility = Visibility.Visible;
                    list_mod = true;
                }
                else
                {
                    But1.Visibility = Visibility.Hidden;
                    await Task.Delay(200);
                    But2.Visibility = Visibility.Hidden;
                    await Task.Delay(200);
                    But3.Visibility = Visibility.Hidden;
                    list_mod = false;
                }
            }
            if (me.Name == "К_авторизации")
            {
                MainWindow newWindow = new MainWindow();
                newWindow.Show();
                this.Close();
            }
            TextBox Text1 = (TextBox)this.FindName("Роли");
            if (me.Name == "Сборщик")
            {
                Text1.IsReadOnly = false;
                Text1.Text = "Сборщик";
                Text1.IsReadOnly = true;
                role = 1;
            }
            if (me.Name == "Поставщик")
            {
                Text1.IsReadOnly = false;
                Text1.Text = "Поставщик";
                Text1.IsReadOnly = true;
                role = 2;
            }
            if (me.Name == "Продавец")
            {
                Text1.IsReadOnly = false;
                Text1.Text = "Продавец";
                Text1.IsReadOnly = true;
                role = 3;
            }
            if (me.Name == "Подтвердить")
            {
                if (checkuser()) { }
                else
                {
                    string login = this.Login.Text;
                    string password = this.Pass.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    string querystring = $"insert into Users(Username,Password, Roles) values('{login}','{password}','{role}')";
                    SqlCommand command = new SqlCommand(querystring, _data.getConnection());
                    _data.openConnection();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Я нагрел тебе местечко поудобнее. Располагайся ^v^");
                    }
                    else
                    {
                        MessageBox.Show("Либо место занято, либо его нет ►w◄");
                    }
                    _data.closeConnection();
                }
                TableForm newForm = new TableForm(role);
                newForm.Show();
                this.Close();
            }
        }
        private Boolean checkuser()
        {
            string login = this.Login.Text;
            string password = this.Pass.Text;
            byte role = 5;
            if (this.Роли.Text == "Сборщик")
                role = 3;
            else if (this.Роли.Text == "Продавец")
                role = 4;
            else if (this.Роли.Text == "Поставщик")
                role = 2;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select Roles from Users where Username = '{login}' and Password = '{password}' and Roles = '{role}'";
            SqlCommand command = new SqlCommand(querystring, _data.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Найдено!");
                return true;
            }
            else
                return false;
        }
    }
}
