using System;
using System.Data;
using System.Data.Odbc;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ReportManager
{
    class DataRetriever
    {
        
        public static void Data1(DataGrid dataGrid, DataTable data)
        {
            
            try
            {
                IniFile readIni = new IniFile("config.ini");
                OdbcConnection connection = new OdbcConnection();
                connection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb)}; Dbq=" + readIni.Read("DbUT", "Database");


                connection.Open();
                string query = "SELECT Calibrations.CalibrationId, Calibrations.CalibrationDate,  Meters.SerialNumber, Calibrations.Operator, Calibrations.Program, Meters.MeterData1, Meters.MeterData2, Meters.MeterData3, Meters.MeterData4, Meters.MeterData5, Meters.MeterData6, Meters.MeterData7, Meters.MeterData8, Meters.MeterData9, Meters.MeterData10 from Calibrations inner join Meters on Calibrations.CalibrationId=Meters.CalibrationId";// UNION ALL SELECT SerialNumber from Meters";// UNION ALL SELECT Operator, Program from Calibrations UNION ALL SELECT MeterData1, MeterData2, MeterData3, MeterData4, MeterData5, MeterData6, MeterData7, MeterData8, MeterData9, MeterData10 FROM Meters";
                OdbcCommand command = new OdbcCommand(query, connection);
                command.ExecuteNonQuery();
                OdbcDataAdapter adapter = new OdbcDataAdapter(command);


                adapter.Fill(data);
                dataGrid.DataContext = data;

                dataGrid.ItemsSource = data.DefaultView;
                adapter.Update(data);
                connection.Close();
                App.Current.Resources["StatusIndicator2"] = Brushes.LimeGreen;
                App.Current.Resources["ConnectionStatus2"] = "ONLINE";
            }
            catch(Exception ex)
            {
                
                App.Current.Resources["StatusIndicator2"] = Brushes.Red;
                App.Current.Resources["ConnectionStatus2"] = "OFFLINE";
                LogFile.Write(ex.Message, "#800004");



            }

            
        }
        public static void Data2(DataGrid dataGrid, DataTable data)
        {
            try
            {
                IniFile readIni = new IniFile("config.ini");
                OdbcConnection connection = new OdbcConnection();
                connection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb)}; Dbq=" + readIni.Read("DbUM", "Database");


                connection.Open();
                string query = "SELECT Calibraciones.IdCalibración, Calibraciones.FechaCalibración,  Calibraciones.NúmeroSerie, Calibraciones.Operador, Contadores.MarcaContador, Contadores.ModeloContador, Contadores.Diámetro, Contadores.TamañoContador, Contadores.PresiónNominal, Calibraciones.TotalizadorIni & ' m³', Calibraciones.TotalizadorFin & ' m³', Contadores.Qmax & ' m³/h', Contadores.Qmin & ' m³/h',  Calibraciones.IdLocalización from Calibraciones inner join Contadores on Calibraciones.NúmeroSerie=Contadores.NúmeroSerie";// UNION ALL SELECT SerialNumber from Meters";// UNION ALL SELECT Operator, Program from Calibrations UNION ALL SELECT MeterData1, MeterData2, MeterData3, MeterData4, MeterData5, MeterData6, MeterData7, MeterData8, MeterData9, MeterData10 FROM Meters";
                OdbcCommand command = new OdbcCommand(query, connection);
                command.ExecuteNonQuery();
                OdbcDataAdapter adapter = new OdbcDataAdapter(command);


                adapter.Fill(data);
                dataGrid.DataContext = data;

                dataGrid.ItemsSource = data.DefaultView;
                adapter.Update(data);
                connection.Close();
                App.Current.Resources["StatusIndicator3"] = Brushes.LimeGreen;
                App.Current.Resources["ConnectionStatus3"] = "ONLINE";
            }
            catch(Exception ex)
            {

                App.Current.Resources["StatusIndicator3"] = Brushes.Red;
                App.Current.Resources["ConnectionStatus3"] = "OFFLINE";
                LogFile.Write(ex.Message, "#800005");
            }            
        }
        public static void Data3(DataGrid dataGrid, DataTable data)
        {
            try
            {
                IniFile readIni = new IniFile("config.ini");
                OdbcConnection connection = new OdbcConnection();
                connection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb)}; Dbq=" + readIni.Read("DbSN", "Database");


                connection.Open();
                //string query = "SELECT Calibrations.CalibrationId, Calibrations.CalibrationDate,  Meters.SerialNumber, Calibrations.Operator, Calibrations.Program, Meters.MeterData1, Meters.MeterData2, Meters.from Calibrations inner join Meters on Calibrations.CalibrationId=Meters.CalibrationId";
                string query = "SELECT Meters.CalibrationId, Calibrations.CalibrationDate,  Meters.SerialNumber, Calibrations.Operator, Calibrations.Program, Meters.GSize, Meters.MeterData1, Meters.MeterData5 from Meters inner join Calibrations on Meters.CalibrationId=Calibrations.CalibrationId";// UNION ALL SELECT SerialNumber from Meters";// UNION ALL SELECT Operator, Program from Calibrations UNION ALL SELECT MeterData1, MeterData2, MeterData3, MeterData4, MeterData5, MeterData6, MeterData7, MeterData8, MeterData9, MeterData10 FROM Meters";
                OdbcCommand command = new OdbcCommand(query, connection);
                command.ExecuteNonQuery();
                OdbcDataAdapter adapter = new OdbcDataAdapter(command);


                adapter.Fill(data);
                dataGrid.DataContext = data;

                dataGrid.ItemsSource = data.DefaultView;
                adapter.Update(data);
                connection.Close();
                App.Current.Resources["StatusIndicator1"] = Brushes.LimeGreen;
                App.Current.Resources["ConnectionStatus1"] = "ONLINE";
            }
            catch(Exception ex)
            {
                App.Current.Resources["StatusIndicator1"] = Brushes.Red;
                App.Current.Resources["ConnectionStatus1"] = "OFFLINE";
                LogFile.Write(ex.Message, "#800006");
            }
            
        }

        public static void GetDataAdress()
        {
            IniFile iniFile = new IniFile("config.ini");
            try
            {
                Globals.DataAdressSN = iniFile.Read("DbSN", "Database");

                Globals.DataAdressUT = iniFile.Read("DbUT", "Database");

                Globals.DataAdressUM = iniFile.Read("DbUM", "Database");

                Globals.xlapp = new Microsoft.Office.Interop.Excel.Application();
            }
            catch(Exception ex)
            {
                LogFile.Write(ex.Message, "#800007");
            }
            
        }

        public static void GetFolderAdress()
        {
            IniFile iniFile = new IniFile("config.ini");
            try
            {
                Globals.FolderAdressSN = iniFile.Read("TemplateFolder3", "DirectoryTemplates");

                Globals.FolderAdressUT = iniFile.Read("TemplateFolder1", "DirectoryTemplates");

                Globals.FolderAdressUM = iniFile.Read("TemplateFolder2", "DirectoryTemplates");

                
            }
            catch (Exception ex)
            {
                LogFile.Write(ex.Message, "#800007");
            }

        }

    }
}
