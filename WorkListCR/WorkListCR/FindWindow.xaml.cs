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

namespace WorkListCR
{
    /// <summary>
    /// Interaction logic for FindWindow.xaml
    /// </summary>
    public partial class FindWindow : Window
    {
        public int selectedId = -1;
        public string selectedString="";

        private string _dataName="";
        public string dataName
        {
            get { return _dataName; }
            set
            {
                _dataName = value;
                if(value == "okres")
                {
                    var newData = DataModel.Searcher.getOkres(0);
                    dataGrid.ItemsSource = newData;
                }
                else if (value == "obor")
                {
                    var newData = DataModel.Searcher.getObor(0);
                    dataGrid.ItemsSource = newData;
                }
                else if (value == "jazyk")
                {
                    var newData = DataModel.Searcher.getJazyk(0);
                    dataGrid.ItemsSource = newData;
                }
                else if (value == "smeny")
                {
                    var newData = DataModel.Searcher.getSmeny(0);
                    dataGrid.ItemsSource = newData;
                }
                else if (value == "vzdelani")
                {
                    var newData = DataModel.Searcher.getVzdelani(0);
                    dataGrid.ItemsSource = newData;
                }
            }
        }

        public FindWindow()
        {
            InitializeComponent();
        }

        private void selectItem()
        {
            if (dataGrid.SelectedIndex > -1)
            {
                if (_dataName == "okres")
                {
                    selectedId = ((DataModel.SelectOkresResult)(dataGrid.SelectedItems[0])).id;
                    selectedString = ((DataModel.SelectOkresResult)(dataGrid.SelectedItems[0])).name;
                }
                else if (_dataName == "obor")
                {
                    selectedId = ((DataModel.SelectOborResult)(dataGrid.SelectedItems[0])).id;
                    selectedString = ((DataModel.SelectOborResult)(dataGrid.SelectedItems[0])).name;
                }
                else if (_dataName == "jazyk")
                {
                    selectedId = ((DataModel.SelectJazykResult)(dataGrid.SelectedItems[0])).id;
                    selectedString = ((DataModel.SelectJazykResult)(dataGrid.SelectedItems[0])).name;
                }
                else if (_dataName == "smeny")
                {
                    selectedId = ((DataModel.SelectSmenyResult)(dataGrid.SelectedItems[0])).id;
                    selectedString = ((DataModel.SelectSmenyResult)(dataGrid.SelectedItems[0])).name;
                }
                else if (_dataName == "vzdelani")
                {
                    selectedId = ((DataModel.SelectVzdelaniResult)(dataGrid.SelectedItems[0])).id;
                    selectedString = ((DataModel.SelectVzdelaniResult)(dataGrid.SelectedItems[0])).name;
                }
                this.DialogResult = true;
            }
        }

        private void buttonSelect_Click(object sender, RoutedEventArgs e)
        {
            selectItem();
        }
    }
}
