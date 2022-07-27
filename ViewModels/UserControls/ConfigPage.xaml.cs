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
            Common.ButtonCaptionText(Btn_Folder_Adress1_Change, Btn_Folder_Adress2_Change, Btn_Folder_Adress3_Change, Btn_Adress1_Change, Btn_Adress2_Change, Btn_Adress3_Change, "btnChange");
            Common.ButtonCaptionText(Btn_Pbx_1, Btn_Pbx_2, Btn_Pbx_3, null, null, null, "btnPswApply");
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
            Common.ButtonCaptionText(Btn_Pbx_1, null, null, null, null, null, "btnPswApplied");
            Btn_Pbx_1.IsEnabled = false;
            Pbx_1.IsEnabled = false;
            //TODO: Criptografar senhas dos templates SN
        }

        private void Btn_Pbx_2_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Criptografar senhas dos templates UT
        }

        private void Btn_Pbx_3_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Criptografar senhas dos templates UM
        }

        private void Btn_Folder_Adress1_Change_Click(object sender, RoutedEventArgs e)
        {
            Common.ChangeTemplateFolderAdress(Folder_data1, "TemplateFolder3", "DirectoryTemplates");
        }

        private void Btn_Folder_Adress2_Change_Click(object sender, RoutedEventArgs e)
        {
            Common.ChangeTemplateFolderAdress(Folder_data2, "TemplateFolder1", "DirectoryTemplates");
        }

        private void Btn_Folder_Adress3_Change_Click(object sender, RoutedEventArgs e)
        {
            Common.ChangeTemplateFolderAdress(Folder_data3, "TemplateFolder2", "DirectoryTemplates");
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TODO: Adicionar suporte para idiomas
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            //TODO: Adicionar seletor de formato de arquivo
        }
    }
}
