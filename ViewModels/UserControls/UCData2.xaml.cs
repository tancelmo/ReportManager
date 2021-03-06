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
            DataRetriever.Data2(datagridUM, data);
            Common.TemplatesSelector("TemplateFolder2", CbxTemplates);
        }

        
        private void datagridUM_Loaded(object sender, RoutedEventArgs e)
        {
            datagridUM.Items.SortDescriptions.Add(new SortDescription("FechaCalibración", ListSortDirection.Descending));
            Mouse.OverrideCursor = null;
            

        }
        private void DataFilter_Checked(object sender, RoutedEventArgs e)
        {

            Common.FilterRangeDate(data, datagridUM, Date1, Date2, "FechaCalibración", SnFilter, TbxInit, TbxFinal, "NúmeroSerie");
        }

        private void DataFilter_Unchecked(object sender, RoutedEventArgs e)
        {
            if (SnFilter.IsChecked == true)
            {
                Common.FilterRangeSn(data, datagridUM, TbxInit, TbxFinal, "NúmeroSerie", DataFilter, Date1, Date2, "FechaCalibración");
            }
            else
            {
                data.DefaultView.RowFilter = string.Empty;
                datagridUM.Items.SortDescriptions.Clear();
                datagridUM.Items.SortDescriptions.Add(new SortDescription("FechaCalibración", ListSortDirection.Descending));
            }

        }

        private void Date1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataFilter.IsChecked == true)
            {
                Common.FilterRangeDate(data, datagridUM, Date1, Date2, "FechaCalibración", SnFilter, TbxInit, TbxFinal, "NúmeroSerie");
            }
        }


        private void Date2_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataFilter.IsChecked == true)
            {
                Common.FilterRangeDate(data, datagridUM, Date1, Date2, "FechaCalibración", SnFilter, TbxInit, TbxFinal, "NúmeroSerie");
            }
        }

        private void SnFilter_Checked(object sender, RoutedEventArgs e)
        {
            Common.FilterRangeSn(data, datagridUM, TbxInit, TbxFinal, "NúmeroSerie", DataFilter, Date1, Date2, "FechaCalibración");
        }

        private void SnFilter_Unchecked(object sender, RoutedEventArgs e)
        {
            if (DataFilter.IsChecked == true)
            {
                Common.FilterRangeDate(data, datagridUM, Date1, Date2, "FechaCalibración", SnFilter, TbxInit, TbxFinal, "NúmeroSerie");
            }
            else
            {
                data.DefaultView.RowFilter = string.Empty;
                datagridUM.Items.SortDescriptions.Clear();
                datagridUM.Items.SortDescriptions.Add(new SortDescription("FechaCalibración", ListSortDirection.Descending));
            }

        }

        private void TbxInit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SnFilter.IsChecked == true)
            {
                Common.FilterRangeSn(data, datagridUM, TbxInit, TbxFinal, "NúmeroSerie", DataFilter, Date1, Date2, "FechaCalibración");
            }
        }

        private void TbxFinal_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SnFilter.IsChecked == true)
            {
                Common.FilterRangeSn(data, datagridUM, TbxInit, TbxFinal, "NúmeroSerie", DataFilter, Date1, Date2, "FechaCalibración");
            }
        }

        private void datagridUM_AutoGeneratedColumns(object sender, EventArgs e)
        {
            Common.UMrename(datagridUM);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //TODO: ExportsMode for UM Database
        }
    }
}
