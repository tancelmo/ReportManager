using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ReportManager.ViewModels.UserControls
{
    /// <summary>
    /// Interação lógica para UCData2.xam
    /// </summary>
    public partial class UCData2 : UserControl
    {
        public DataTable data = new DataTable();
        public UCData2()
        {
            InitializeComponent();
            DataRetriever.Data2(datagrid1, data);
            Common.SetLanguage(this);
        }

        
        private void datagrid1_Loaded(object sender, RoutedEventArgs e)
        {
            datagrid1.Items.SortDescriptions.Add(new SortDescription("FechaCalibración", ListSortDirection.Descending));
            Mouse.OverrideCursor = null;

        }
        private void DataFilter_Checked(object sender, RoutedEventArgs e)
        {

            Common.FilterRangeDate(data, datagrid1, Date1, Date2, "FechaCalibración", SnFilter, TbxInit, TbxFinal, "NúmeroSerie");
        }

        private void DataFilter_Unchecked(object sender, RoutedEventArgs e)
        {
            if (SnFilter.IsChecked == true)
            {
                Common.FilterRangeSn(data, datagrid1, TbxInit, TbxFinal, "NúmeroSerie", DataFilter, Date1, Date2, "FechaCalibración");
            }
            else
            {
                data.DefaultView.RowFilter = string.Empty;
                datagrid1.Items.SortDescriptions.Clear();
                datagrid1.Items.SortDescriptions.Add(new SortDescription("FechaCalibración", ListSortDirection.Descending));
            }

        }

        private void Date1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataFilter.IsChecked == true)
            {
                Common.FilterRangeDate(data, datagrid1, Date1, Date2, "FechaCalibración", SnFilter, TbxInit, TbxFinal, "NúmeroSerie");
            }
        }


        private void Date2_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataFilter.IsChecked == true)
            {
                Common.FilterRangeDate(data, datagrid1, Date1, Date2, "FechaCalibración", SnFilter, TbxInit, TbxFinal, "NúmeroSerie");
            }
        }

        private void SnFilter_Checked(object sender, RoutedEventArgs e)
        {
            Common.FilterRangeSn(data, datagrid1, TbxInit, TbxFinal, "NúmeroSerie", DataFilter, Date1, Date2, "FechaCalibración");
        }

        private void SnFilter_Unchecked(object sender, RoutedEventArgs e)
        {
            if (DataFilter.IsChecked == true)
            {
                Common.FilterRangeDate(data, datagrid1, Date1, Date2, "FechaCalibración", SnFilter, TbxInit, TbxFinal, "NúmeroSerie");
            }
            else
            {
                data.DefaultView.RowFilter = string.Empty;
                datagrid1.Items.SortDescriptions.Clear();
                datagrid1.Items.SortDescriptions.Add(new SortDescription("FechaCalibración", ListSortDirection.Descending));
            }

        }

        private void TbxInit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SnFilter.IsChecked == true)
            {
                Common.FilterRangeSn(data, datagrid1, TbxInit, TbxFinal, "NúmeroSerie", DataFilter, Date1, Date2, "FechaCalibración");
            }
        }

        private void TbxFinal_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SnFilter.IsChecked == true)
            {
                Common.FilterRangeSn(data, datagrid1, TbxInit, TbxFinal, "NúmeroSerie", DataFilter, Date1, Date2, "FechaCalibración");
            }
        }
    }
}
