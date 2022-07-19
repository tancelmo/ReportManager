using System;
using System.Windows;
using System.Windows.Input;

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

        private void Window_Activated(object sender, EventArgs e)
        {
            Common.ActivedCaptionForeground(BtnClose, null, null, null, null, null, null, CaptionLabel);
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            Common.DeactivedCaptionForeground(BtnClose, null, null, null, null, null, null, CaptionLabel);
        }
    }
}
