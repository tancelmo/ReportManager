using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace ReportManager
{
    class Animations
    {
        public static void AnimateMenuWidth(Grid grid, double width, bool isRelative = false)
        {
            //---------------------------------------------------
            //  Settings
            //---------------------------------------------------

            TimeSpan duration = TimeSpan.FromSeconds(0.2);
            double newWidth = isRelative ? grid.Width - width : width;

            _ = grid.Dispatcher.BeginInvoke(new Action(() =>
            {
                Storyboard storyboard = new Storyboard();


                //---------------------------------------------------
                //  Animate Height
                //---------------------------------------------------
                DoubleAnimation widthAnimation = new DoubleAnimation()
                {
                    Duration = new Duration(duration),
                    From = grid.ActualWidth,
                    To = newWidth
                };


                Storyboard.SetTarget(widthAnimation, grid);

                Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(Grid.WidthProperty));
                storyboard.Children.Add(widthAnimation);

                //---------------------------------------------------
                //  Play
                //---------------------------------------------------
                grid.BeginStoryboard(storyboard, HandoffBehavior.SnapshotAndReplace, false);
            }), null);
        }

        public static void AnimateMargin(Grid grid, int newMargin)
        {
            var sb = new Storyboard();
            var ta = new ThicknessAnimation();
            ta.BeginTime = new TimeSpan(0);
            
            Storyboard.SetTargetProperty(ta, new PropertyPath(Grid.MarginProperty));
            var actualMargin = grid.Margin.Left;
            ta.From = new Thickness(actualMargin, 45, 0, 0);
            ta.To = new Thickness(newMargin, 45, 0, 0);
            ta.Duration = new Duration(TimeSpan.FromSeconds(0.2));

            sb.Children.Add(ta);
            sb.Begin(grid);
        }
    }
}
