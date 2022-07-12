using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ReportManager.ViewModels
{
    /// <summary>
    /// Lógica interna para IniLoading.xaml
    /// </summary>
    public partial class IniLoading : Window
    {
        
        
        DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        public IniLoading()
        {
            
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
            InitializeComponent();
            StartUp.CheckFiles();
            StartUp.Language(this);
            //StartUp.Theme(this);
            StartUp.TestConnection();
            
            Storyboard s = (Storyboard)TryFindResource("mystoryboard");
            s.Begin();
            PbLoading.Value = 100;
            
            
            
            


        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            dispatcherTimer.Stop();
            this.Close();
            
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
