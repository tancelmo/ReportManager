using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ReportManager
{
    class DataRetriever
    {
        
        public static void Data1(DataGrid dataGrid, DataTable data)
        {
            string LanguageSource = "pt-BR";
            Thread.CurrentThread.CurrentCulture = new CultureInfo(LanguageSource);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageSource);

            //Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);

            // 
            // IniFile readIni = new IniFile("config.ini");
            // double test = Convert.ToDouble(readIni.Read("Valor", "Test"), CultureInfo.InvariantCulture);

            // MessageBox.Show(Convert.ToString("Valor convertido: " + test));
            //

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
        }

        public static void Data2(DataGrid dataGrid, DataTable data)
        {
            IniFile readIni = new IniFile("config.ini");
            OdbcConnection connection = new OdbcConnection();
            connection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb)}; Dbq="+ readIni.Read("DbUM","Database");


            connection.Open();
            string query = "SELECT Calibraciones.IdCalibración, Calibraciones.FechaCalibración,  Calibraciones.NúmeroSerie, Calibraciones.Operador, Contadores.MarcaContador, Contadores.ModeloContador, Contadores.Diámetro, Contadores.PresiónNominal, Calibraciones.TotalizadorIni, Calibraciones.TotalizadorFin, Calibraciones.IdCliente from Calibraciones inner join Contadores on Calibraciones.NúmeroSerie=Contadores.NúmeroSerie";// UNION ALL SELECT SerialNumber from Meters";// UNION ALL SELECT Operator, Program from Calibrations UNION ALL SELECT MeterData1, MeterData2, MeterData3, MeterData4, MeterData5, MeterData6, MeterData7, MeterData8, MeterData9, MeterData10 FROM Meters";
            OdbcCommand command = new OdbcCommand(query, connection);
            command.ExecuteNonQuery();
            OdbcDataAdapter adapter = new OdbcDataAdapter(command);


            adapter.Fill(data);
            dataGrid.DataContext = data;

            dataGrid.ItemsSource = data.DefaultView;
            adapter.Update(data);
            connection.Close();
        }
        public static void Data3(DataGrid dataGrid, DataTable data)
        {
            IniFile readIni = new IniFile("config.ini");
            OdbcConnection connection = new OdbcConnection();
            connection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb)}; Dbq="+ readIni.Read("DbSN","Database");


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
        }

    }
}
