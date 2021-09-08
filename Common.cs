using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ReportManager
{
    public class Common
    {
        public static void SetLanguage(UserControl userControl)
        {
            IniFile readIni = new IniFile("config.ini");
            string currentLanguage = readIni.Read("Language", "General");
            Thread.CurrentThread.CurrentCulture = new CultureInfo(currentLanguage);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(currentLanguage);

            userControl.Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);
        }

        public static void FilterRangeDate(DataTable dataTable, DataGrid dataGrid, DatePicker datePicker, DatePicker datePicker1, string ColumnName, CheckBox checkBox, TextBox textBox, TextBox textBox1, string ColumnName1)
        {
            if (checkBox.IsChecked == true)
            {
                dataTable.DefaultView.RowFilter = string.Format("[" + ColumnName + "] >= '" + datePicker + "' AND [" + ColumnName + "] <= '" + datePicker1 + "' AND [" + ColumnName1 + "] >= '" + textBox.Text + "' AND [" + ColumnName1 + "] <= '" + textBox1.Text + "'");
                dataGrid.Items.SortDescriptions.Clear();
                dataGrid.Items.SortDescriptions.Add(new SortDescription(ColumnName, ListSortDirection.Ascending));
                
            }
            else
            {
                dataTable.DefaultView.RowFilter = string.Format("[" + ColumnName + "] >= '" + datePicker + "' AND [" + ColumnName + "] <= '" + datePicker1 + "'");
                dataGrid.Items.SortDescriptions.Clear();
                dataGrid.Items.SortDescriptions.Add(new SortDescription(ColumnName, ListSortDirection.Ascending));
            }
        }
        public static void FilterRangeSn(DataTable dataTable, DataGrid dataGrid, TextBox textBox, TextBox textBox1, string ColumnName,CheckBox checkBox, DatePicker datePicker, DatePicker datePicker1, string ColumnName1)
        {
            if(checkBox.IsChecked == true)
            {
                dataTable.DefaultView.RowFilter = string.Format("[" + ColumnName1 + "] >= '" + datePicker + "' AND [" + ColumnName1 + "] <= '" + datePicker1 + "' AND [" + ColumnName + "] >= '" + textBox.Text + "' AND [" + ColumnName + "] <= '" + textBox1.Text + "'");
                dataGrid.Items.SortDescriptions.Clear();
                dataGrid.Items.SortDescriptions.Add(new SortDescription(ColumnName, ListSortDirection.Ascending));
            }
            else
            {
                dataTable.DefaultView.RowFilter = string.Format("[" + ColumnName + "] >= '" + textBox.Text + "' AND [" + ColumnName + "] <= '" + textBox1.Text + "'");
                dataGrid.Items.SortDescriptions.Clear();
                dataGrid.Items.SortDescriptions.Add(new SortDescription(ColumnName, ListSortDirection.Ascending));
            }
            
        }

        public static void TemplatesSelector(string key, ComboBox comboBox)
        {
            //remover extensao
            IniFile readIni = new IniFile("config.ini");
            DirectoryInfo directoryInfo = new DirectoryInfo(readIni.Read(key, "DirectoryTemplates"));
            FileInfo[] files = directoryInfo.GetFiles("*.xls?", SearchOption.AllDirectories);
            foreach (FileInfo file in files)
            {
                comboBox.Items.Add(Path.GetFileNameWithoutExtension(file.Name));
                
            }
            
        }
    }
}
