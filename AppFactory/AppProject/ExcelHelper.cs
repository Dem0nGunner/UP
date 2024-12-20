using System;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace AppProject
{
    internal class ExcelHelper : IDisposable
    {
        private Application m_objExcel;
        private Workbook m_workbook;
        public ExcelHelper()
        {
            m_objExcel = new Application(); //Инизиализация и запуск мини-приложения
            m_workbook = m_objExcel.Workbooks.Add(); //Создание нового файла
        }
        internal bool OpenFile(string FilePath)
        {
            try
            {
                if (File.Exists(FilePath)) //Файл существует
                {
                    m_objExcel.Workbooks.Close(); //Закрыть предыдущий лист, если он есть
                    m_workbook = m_objExcel.Workbooks.Open(FilePath, Editable: true); //Открыть файл
                }
                else //Файла не существует
                    m_workbook = m_objExcel.Workbooks.Add(); //Создать файл
                return true;
            }
            catch (Exception ex) { return false; }
        }
        internal bool SaveAsFile(string FilePath, string[,] table)
        {
            try
            {
                Worksheet m_workSheet = (Worksheet)m_workbook.ActiveSheet; //Выбор активной таблицы (листа) в файле
                m_workSheet.Rows.Clear(); //Очистка таблицы excel перед заполнением
                for (int i = 0; i < table.GetLength(0); i++) //по строкам
                    for (int j = 0; j < table.GetLength(1); j++) //по столбцам
                        m_workSheet.Cells[j + 1, i + 1] = table[i, j]; //Перенос значений из string[,]table в excel таблицу
                m_workbook.SaveAs(FilePath); //Сохранение файла по пути
                return true;
            }
            catch (Exception ex) { return false; }
        }
        public void Dispose()
        {
            if (m_workbook != null) //Приложение содержит файл
                m_workbook.Close(); //Закрыть файл перед завершением процесса
            m_objExcel.Quit(); //Завершение процесса мини-приложения
        }
    }
}
