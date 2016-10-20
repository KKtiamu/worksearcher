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
    /// Interaction logic for Searcher.xaml
    /// </summary>
    public partial class Searcher : Window
    {
        List<int> filterOkresy = new List<int>();
        List<int> filterObor = new List<int>();
        List<int> filterJazyk = new List<int>();
        List<int> filterSmeny = new List<int>();
        List<int> filterVzdelani = new List<int>();

        public Searcher()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
            this.Close();
        }

        private void buttonObecAdd_Click(object sender, RoutedEventArgs e)
        {
            FindWindow newWindow = new FindWindow();
            newWindow.dataName = "okres";
            if (newWindow.ShowDialog().Value == true)
            {
                labelObecArray.Content += newWindow.selectedString + Environment.NewLine;
                filterOkresy.Add(newWindow.selectedId);
            } 
        }

        private void buttonOborAdd_Click(object sender, RoutedEventArgs e)
        {
            FindWindow newWindow = new FindWindow();
            newWindow.dataName = "obor";
            if (newWindow.ShowDialog().Value == true)
            {
                labelOborArray.Content += newWindow.selectedString+ Environment.NewLine;
                filterObor.Add(newWindow.selectedId);
            }
        }

        private void buttonJazykAdd_Click(object sender, RoutedEventArgs e)
        {
            FindWindow newWindow = new FindWindow();
            newWindow.dataName = "jazyk";
            if (newWindow.ShowDialog().Value == true)
            {
                labelJazykArray.Content = newWindow.selectedString+ Environment.NewLine;
                filterJazyk.Add(newWindow.selectedId);
            }
        }

        private void buttonSmenyAdd_Click(object sender, RoutedEventArgs e)
        {
            FindWindow newWindow = new FindWindow();
            newWindow.dataName = "smeny";
            if (newWindow.ShowDialog().Value == true)
            {
                labelSmenyArray.Content = newWindow.selectedString+ Environment.NewLine;
                filterSmeny.Add(newWindow.selectedId);
            }
        }

        private void buttonVzdelaniAdd_Click(object sender, RoutedEventArgs e)
        {
            FindWindow newWindow = new FindWindow();
            newWindow.dataName = "vzdelani";
            if (newWindow.ShowDialog().Value == true)
            {
                labelVzdelaniArray.Content = newWindow.selectedString+ Environment.NewLine;
                filterVzdelani.Add(newWindow.selectedId);
            }
        }

        private void buttonGo_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            var sourceVM = DataModel.Searcher.getVM(0);
            foreach(int id in filterOkresy)
            {
                sourceVM = sourceVM.Where(x => x.idObce.Split(',')[0] == id.ToString());
            }
            foreach (int id in filterSmeny)
            {
                sourceVM = sourceVM.Where(x => x.idSmena == id);
            }
            foreach(int id in filterVzdelani)
            {
                sourceVM = sourceVM.Where(x => x.idVzdelani == id);
            }
            foreach(int id in filterObor)
            {
                sourceVM = (from svm in sourceVM
                            from prof in DataModel.Searcher.getProfByObor(id)
                            where svm.idProf == prof.id
                            select svm);
            }
            foreach(int id in filterJazyk)
            {
                sourceVM = (from svm in sourceVM
                            from jaz in DataModel.Searcher.getVmByJazyk(id)
                            where svm.id == jaz.idVM
                            select svm);
            }
            dataGrid.ItemsSource = sourceVM.ToList();
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
        }
    }
}
