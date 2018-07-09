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

namespace AGV_Traffic_Controller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabItemMaps.IsSelected)
            {
                tabItemMaps.Foreground = Brushes.SteelBlue;
                tabItemRobots.Foreground = Brushes.Gray;
                tabItemTasks.Foreground = Brushes.Gray;
                tabItemSettings.Foreground = Brushes.Gray;
                tabItemLogs.Foreground = Brushes.Gray;
            }
            else if (tabItemRobots.IsSelected)
            {
                tabItemMaps.Foreground = Brushes.Gray;
                tabItemRobots.Foreground = Brushes.SteelBlue;
                tabItemTasks.Foreground = Brushes.Gray;
                tabItemSettings.Foreground = Brushes.Gray;
                tabItemLogs.Foreground = Brushes.Gray;
            }          
            else if (tabItemTasks.IsSelected)
            {
                tabItemMaps.Foreground = Brushes.Gray;
                tabItemRobots.Foreground = Brushes.Gray;
                tabItemTasks.Foreground = Brushes.SteelBlue;
                tabItemSettings.Foreground = Brushes.Gray;
                tabItemLogs.Foreground = Brushes.Gray;
            }
            else if (tabItemSettings.IsSelected)
            {
                tabItemMaps.Foreground = Brushes.Gray;
                tabItemRobots.Foreground = Brushes.Gray;
                tabItemTasks.Foreground = Brushes.Gray;
                tabItemSettings.Foreground = Brushes.SteelBlue;
                tabItemLogs.Foreground = Brushes.Gray;
            }
            else if (tabItemLogs.IsSelected)
            {
                tabItemMaps.Foreground = Brushes.Gray;
                tabItemRobots.Foreground = Brushes.Gray;
                tabItemTasks.Foreground = Brushes.Gray;
                tabItemSettings.Foreground = Brushes.Gray;
                tabItemLogs.Foreground = Brushes.SteelBlue;
            }
        }


    }
}
