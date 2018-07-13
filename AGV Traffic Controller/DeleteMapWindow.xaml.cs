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
    /// Interaction logic for DeleteMapWindow.xaml
    /// </summary>
    public partial class DeleteMapWindow : Window
    {
        public bool flagDelete;

        private List<Map> list_Maps;

        public DeleteMapWindow(List<Map> List_Maps)
        {
            InitializeComponent();

            list_Maps = List_Maps;
            flagDelete = false;

            for (int MapIndex = 0; MapIndex < list_Maps.Count; MapIndex++)
                lboxMaps.Items.Add(list_Maps[MapIndex].name);
        }

        /// <summary>
        /// This method will enable btnDelete button when the chbox_maps has an item selected.
        /// </summary>
        private void lboxMaps_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lboxMaps.SelectedIndex > -1)
                btnDelete.IsEnabled = true;
        }
        /// <summary>
        /// This method will close the window.
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            list_Maps.RemoveAt(lboxMaps.SelectedIndex);
            lboxMaps.Items.RemoveAt(lboxMaps.SelectedIndex);

            this.Close();
        }        
    }
}
