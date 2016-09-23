﻿using Microsoft.Win32;
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
                try { 
                string kodVacancy = vacancy.Attributes["uid"].Value;
                    if (!DataModel.VolneMistaBLL.isExist(kodVacancy))
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
                            idProf = DataModel.VolneMistaBLL.saveProf(prof[0].Attributes["kod"].Value, prof[0].Attributes["nazev"].Value, idObor);
                        }

                        string idCoobce = "";
                        var city = vacancy.GetElementsByTagName("PRACOVISTE");
                        if (city.Count > 0)
                        {
                            if (city[0].Attributes["neurcitaAdresa"].Value == "N")
                            {
                                idCoobce = DataModel.VolneMistaBLL.saveCoObce(city[0].Attributes["cobce"] != null ? city[0].Attributes["cobce"].Value : "", city[0].Attributes["obec"].Value,
                                    city[0].Attributes["okres"].Value, city[0].Attributes["psc"] != null ? city[0].Attributes["psc"].Value : "", city[0].Attributes["okresKod"].Value);
                            }
                        }

                        string jazyky = "";
                        var jazyk = vacancy.GetElementsByTagName("JAZYK");
                        for (int i = 0; i < jazyk.Count; i++)
                        {
                            jazyky += DataModel.VolneMistaBLL.saveJazyk(jazyk[i].Attributes["kod"].Value, jazyk[i].Attributes["nazev"].Value,
                                    jazyk[i].Attributes["urovenKod"].Value, jazyk[i].Attributes["uroven"].Value).ToString() + ",";
                        }

                        string typeZamest = "";
                        var typeZ = vacancy.GetElementsByTagName("VHODNE_PRO");
                        if (typeZ.Count > 0)
                        {
                            typeZamest += ((typeZ[0].Attributes["absolventySs"].Value == "A") ? DataModel.VolneMistaBLL.getTypeZamestn("absolventySs").ToString() + "," : "");
                            typeZamest += ((typeZ[0].Attributes["absolventyVs"].Value == "A") ? DataModel.VolneMistaBLL.getTypeZamestn("absolventyVs").ToString() + "," : "");
                            typeZamest += ((typeZ[0].Attributes["ozp"].Value == "A") ? DataModel.VolneMistaBLL.getTypeZamestn("ozp").ToString() + "," : "");
                            typeZamest += ((typeZ[0].Attributes["bezbar"].Value == "A") ? DataModel.VolneMistaBLL.getTypeZamestn("bezbar").ToString() + "," : "");
                            typeZamest += ((typeZ[0].Attributes["cizince"].Value == "A") ? DataModel.VolneMistaBLL.getTypeZamestn("cizince").ToString() + "," : "");
                            typeZamest += ((typeZ[0].Attributes["azylanty"].Value == "A") ? DataModel.VolneMistaBLL.getTypeZamestn("azylanty").ToString() + "," : "");
                        }

                        string pracVztahy = "";
                        var pracV = vacancy.GetElementsByTagName("PRACPRAVNI_VZTAH");
                        if (pracV.Count > 0)
                        {
                            pracVztahy += ((pracV[0].Attributes["ppvztahPpPlny"].Value == "A") ? DataModel.VolneMistaBLL.getPracVztah("ppvztahPpPlny").ToString() + "," : "");
                            pracVztahy += ((pracV[0].Attributes["ppvztahPpZkrac"].Value == "A") ? DataModel.VolneMistaBLL.getPracVztah("ppvztahPpZkrac").ToString() + "," : "");
                            pracVztahy += ((pracV[0].Attributes["ppvztahSp"].Value == "A") ? DataModel.VolneMistaBLL.getPracVztah("ppvztahSp").ToString() + "," : "");
                            pracVztahy += ((pracV[0].Attributes["ppvztahDpp"].Value == "A") ? DataModel.VolneMistaBLL.getPracVztah("ppvztahDpp").ToString() + "," : "");
                            pracVztahy += ((pracV[0].Attributes["ppvztahDpc"].Value == "A") ? DataModel.VolneMistaBLL.getPracVztah("ppvztahDpc").ToString() + "," : "");
                        }

                        string aktualDateStr = vacancy.Attributes["zmena"].Value;
                        DateTime aktualDate = DateTime.Parse(aktualDateStr.Substring(0, 10));

                        string firm = vacancy.GetElementsByTagName("FIRMA")[0] != null ? vacancy.GetElementsByTagName("FIRMA")[0].Attributes["nazev"].Value : "";

                        string kontakt = vacancy.GetElementsByTagName("KONOS")[0] != null ? (vacancy.GetElementsByTagName("KONOS")[0].Attributes["jmeno"] != null ? vacancy.GetElementsByTagName("KONOS")[0].Attributes["jmeno"].Value : ""
                            + " " + vacancy.GetElementsByTagName("KONOS")[0].Attributes["prijmeni"] != null ? vacancy.GetElementsByTagName("KONOS")[0].Attributes["prijmeni"].Value : ""
                            + ". telefon:" + vacancy.GetElementsByTagName("KONOS")[0].Attributes["telefon"] != null ? vacancy.GetElementsByTagName("KONOS")[0].Attributes["telefon"].Value : ""
                            + ". email:" + vacancy.GetElementsByTagName("KONOS")[0].Attributes["email"] != null ? vacancy.GetElementsByTagName("KONOS")[0].Attributes["email"].Value : "") : "";

                        int pocetVM = Int32.Parse(vacancy.Attributes["celkemVm"].Value);

                        string poznamka = vacancy.GetElementsByTagName("POZNAMKA")[0] != null ? vacancy.GetElementsByTagName("POZNAMKA")[0].InnerText : "";


                        decimal mzdaOd = 0;
                        decimal mzdaDo = 0;
                        string mzdaType = "";

                        if (vacancy.GetElementsByTagName("MZDA")[0] != null)
                        {
                            Decimal.TryParse(vacancy.GetElementsByTagName("MZDA")[0].Attributes["min"] != null ? vacancy.GetElementsByTagName("MZDA")[0].Attributes["min"].Value : "0", out mzdaOd);

                            Decimal.TryParse(vacancy.GetElementsByTagName("MZDA")[0].Attributes["max"] != null ? vacancy.GetElementsByTagName("MZDA")[0].Attributes["max"].Value : "0", out mzdaDo);

                            mzdaType = vacancy.GetElementsByTagName("MZDA")[0].Attributes["typMzdy"] != null ? vacancy.GetElementsByTagName("MZDA")[0].Attributes["typMzdy"].Value : "";
                        }


                        DataModel.VolneMistaBLL.saveVM(idCoobce, jazyky, pracVztahy, idProf, idSmennost, typeZamest
                            , idUP, idVzdelani, aktualDate, firm, kodVacancy, kontakt, 0, 0, pocetVM, poznamka
                            , mzdaOd, mzdaDo, mzdaType, DateTime.Now, DateTime.Now.AddYears(1));
                    }
                }
                catch(Exception ex)
                { }
            }
        }
    }
}
