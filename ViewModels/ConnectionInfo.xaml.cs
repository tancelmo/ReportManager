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
using ReportManager.ViewModels;

namespace ReportManager.ViewModels
{
    /// <summary>
    /// Lógica interna para ConnectionInfo.xaml
    /// </summary>
    public partial class ConnectionInfo : Window
    {
        
        public ConnectionInfo()
        {
            
            InitializeComponent();
            StartUp.Theme(this);
            StartUp.Language(this);
            DataRetriever.GetDataAdress();
            
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
           // this.DragMove();
            
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Show();
        }
    }
}
