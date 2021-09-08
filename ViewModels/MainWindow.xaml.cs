using ReportManager.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ReportManager
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        //Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
        UCData1 ucObj1;
        UCData2 ucObj2;
        UCData3 ucObj3;

        
        

        //public void LoadDataGrid()
        //{
        //    teste = new UCData2();
        //    table = teste.data;
        //}
        public MainWindow()
        {
            InitializeComponent();

            //LoadDataGrid();

        }
        public static RoutedCommand CustomRoutedCommand = new RoutedCommand();

        //public KeyBinding Search = new KeyBinding(CustomRoutedCommand, Key.F, ModifierKeys.Control);

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                BtnRestore.Visibility = Visibility.Visible;
                BtnMaximize.Visibility = Visibility.Collapsed;
            }
            else if (WindowState == WindowState.Normal)
            {
                BtnRestore.Visibility = Visibility.Collapsed;
                BtnMaximize.Visibility = Visibility.Visible;
            }       
            
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnMaximize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        private void BtnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                BtnRestore.Visibility = Visibility.Collapsed;
                BtnMaximize.Visibility = Visibility.Visible;
            }
            else if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
                BtnRestore.Visibility = Visibility.Visible;
                BtnMaximize.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void TbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
           

            
            if (ut.IsChecked == true)
            {

                if (ucObj1.SnFilter.IsChecked == true || ucObj1.DataFilter.IsChecked == true)
                {
                    e.Handled = true;
                    SystemSounds.Beep.Play();
                    Warn.Visibility = Visibility.Visible;
                    TbxSearch.Text = string.Empty;
                }
                else
                {
                    Warn.Visibility = Visibility.Collapsed;
                    ucObj1.data.DefaultView.RowFilter = string.Format("[SerialNumber] Like '%{0}%'", TbxSearch.Text);
                    ucObj1.datagrid1.ItemsSource = ucObj1.data.DefaultView;
                }


            }
            if (um.IsChecked == true)
            {


                if (ucObj2.SnFilter.IsChecked == true || ucObj2.DataFilter.IsChecked == true)
                {
                    e.Handled = true;
                    SystemSounds.Beep.Play();
                    Warn.Visibility = Visibility.Visible;
                    TbxSearch.Text = string.Empty;
                }
                else
                {
                    Warn.Visibility = Visibility.Collapsed;
                    ucObj2.data.DefaultView.RowFilter = string.Format("[NúmeroSerie] Like '%{0}%'", TbxSearch.Text);
                    ucObj2.datagrid1.ItemsSource = ucObj2.data.DefaultView;
                }

            }
            if (Sonical.IsChecked == true)
            {
                if (ucObj3.SnFilter.IsChecked == true || ucObj3.DataFilter.IsChecked == true)
                {
                    e.Handled = true;
                    SystemSounds.Beep.Play();
                    Warn.Visibility = Visibility.Visible;
                    TbxSearch.Text = string.Empty;
                }
                else
                {
                    Warn.Visibility = Visibility.Collapsed;
                    ucObj3.data.DefaultView.RowFilter = string.Format("[SerialNumber] Like '%{0}%'", TbxSearch.Text);
                    ucObj3.datagrid1.ItemsSource = ucObj3.data.DefaultView;
                }

            }
            




        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            ucObj1 = new UCData1();
            TbxSearch.Text = String.Empty;
            grid1.Children.Add(ucObj1);
            
        }

        private void RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            ucObj1.datagrid1 = null;
            grid1.Children.Remove(ucObj1);
            


        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            ucObj2 = new UCData2();
            TbxSearch.Text = String.Empty;
            grid1.Children.Add(ucObj2);
        }

        private void RadioButton_Unchecked_1(object sender, RoutedEventArgs e)
        {
            ucObj2.datagrid1 = null;
            grid1.Children.Remove(ucObj2);
            

        }

        private void Sonical_Checked(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            ucObj3 = new UCData3();
            TbxSearch.Text = String.Empty;
            grid1.Children.Add(ucObj3);
        }

        private void Sonical_Unchecked(object sender, RoutedEventArgs e)
        {
            ucObj3.datagrid1 = null;
            grid1.Children.Remove(ucObj3);
            
        }

        private void TbxSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            Warn.Visibility = Visibility.Collapsed;
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            

            Keyboard.Focus(TbxSearch);
            TbxSearch.Tag = "Procure um número de série..";
            
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("teste");
        }
    }
}
