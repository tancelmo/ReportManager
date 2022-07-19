using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ReportManager.ExportsMods
{
    public class ExportMode
    {
        public static void ReplacementUTG250(string filename, DataGrid dataGrid, Microsoft.Office.Interop.Excel.Application xlapp)
        {
            Mouse.OverrideCursor = Cursors.Wait;

            IniFile iniFile = new IniFile("config.ini");

            xlapp.Visible = false;
            
            string sourceFile = Convert.ToString(iniFile.Read("TemplateFolder1", "DirectoryTemplates") + "\\" + filename + iniFile.Read("ReportExtension", "General"));
            string destFile = Convert.ToString(iniFile.Read("TemplateFolder1", "DirectoryTemplates") + "\\Temp\\" + "REPORT1" + iniFile.Read("ReportExtension", "General"));
            string markUp = iniFile.Read("MarkUP", "General");
            int filecount = 1;
            xlapp.DisplayAlerts = false;
            // Arquivo de saída
            while (File.Exists(destFile))
            {
                filecount++;
                destFile = Convert.ToString(iniFile.Read("TemplateFolder1", "DirectoryTemplates") + "\\Temp\\" + "REPORT" + filecount + iniFile.Read("ReportExtension", "General"));
            }
            DataRowView selected = dataGrid.SelectedItem as DataRowView;

            // nada selecionado
            if (selected == null)
            {
                MessageBox.Show("Nada selecionado");
            }
            else
            {
                try
                {
                    File.Copy(sourceFile, destFile, true);
                }catch (Exception ex)
                {
                    LogFile.Write(ex.Message, "#800009");
                    Mouse.OverrideCursor = null;
                    return;
                    
                }
                

                Workbook wb = xlapp.Workbooks.Open(destFile);

                

                Connection connection = new Connection(Globals.DataAdressUT);
                connection.Connect();

                string secondMeter = "";

                try
                {
                    OdbcCommand cmd = new OdbcCommand();
                    cmd.CommandText = "select * from Meters where CalibrationId=" + selected[0].ToString();
                    cmd.Connection = connection.Connect();
                    OdbcDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        secondMeter = Convert.ToString(reader["SlowEmitterError"]);

                    }

                }
                catch(Exception ex)
                {
                    LogFile.Write(ex.Message, "#800005");
                    
                }

                void getValeus(int sheetNumber)
                {



                    Range oRng1 = wb.Worksheets[sheetNumber].Cells;
                    
                    //-- Contador quantas Strings contem na chave MarkUP para substituir
                    int index = Convert.ToInt32(xlapp.WorksheetFunction.CountIf(oRng1, "*" + markUp + "*"));
                    //-------------

                    Range[] dataRange = new Range[index + 1];
                    
                    
                    for (int j = 0; j <= index; j++)
                    {
                        dataRange[j] = oRng1.Find(markUp, Type.Missing, Type.Missing, XlLookAt.xlPart);
                        
                        if (dataRange[j] != null)
                        {


                            string firstData = dataRange[j].Value2;
                            
                            if (firstData.Contains("2" + markUp))

                            {

                                string arg1 = firstData.Between(markUp, markUp);
                                string arg2 = firstData.Between(arg1, null);
                                arg2 = arg2.Between(markUp, null);
                                OdbcCommand cmd = new OdbcCommand();
                                cmd.CommandText = "select * from " + arg1.Replace("2", "") + " where CalibrationId=" + secondMeter;

                                try
                                {
                                    cmd.Connection = connection.Connect();
                                    OdbcDataReader reader = cmd.ExecuteReader();

                                    while (reader.Read())
                                    {
                                        wb.Worksheets[sheetNumber].Cells.Replace(firstData, reader[arg2].ToString(), XlLookAt.xlWhole);
                                    }

                                }
                                catch(Exception ex)
                                {
                                    LogFile.Write(ex.Message, "#800006");
                                }

                            }
                            else
                            {
                                string arg1 = firstData.Between(markUp, markUp);
                                string arg2 = firstData.Between(arg1, null);
                                arg2 = arg2.Between(markUp, null);
                                OdbcCommand cmd = new OdbcCommand();
                                try
                                {
                                    //original---
                                    cmd.CommandText = "select * from " + arg1 + " where CalibrationId=" + selected[0].ToString();
                                    //--------

                                    //cmd.CommandText = "select COUNT(*) from " + arg1 + " where CalibrationId=" + selected[0].ToString();
                                    //cmd.CommandText = "select * from " + arg1 + " where CalibrationId=" + selected[0].ToString() + " AND PointNum=2";
                                    // cmd.CommandText = "select * from " + arg1 + "group by PointNum having count(distinct PointNum)>1 where CalibrationId=" + selected[0].ToString();
                                    //cmd.CommandText = "SELECT CalibrationID from ( SELECT CalibrationId, ROW_NUMBER() OVER (PARTITION BY FormId ORDER BY NEWID()) AS RowNumber FROM " + arg1 + ") t Where t.RowNumber = 1";

                                    cmd.Connection = connection.Connect();
                                    OdbcDataReader reader = cmd.ExecuteReader();

                                    while (reader.Read())
                                    {
                                        //TODO: InsertMode on exportsMode
                                        // if (firstData.Contains("Tests")){
                                        //    iniFile.Write("Adress", dataRange[j].get_Address());
                                        //    var adress = iniFile.Read("Adress");
                                        //    dataRange.Reverse();
                                        //  // MessageBox.Show(adress);
                                        //    wb.Worksheets[sheetNumber].Range[adress].Insert(XlDirection.xlDown, XlInsertFormatOrigin.xlFormatFromLeftOrAbove);
                                        //    wb.Worksheets[sheetNumber].Range[adress] = reader[arg2];

                                        //}
                                        //wb.Worksheets[sheetNumber].Range[dataRange[j].Address].Insert();
                                        wb.Worksheets[sheetNumber].Cells.Replace(firstData, reader[arg2].ToString(), XlLookAt.xlWhole);
                                        //dataRange[j].Insert(XlInsertShiftDirection.xlShiftDown, reader[arg2].ToString() + "\n");
                                        //LogFile.Write(dataRange[j].Address, Convert.ToString(firstData.ToString()) + " " + reader[arg2].ToString());
                                        
                                    }
                                }catch(Exception ex)
                                {
                                    LogFile.Write(ex.Message, "#800007");
                                }
                                
                            }

                        }

                    }

                }
                
                int count;
                count = wb.Worksheets.Count;

                for (int i = 1; i <= count; i++)
                {

                   wb.Worksheets[i].Unprotect("utg250_614");
                    getValeus(i);

                   wb.Worksheets[i].Protect("utg250_614");

                }
                Mouse.OverrideCursor = null;
                connection.Disconnect();
                xlapp.DisplayAlerts = true;
                xlapp.Visible = true;
            }


        }

    }
}
    

