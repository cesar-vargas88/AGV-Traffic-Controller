//////////////////////////////////////////////////////////////////////////
//      Project           : AGV Traffic Controller
//      Program name      : AGV Traffic Controller
//      Author            : César Augusto Vargas Torres
//      Date created      : 01/07/2018
//      Purpose           : 
//      Revision History  :
//////////////////////////////////////////////////////////////////////////

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        /// <summary>
        /// Here we change the color of tab Items in order to let know the user which one is selected.
        /// </summary>
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
