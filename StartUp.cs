using MaterialDesignThemes.Wpf;
using System;
using System.Data.Odbc;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media;

namespace ReportManager
{
    internal class StartUp
    {
        public static void TestConnection()
        {
            IniFile readIni = new IniFile("config.ini");

            try
            {
                OdbcConnection connection = new OdbcConnection();
                connection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb)}; Dbq=" + readIni.Read("DbUT", "Database");
                connection.Open();
                connection.Close();
            }
            catch(Exception ex)
            {
                App.Current.Resources["StatusIndicator2"] = Brushes.Red;
                App.Current.Resources["ConnectionStatus2"] = "OFFLINE";

                LogFile.Write("#800001", ex.Message) ;
            }

            try
            {
                OdbcConnection connection = new OdbcConnection();
                connection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb)}; Dbq=" + readIni.Read("DbUM", "Database");
                connection.Open();
                connection.Close();
            }
            catch(Exception ex)
            {
                App.Current.Resources["StatusIndicator3"] = Brushes.Red;
                App.Current.Resources["ConnectionStatus3"] = "OFFLINE";
                LogFile.Write("#800002", ex.Message);

            }

            try
            {
                OdbcConnection connection = new OdbcConnection();
                connection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb)}; Dbq=" + readIni.Read("DbSN", "Database");
                connection.Open();
                connection.Close();
            }
            catch(Exception ex)
            {
                
                App.Current.Resources["StatusIndicator1"] = Brushes.Red;
                App.Current.Resources["ConnectionStatus1"] = "OFFLINE";
                LogFile.Write("#800003", ex.Message);

            }

            
            
        }

        public static void Language(Window window)
        {
            IniFile readIni = new IniFile("config.ini");
            string currentLanguage = readIni.Read("Language", "General");
            Thread.CurrentThread.CurrentCulture = new CultureInfo(currentLanguage);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(currentLanguage);

             window.Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);
        }
        
        public static void SetTheme(bool isDark)
        {
            IniFile readIni = new IniFile("config.ini");
            string currentTheme = readIni.Read("Theme", "General");

            PaletteHelper _paletteHelper = new PaletteHelper();
            ITheme theme = _paletteHelper.GetTheme();
            IBaseTheme baseTheme = isDark ? new MaterialDesignDarkTheme() : (IBaseTheme)new MaterialDesignLightTheme();
            theme.SetBaseTheme(baseTheme);
            _paletteHelper.SetTheme(theme);
            if(isDark == true)
            {
                readIni.Write("Theme", "Dark", "General");
            }
            else
            {
                readIni.Write("Theme", "Light", "General");
            }
            

        }
        public static void Theme(Window window)
        {
            IniFile readIni = new IniFile("config.ini");
            string currentTheme = readIni.Read("Theme", "General");
            if (currentTheme == "Dark")
            {
                StartUp.SetTheme(true);
                Common.ChangeTheme(window, "Dark");
                
            }
            else
            {
                StartUp.SetTheme(false);
                Common.ChangeTheme(window, "Light");
                
            }
        }

        public static void ThemeSwitch(ToggleButton toggleButton)
        {

            IniFile readIni = new IniFile("config.ini");
            string currentTheme = readIni.Read("Theme", "General");
            if (currentTheme == "Dark")
            {
                toggleButton.IsChecked = true;

            }
            else
            {
                toggleButton.IsChecked = false;

            }
        }

        public static void CheckFiles()
        {
            

            if (!File.Exists("config.ini"))
            {

                MessageBoxResult result = MessageBox.Show(Application.Current.FindResource("ConfigWarn").ToString(), Application.Current.FindResource("ConfigWarnCaption").ToString(), MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    CreateIniFile();
                }
                
                else
                {
                    Application.Current.Shutdown();
                }
            }
        }

        // Create a file if not exist
        internal static void CreateIniFile()
        {
            using (StreamWriter writer = new StreamWriter("config.ini", append: true))
            {
                writer.Write(
    @"[General]
Language=pt-br
Theme=Light
MarkUP=##
ReportExtension=.xls

[Database]
DbUT=Results.mdb
DbUM=UM.mdb
DbSN=Sonical/Results.mdb

[DirectoryTemplates]
TemplateFolder1=ReportTemplates\UT
TemplateFolder2=ReportTemplates\UM
TemplateFolder3=ReportTemplates\SN");
            }
        }

    }
}
