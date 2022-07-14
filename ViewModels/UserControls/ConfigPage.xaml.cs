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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReportManager.ViewModels.UserControls
{
    /// <summary>
    /// Interação lógica para ConfigPage.xam
    /// </summary>
    public partial class ConfigPage : UserControl
    {
        IniFile iniFile = new IniFile("config.ini");
        public ConfigPage()
        {
            InitializeComponent();

            
        }

        private void Btn_Adress1_Change_Click(object sender, RoutedEventArgs e)
        {

            Common.ChangeDatabaseAdress(data1, "DbSN", "Database");

            //Refresh
            DataRetriever.GetDataAdress();

        }

        private void Btn_Adress2_Change_Click(object sender, RoutedEventArgs e)
        {
            Common.ChangeDatabaseAdress(data2, "DbUT", "Database");
            //Refresh
            DataRetriever.GetDataAdress();
        }

        private void Btn_Adress3_Change_Click(object sender, RoutedEventArgs e)
        {
            Common.ChangeDatabaseAdress(data3, "DbUM", "Database");
            //Refresh
            DataRetriever.GetDataAdress();
        }

        private void Btn_Pbx_1_Click(object sender, RoutedEventArgs e)
        {

            iniFile.Write("PassWordSN", Pbx_1.Password, "TemplatesPasswords");
            //Refresh
            DataRetriever.GetDataAdress();

        }

        private void Btn_Folder_Adress1_Change_Click(object sender, RoutedEventArgs e)
        {
            Common.ChangeTemplateFolderAdress(Folder_data1, "TemplateFolder1", "DirectoryTemplates");
        }
    }
}
