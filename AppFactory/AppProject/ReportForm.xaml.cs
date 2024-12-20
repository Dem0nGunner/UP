using AppProject.TablesRes;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
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
using System.Windows.Shapes;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace AppProject
{
    /// <summary>
    /// Логика взаимодействия для ReportForm.xaml
    /// </summary>
    public partial class ReportForm : Window
    {
        TableForm ourForm;
        public ReportForm(TableForm ourF)
        {
            InitializeComponent();
            this.ourForm = ourF;
        }
        bool sklad = false;
        bool v_prod = false;
        bool postav = false;
        bool prodashi = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender == this.Отмена)
            {
                this.Close();
            }
            if (sender == this.Plus1)
            {
                if (this.Склад_текст.Text == "СКЛАД")
                {
                    this.Склад_текст.Text = "";
                    this.Plus1.Content = "+";
                    sklad = false;
                }
                else
                {
                    this.Склад_текст.Text = "СКЛАД";
                    this.Plus1.Content = "-";
                    sklad = true;
                }
            }
            if (sender == this.Plus2)
            {
                if (this.В_продаже_текст.Text == "В ПРОДАЖЕ")
                {
                    this.В_продаже_текст.Text = "";
                    this.Plus2.Content = "+";
                    v_prod = false;
                }
                else
                {
                    this.В_продаже_текст.Text = "В ПРОДАЖЕ";
                    this.Plus2.Content = "-";
                    v_prod = true;
                }
            }
            if (sender == this.Plus3)
            {
                if (this.Поставки_текст.Text == "ПОСТАВКИ")
                {
                    this.Поставки_текст.Text = "";
                    this.Plus3.Content = "+";
                    postav = false;
                }
                else
                {
                    this.Поставки_текст.Text = "ПОСТАВКИ";
                    this.Plus3.Content = "-";
                    postav = true;
                }
            }
            if (sender == this.Plus4)
            {
                if (this.Продажи_текст.Text == "ПРОДАЖИ")
                {
                    this.Продажи_текст.Text = "";
                    this.Plus4.Content = "+";
                    prodashi = false;
                }
                else
                {
                    this.Продажи_текст.Text = "ПРОДАЖИ";
                    this.Plus4.Content = "-";
                    prodashi = true;
                }
            }
            if (sender == this.Отчёт)
            {
                ExcelHelper filehelper = new ExcelHelper();
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Лист Excel (*.xlsx)|*.xlsx|Лист Excel (*.xls)|*.xls";
                string[,] table;
                int next_tabl = 0;
                FrameworkElement cellContent;
                int[] list = { ourForm.Grid1.Items.Count, ourForm.Grid2.Items.Count, ourForm.Grid3.Items.Count, ourForm.Grid4.Items.Count };
                int long_e = list.Max();
                if (saveFileDialog.ShowDialog() == true)
                {
                    string filePath = saveFileDialog.FileName;
                    table = new string[16, long_e];
                    if (sklad)
                    {
                        for (int i = 0; i < ourForm.Grid1.Columns.Count; i++) //по колоннам
                            for (int j = 0; j < ourForm.Grid1.Items.Count; j++) //по строкам
                            {
                                cellContent = ourForm.Grid1.Columns[i].GetCellContent(ourForm.Grid1.Items[j]);
                                if (cellContent is TextBlock text_t)
                                {
                                    table[i, j] = text_t.Text;
                                }
                            }
                    }
                    if (v_prod)
                    {
                        for (int i = 0; i < ourForm.Grid2.Columns.Count; i++) //по колоннам
                            for (int j = 0; j < ourForm.Grid2.Items.Count; j++) //по строкам
                            {
                                cellContent = ourForm.Grid2.Columns[i].GetCellContent(ourForm.Grid2.Items[j]);
                                if (cellContent is TextBlock text_t)
                                {
                                    table[ourForm.Grid1.Columns.Count + i, j] = text_t.Text;
                                }
                            }
                        if (postav)
                        {
                            for (int i = 0; i < ourForm.Grid3.Columns.Count; i++) //по колоннам
                                for (int j = 0; j < ourForm.Grid3.Items.Count; j++) //по строкам
                                {
                                    cellContent = ourForm.Grid3.Columns[i].GetCellContent(ourForm.Grid3.Items[j]);
                                    if (cellContent is TextBlock text_t)
                                    {
                                        table[ourForm.Grid1.Columns.Count + ourForm.Grid2.Columns.Count + i, j] = text_t.Text;
                                    }
                                }
                            if (prodashi)
                            {
                                for (int i = 0; i < ourForm.Grid4.Columns.Count; i++) //по колоннам
                                    for (int j = 0; j < ourForm.Grid4.Items.Count; j++) //по строкам
                                    {
                                        cellContent = ourForm.Grid4.Columns[i].GetCellContent(ourForm.Grid4.Items[j]);
                                        if (cellContent is TextBlock text_t)
                                        {
                                            table[ourForm.Grid1.Columns.Count + ourForm.Grid2.Columns.Count + ourForm.Grid3.Columns.Count + i, j] = text_t.Text;
                                        }
                                    }
                                filehelper.SaveAsFile(filePath, table);
                            }
                            filehelper.Dispose();
                        }
                    }
                }
            }
        }
    }
}