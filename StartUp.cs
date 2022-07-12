using MaterialDesignThemes.Wpf;
using System;
using System.Data.Odbc;
using System.Globalization;
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

                LogFile.Write(ex.Message, "#800001") ;
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
                LogFile.Write(ex.Message, "#800002");

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
                LogFile.Write(ex.Message, "#800003");

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

    }
}
