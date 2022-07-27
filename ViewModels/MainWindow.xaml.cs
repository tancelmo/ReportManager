using ReportManager.ViewModels;
using ReportManager.ViewModels.UserControls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ReportManager
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        
        
        UCData1 ucObj1;
        UCData2 ucObj2;
        UCData3 ucObj3;
        ConfigPage ConfigPage;
        



        public string UserNameLabel; 
        public string UserLevelLabel;

        

        public MainWindow()
        {
            
            //DataContext = this;
            StartUp.Theme(this);
            StartUp.Language(this);
            InitializeComponent();
            

            
            StartUp.ThemeSwitch(DarkModeToggleButton);
            DataRetriever.GetDataAdress();
            DataRetriever.GetFolderAdress();
            UserNameLabel = Convert.ToString(FindResource("UserName"));
            UserLevelLabel = Convert.ToString(FindResource("UserLevel"));

        }
        

        public static RoutedCommand SearchToolbox = new RoutedCommand();



        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                BtnRestore.Visibility = Visibility.Visible;
                BtnMaximize.Visibility = Visibility.Collapsed;
            }
            else if (WindowState == WindowState.Normal)
            {
                BtnRestore.Visibility = Visibility.Collapsed;
                BtnMaximize.Visibility = Visibility.Visible;
            }
            
            //MenuAnimation
            if (Width < 1170)
            {
                if (Menu.Width == 240)
                {
                    Animations.AnimateMenuWidth(Menu, 60, false);
                    //Sonical.Width = 40;
                    //ut.Width = 40;
                    //um.Width = 40;

                    //Sonical.Content = FindResource("MenuShortName1");
                    //ut.Content = FindResource("MenuShortName2");
                    //um.Content = FindResource("MenuShortName3");

                    //Sonical.HorizontalContentAlignment = HorizontalAlignment.Center;
                    //ut.HorizontalContentAlignment = HorizontalAlignment.Center;
                    //um.HorizontalContentAlignment = HorizontalAlignment.Center;

                    //Sonical.Padding = new Thickness(0, 0, 0, 0);
                    //um.Padding = new Thickness(0, 0, 0, 0);
                    //ut.Padding = new Thickness(0, 0, 0, 0);

                    Animations.AnimateMargin(grid1, 60);
                    
                }
            }
            

        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnMaximize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        private void BtnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                BtnRestore.Visibility = Visibility.Collapsed;
                BtnMaximize.Visibility = Visibility.Visible;
            }
            else if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
                BtnRestore.Visibility = Visibility.Visible;
                BtnMaximize.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void TbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
         if (TbxSearch.Text != String.Empty)
            {
                BtnClear.Visibility = Visibility.Visible;
            }
            else
            {
                BtnClear.Visibility = Visibility.Collapsed;
            }  

            
            if (ut.IsSelected == true)
            {

                ucObj1.SnFilter.IsChecked = false;
                ucObj1.DataFilter.IsChecked = false;
                ucObj1.data.DefaultView.RowFilter = string.Format("[SerialNumber] Like '%{0}%'", TbxSearch.Text);
                ucObj1.datagridUT.ItemsSource = ucObj1.data.DefaultView;
            }

            if (um.IsSelected == true)
            {

                ucObj2.SnFilter.IsChecked = false;
                ucObj2.DataFilter.IsChecked = false;
                ucObj2.data.DefaultView.RowFilter = string.Format("[NúmeroSerie] Like '%{0}%'", TbxSearch.Text);
                ucObj2.datagridUM.ItemsSource = ucObj2.data.DefaultView;
                

            }
            if (Sonical.IsSelected == true)
            {
                ucObj3.SnFilter.IsChecked = false;
                ucObj3.DataFilter.IsChecked = false;
                ucObj3.data.DefaultView.RowFilter = string.Format("[SerialNumber] Like '%{0}%'", TbxSearch.Text);
                ucObj3.datagridSN.ItemsSource = ucObj3.data.DefaultView;
                
            }
            
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            ucObj1 = new UCData1();
            TbxSearch.Text = String.Empty;
            grid1.Children.Add(ucObj1);
            Common.HideLabelWarn(Attention0, Attention1);
            grid1.Children.Remove(ucObj2);
            grid1.Children.Remove(ucObj3);
            LabelDb.Content = FindResource("MenuName2");
            LabelDb.ToolTip = FindResource("MenuName2") + " - " + Globals.DataAdressUT;
            ShortSelectedMenu.Content = FindResource("CurrentData") + "" + FindResource("MenuName2");

        }

        private void RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            
            ucObj1.datagridUT = null;
            grid1.Children.Remove(ucObj1);
            this.UpdateLayout();
            


        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            ucObj2 = new UCData2();
            TbxSearch.Text = String.Empty;
            grid1.Children.Add(ucObj2);
            Common.HideLabelWarn(Attention0, Attention1);
            grid1.Children.Remove(ucObj1);
            grid1.Children.Remove(ucObj3);
            LabelDb.Content = FindResource("MenuName3");
            LabelDb.ToolTip = FindResource("MenuName3") + " - " + Globals.DataAdressUM;
            ShortSelectedMenu.Content = FindResource("CurrentData") + "" + FindResource("MenuName3");
        }

        private void RadioButton_Unchecked_1(object sender, RoutedEventArgs e)
        {
            ucObj2.datagridUM = null;
            grid1.Children.Remove(ucObj2);
            this.UpdateLayout();


        }

        private void Sonical_Checked(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            ucObj3 = new UCData3();
            TbxSearch.Text = String.Empty;
            grid1.Children.Add(ucObj3);
            Common.HideLabelWarn(Attention0, Attention1);
            grid1.Children.Remove(ucObj1);
            grid1.Children.Remove(ucObj2);
            
            LabelDb.Content = FindResource("MenuName1");
            LabelDb.ToolTip = FindResource("MenuName1") + " - " + Globals.DataAdressSN;
            ShortSelectedMenu.Content = FindResource("CurrentData") + "" + FindResource("MenuName1");


        }

        private void Sonical_Unchecked(object sender, RoutedEventArgs e)
        {
            ucObj3.datagridSN = null;
            grid1.Children.Remove(ucObj3);
            this.UpdateLayout();
            

        }

        private void TbxSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            
            if (TbxSearch.Text == String.Empty)
            {
                MaterialDesignThemes.Wpf.HintAssist.SetHint(TbxSearch, Convert.ToString(FindResource("GeneralSearchPlaceHolder")));
            }

        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {


            TbxSearch.Focus();
            TbxSearch.SelectionStart = 1;
            //TbxSearch.Tag = Convert.ToString(FindResource("GeneralSearchPlaceHolder2"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(TbxSearch, Convert.ToString(FindResource("GeneralSearchPlaceHolder2")));


        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
        }

        private void TbxSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            MaterialDesignThemes.Wpf.HintAssist.SetHint(TbxSearch, Convert.ToString(FindResource("GeneralSearchPlaceHolder2")));
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (Menu.Width == 60)
            {
                Animations.AnimateMenuWidth(Menu, 240, false);
                Animations.AnimateMargin(grid1, 240);
                ShortSelectedMenu.Visibility = Visibility.Collapsed;
                MenuTree.Visibility = Visibility.Visible;

            }
            else
            {
                Animations.AnimateMenuWidth(Menu, 60, false);
                Animations.AnimateMargin(grid1, 60);
                ShortSelectedMenu.Visibility = Visibility.Visible;
                MenuTree.Visibility = Visibility.Collapsed;

            }


        }

        private void TbxSearch_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Common.MenuTimer(dispatcherTimer_Tick);
            
            
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TbxSearch.Clear();
            TbxSearch.Focus();

        }

        private void BtnConfig_Click(object sender, RoutedEventArgs e)
        {
            ConfigPage configPage = new ConfigPage();
            grid1.Children.Add(configPage);
        }

        

        private void BtnMaximize_MouseEnter(object sender, MouseEventArgs e)
        {
            //SendKeys.Send(Key.LWin);
            //SendKeys.Send(Key.Z);
            //Common.AlternativeWindows11SnapLayout();
            //MessageBox.Show("oi");
            
        }

        private void DarkModeToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (DarkModeToggleButton.IsChecked == true)
            {
                StartUp.SetTheme(true);
                Common.ChangeTheme(this, "Dark");
                Common.ActivedCaptionForeground(MenuButton, BtnClose, BtnRestore, Btn_Config, BtnMinimize, BtnMaximize, IconPopUP, LabelDb);
            }
            else
            {
                StartUp.SetTheme(false);
                Common.ChangeTheme(this, "Light");
                Common.ActivedCaptionForeground(MenuButton, BtnClose, BtnRestore, Btn_Config, BtnMinimize, BtnMaximize, IconPopUP, LabelDb);
            }
            
        }

        private void TbxSearch_MouseEnter(object sender, MouseEventArgs e)
        {
            //TbxSearch.Foreground = (Brush)FindResource("MaterialDesignBody");
        }

        private void TbxSearch_MouseLeave(object sender, MouseEventArgs e)
        {
            //var brush = new SolidColorBrush(Color.FromRgb(250, 250, 250));
            //var brush2 = new SolidColorBrush(Color.FromRgb(144, 144, 144));
            //TbxSearch.Background = brush;
            //TbxSearch.Foreground = brush2;
        }

        private void LabelDb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.ShowDialog();
            
        }

        private void Menu_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Menu.Width == 60)
            {
                Animations.AnimateMenuWidth(Menu, 240, false);
                //Sonical.Width = 40;
                //ut.Width = 40;
                //um.Width = 40;

                //Sonical.Content = FindResource("MenuShortName1");
                //ut.Content = FindResource("MenuShortName2");
                //um.Content = FindResource("MenuShortName3");

                //Sonical.HorizontalContentAlignment = HorizontalAlignment.Center;
                //ut.HorizontalContentAlignment = HorizontalAlignment.Center;
                //um.HorizontalContentAlignment = HorizontalAlignment.Center;

                //Sonical.Padding = new Thickness(0, 0, 0, 0);
                //um.Padding = new Thickness(0, 0, 0, 0);
                //ut.Padding = new Thickness(0, 0, 0, 0);

                Animations.AnimateMargin(grid1, 240);
                ShortSelectedMenu.Visibility = Visibility.Collapsed;
                MenuTree.Visibility = Visibility.Visible;

            }
            //else if (Width < 1170)
            //{

            //}
            //else
            //{
            //    Animations.AnimateMenuWidth(Menu, 240, false);
            //    //Sonical.Width = 220;
            //    //ut.Width = 220;
            //    //um.Width = 220;
            //    //Sonical.Content = FindResource("MenuName1");
            //    //ut.Content = FindResource("MenuName2");
            //    //um.Content = FindResource("MenuName3");

            //    //Sonical.HorizontalContentAlignment = HorizontalAlignment.Left;
            //    //ut.HorizontalContentAlignment = HorizontalAlignment.Left;
            //    //um.HorizontalContentAlignment = HorizontalAlignment.Left;

            //    //Sonical.Padding = new Thickness(10, 0, 0, 0);
            //    //um.Padding = new Thickness(10, 0, 0, 0);
            //    //ut.Padding = new Thickness(10, 0, 0, 0);

            //    Animations.AnimateMargin(grid1, 240);

            //}
        }

        private void Menu_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Menu.Width == 240)
            {
                Animations.AnimateMenuWidth(Menu, 60, false);
                //Sonical.Width = 40;
                //ut.Width = 40;
                //um.Width = 40;

                //Sonical.Content = FindResource("MenuShortName1");
                //ut.Content = FindResource("MenuShortName2");
                //um.Content = FindResource("MenuShortName3");

                //Sonical.HorizontalContentAlignment = HorizontalAlignment.Center;
                //ut.HorizontalContentAlignment = HorizontalAlignment.Center;
                //um.HorizontalContentAlignment = HorizontalAlignment.Center;

                //Sonical.Padding = new Thickness(0, 0, 0, 0);
                //um.Padding = new Thickness(0, 0, 0, 0);
                //ut.Padding = new Thickness(0, 0, 0, 0);

                Animations.AnimateMargin(grid1, 60);
                ShortSelectedMenu.Visibility = Visibility.Visible;
                MenuTree.Visibility = Visibility.Collapsed;

            }
            //else if (Width < 1170)
            //{

            //}
            //else
            //{
            //    Animations.AnimateMenuWidth(Menu, 240, false);
            //    //Sonical.Width = 220;
            //    //ut.Width = 220;
            //    //um.Width = 220;
            //    //Sonical.Content = FindResource("MenuName1");
            //    //ut.Content = FindResource("MenuName2");
            //    //um.Content = FindResource("MenuName3");

            //    //Sonical.HorizontalContentAlignment = HorizontalAlignment.Left;
            //    //ut.HorizontalContentAlignment = HorizontalAlignment.Left;
            //    //um.HorizontalContentAlignment = HorizontalAlignment.Left;

            //    //Sonical.Padding = new Thickness(10, 0, 0, 0);
            //    //um.Padding = new Thickness(10, 0, 0, 0);
            //    //ut.Padding = new Thickness(10, 0, 0, 0);

            //    Animations.AnimateMargin(grid1, 240);

            //}
        }

     
        

        private void MenuTree_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            //ScrollViewer scroll = (ScrollViewer)sender;
            //if (e.Delta < 0)
            //{
            //    if (scroll.VerticalOffset - e.Delta <= scroll.ExtentHeight - scroll.ViewportHeight)
            //    {
            //        scroll.ScrollToVerticalOffset(scroll.VerticalOffset - e.Delta);
            //    }
            //    else
            //    {
            //        scroll.ScrollToBottom();
            //    }
            //}
            //else
            //{
            //    if (scroll.VerticalOffset + e.Delta > 0)
            //    {
            //        scroll.ScrollToVerticalOffset(scroll.VerticalOffset - e.Delta);
            //    }
            //    else
            //    {
            //        scroll.ScrollToTop();
            //    }
            //}
            //e.Handled = true;

            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void Btn_Config_Click(object sender, RoutedEventArgs e)
        {
            
            ConfigPage = new ConfigPage();
            TbxSearch.Text = String.Empty;
            grid1.Children.Add(ConfigPage);
            Common.HideLabelWarn(Attention0, Attention1);
            grid1.Children.Remove(ucObj1);
            grid1.Children.Remove(ucObj2);
            grid1.Children.Remove(ucObj3);
            LabelDb.Content = FindResource("MenuConfig");
            LabelDb.ToolTip = FindResource("MenuConfig") + " - " + Globals.DataAdressUT;
            ShortSelectedMenu.Content = FindResource("CurrentData") + "" + FindResource("MenuConfig");
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Common.ActivedCaptionForeground(MenuButton, BtnClose, BtnRestore, Btn_Config, BtnMinimize, BtnMaximize, IconPopUP, LabelDb);
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            Common.DeactivedCaptionForeground(MenuButton, BtnClose, BtnRestore, Btn_Config, BtnMinimize, BtnMaximize, IconPopUP, LabelDb);
        }
    }
}
