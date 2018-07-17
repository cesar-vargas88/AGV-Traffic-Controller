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
using System.Windows.Shapes;

namespace AGV_Traffic_Controller
{
    /// <summary>
    /// Interaction logic for LoadMapWindow.xaml
    /// </summary>
    public partial class LoadMapWindow : Window
    {
        public bool flagLoad;

        private List<Map> list_Maps;
        public Map map;

        public LoadMapWindow(List<Map> List_Maps)
        {
            InitializeComponent();

            list_Maps = List_Maps;
            flagLoad = false;

            for (int MapIndex = 0; MapIndex < list_Maps.Count; MapIndex++)
                lboxMaps.Items.Add(list_Maps[MapIndex].name);
        }

        /// <summary>
        /// This method will enable btnLoad button when the chbox_maps has an item selected.
        /// </summary>
        private void lboxMaps_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnLoad.IsEnabled = true;
        }
        /// <summary>
        /// This method will close the window.
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            map = list_Maps[lboxMaps.SelectedIndex];
            flagLoad = true;
            this.Close();
        }
    }
}
