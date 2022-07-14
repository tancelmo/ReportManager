using MaterialDesignThemes.Wpf;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;


namespace ReportManager
{

    public class Common
    {
        
        public static int CounterSelectedDatagrid(DataGrid dataGrid, int NumberOfColumns)
        {
            return dataGrid.SelectedCells.Count / NumberOfColumns;
        }     
        public static void FilterRangeDate(DataTable dataTable, DataGrid dataGrid, DatePicker datePicker, DatePicker datePicker1, string ColumnName, CheckBox checkBox, TextBox textBox, TextBox textBox1, string ColumnName1)
        {
            if (checkBox.IsChecked == true)
            {
                
                dataTable.DefaultView.RowFilter = string.Format("[" + ColumnName + "] >= '" + datePicker + "' AND [" + ColumnName + "] <= '" + datePicker1.SelectedDate.Value.AddDays(1) + "' AND [" + ColumnName1 + "] >= '" + textBox.Text + "' AND [" + ColumnName1 + "] <= '" + textBox1.Text + "'");
                dataGrid.Items.SortDescriptions.Clear();
                dataGrid.Items.SortDescriptions.Add(new SortDescription(ColumnName, ListSortDirection.Ascending));
                
            }
            else
            {
                dataTable.DefaultView.RowFilter = string.Format("[" + ColumnName + "] >= '" + datePicker + "' AND [" + ColumnName + "] <= '" + datePicker1.SelectedDate.Value.AddDays(1) + "'");
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
            FileInfo[] files = directoryInfo.GetFiles("*.xls?", SearchOption.TopDirectoryOnly);
            foreach (FileInfo file in files)
            {
                comboBox.Items.Add(Path.GetFileNameWithoutExtension(file.Name));
                
            }
            
        }

        public static void MenuTimer(EventHandler eventHandler)
        {
            DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(eventHandler);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Start();
            
        }

        public static void SNRename(DataGrid dataGrid)
            {
                
                dataGrid.Columns[0].Header = Convert.ToString(Application.Current.FindResource("SNHeader0"));
                dataGrid.Columns[1].Header = Convert.ToString(Application.Current.FindResource("SNHeader1"));
                dataGrid.Columns[2].Header = Convert.ToString(Application.Current.FindResource("SNHeader2"));
                dataGrid.Columns[3].Header = Convert.ToString(Application.Current.FindResource("SNHeader3"));
                dataGrid.Columns[4].Header = Convert.ToString(Application.Current.FindResource("SNHeader4"));
                dataGrid.Columns[5].Header = Convert.ToString(Application.Current.FindResource("SNHeader5"));
                dataGrid.Columns[6].Header = Convert.ToString(Application.Current.FindResource("SNHeader6"));
                dataGrid.Columns[7].Header = Convert.ToString(Application.Current.FindResource("SNHeader7"));

            }

        public static void UTRename(DataGrid dataGrid)
            {
                
                dataGrid.Columns[0].Header = Convert.ToString(Application.Current.FindResource("UTHeader0"));
                dataGrid.Columns[1].Header = Convert.ToString(Application.Current.FindResource("UTHeader1"));
                dataGrid.Columns[2].Header = Convert.ToString(Application.Current.FindResource("UTHeader2"));
                dataGrid.Columns[3].Header = Convert.ToString(Application.Current.FindResource("UTHeader3"));
                dataGrid.Columns[4].Header = Convert.ToString(Application.Current.FindResource("UTHeader4"));
                dataGrid.Columns[5].Header = Convert.ToString(Application.Current.FindResource("UTHeader5"));
                dataGrid.Columns[6].Header = Convert.ToString(Application.Current.FindResource("UTHeader6"));
                dataGrid.Columns[7].Header = Convert.ToString(Application.Current.FindResource("UTHeader7"));
                dataGrid.Columns[8].Header = Convert.ToString(Application.Current.FindResource("UTHeader8"));
                dataGrid.Columns[9].Header = Convert.ToString(Application.Current.FindResource("UTHeader9"));
                dataGrid.Columns[10].Header = Convert.ToString(Application.Current.FindResource("UTHeader10"));
                dataGrid.Columns[11].Header = Convert.ToString(Application.Current.FindResource("UTHeader11"));
                dataGrid.Columns[12].Header = Convert.ToString(Application.Current.FindResource("UTHeader12"));
                dataGrid.Columns[13].Header = Convert.ToString(Application.Current.FindResource("UTHeader13"));
                dataGrid.Columns[14].Header = Convert.ToString(Application.Current.FindResource("UTHeader14"));
            }
        public static void UMrename(DataGrid dataGrid)
            {
                
                dataGrid.Columns[0].Header = Convert.ToString(Application.Current.FindResource("UMHeader0"));
                dataGrid.Columns[1].Header = Convert.ToString(Application.Current.FindResource("UMHeader1"));
                dataGrid.Columns[2].Header = Convert.ToString(Application.Current.FindResource("UMHeader2"));
                dataGrid.Columns[3].Header = Convert.ToString(Application.Current.FindResource("UMHeader3"));
                dataGrid.Columns[4].Header = Convert.ToString(Application.Current.FindResource("UMHeader4"));
                dataGrid.Columns[5].Header = Convert.ToString(Application.Current.FindResource("UMHeader5"));
                dataGrid.Columns[6].Header = Convert.ToString(Application.Current.FindResource("UMHeader6"));
                dataGrid.Columns[7].Header = Convert.ToString(Application.Current.FindResource("UMHeader7"));
                dataGrid.Columns[8].Header = Convert.ToString(Application.Current.FindResource("UMHeader8"));
                dataGrid.Columns[9].Header = Convert.ToString(Application.Current.FindResource("UMHeader9"));
                dataGrid.Columns[10].Header = Convert.ToString(Application.Current.FindResource("UMHeader10"));
                dataGrid.Columns[11].Header = Convert.ToString(Application.Current.FindResource("UMHeader11"));
                dataGrid.Columns[12].Header = Convert.ToString(Application.Current.FindResource("UMHeader12"));
                dataGrid.Columns[13].Header = Convert.ToString(Application.Current.FindResource("UMHeader13"));
            }
            
        public static void HideLabelWarn(Label label, Label label1)
        {
            label.Visibility = Visibility.Collapsed;
            label1.Visibility = Visibility.Collapsed;
        }

        public static void ChangeTheme(Window window, string theme)
        {
            ResourceDictionary newRes = new ResourceDictionary();
            newRes.Source = new Uri("Assets/Themes/" + theme + "Theme.xaml", UriKind.RelativeOrAbsolute);
            window.Resources.MergedDictionaries.Add(newRes);
        }

        public static void ChangeDatabaseAdress(TextBox textBox, string key, string section)
        {
            IniFile iniFile = new IniFile("config.ini");
            var ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.DefaultExt = ".mdb";
            ofd.Filter = "Microsoft Access Database (.mdb)|*.mdb";

            var result = ofd.ShowDialog();
            if (result == false) return;
            textBox.Text = ofd.FileName;
            //Novo Endereço
            iniFile.Write(key, textBox.Text.ToString(), section);
        }

        public static void ChangeTemplateFolderAdress(TextBox textBox, string key, string section)
        {
            IniFile iniFile = new IniFile("config.ini");
            var ofd = new System.Windows.Forms.FolderBrowserDialog();
            ofd.SelectedPath = AppDomain.CurrentDomain.BaseDirectory;
            var result = ofd.ShowDialog();
            //if (result == false) return;
            textBox.Text = ofd.SelectedPath;
            //Novo Endereço
            iniFile.Write(key, textBox.Text.ToString(), section);
        }
            
    }
}
