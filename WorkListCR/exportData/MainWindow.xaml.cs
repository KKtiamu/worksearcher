using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;
using System.Xml.Linq;

namespace exportData
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

        private void buttonExport_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                filePath = ofd.FileName;
                if(validateFileName(filePath))
                {
                    exportXml(filePath);
                }
            }
        }

        private bool validateFileName(string filePath)
        {
            return filePath.Contains(".xml");
        }

        private void exportXml(string filePath)
        {
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(filePath, FileMode.Open);
            xd.Load(fs);
            foreach (XmlElement vacancy in xd.GetElementsByTagName("VOLNEMISTO"))
            {
                int idVzdelani = 0;
                var vzdelani = vacancy.GetElementsByTagName("MIN_VZDELANI");
                if (vzdelani.Count > 0)
                {
                    idVzdelani = DataModel.VolneMistaBLL.saveVzdelani(vzdelani[0].Attributes["kod"].Value, vzdelani[0].Attributes["nazev"].Value);
                }

                int idSmennost = 0;
                var smeny = vacancy.GetElementsByTagName("SMENNOST");
                if (smeny.Count > 0)
                {
                    idSmennost = DataModel.VolneMistaBLL.saveSmeny(smeny[0].Attributes["kod"].Value, smeny[0].Attributes["nazev"].Value);
                }

                int idUP = 0;
                var UP = vacancy.GetElementsByTagName("URAD_PRACE");
                if (UP.Count > 0)
                {
                    idUP = DataModel.VolneMistaBLL.saveUP(UP[0].Attributes["kod"].Value, UP[0].Attributes["nazev"].Value);
                }

                int idObor = 0;
                var obor = vacancy.GetElementsByTagName("OBOR");
                if (obor.Count > 0)
                {
                    idObor = DataModel.VolneMistaBLL.saveObor(obor[0].Attributes["kod"].Value, obor[0].Attributes["nazev"].Value);
                }

                int idProf = 0;
                var prof = vacancy.GetElementsByTagName("PROFESE");
                if (prof.Count > 0)
                {
                    idProf = DataModel.VolneMistaBLL.saveObor(prof[0].Attributes["kod"].Value, prof[0].Attributes["nazev"].Value);
                }



            }
        }
    }
}
