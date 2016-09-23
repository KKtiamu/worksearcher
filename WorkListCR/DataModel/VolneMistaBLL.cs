using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public static class VolneMistaBLL
    {
        public static int saveVzdelani(string kod, string name)
        {
            dataClassWorkDataContext context = new dataClassWorkDataContext();
            var vzdelan = context.vzdelans.Where(x => x.kodUP == kod).FirstOrDefault();
            if(vzdelan!=null)
            {
                return ((DataModel.vzdelan)vzdelan).id;
            }
            else
            {
                DataModel.vzdelan newVzdelan = new DataModel.vzdelan()
                {
                    kodUP=kod,
                    name=name
                };
                context.vzdelans.InsertOnSubmit(newVzdelan);
                context.SubmitChanges();
                return newVzdelan.id;
            }
        }

        public static int saveSmeny(string kod, string name)
        {
            dataClassWorkDataContext context = new dataClassWorkDataContext();
            var smeny = context.smenies.Where(x => x.kodUP == kod).FirstOrDefault();
            if (smeny != null)
            {
                return ((DataModel.smeny)smeny).id;
            }
            else
            {
                DataModel.smeny newSmena = new DataModel.smeny()
                {
                    kodUP = kod,
                    name = name
                };
                context.smenies.InsertOnSubmit(newSmena);
                context.SubmitChanges();
                return newSmena.id;
            }
        }

        public static int saveUP(string kod, string name)
        {
            dataClassWorkDataContext context = new dataClassWorkDataContext();
            var subject = context.uradPraces.Where(x => x.kodUP == kod).FirstOrDefault();
            if (subject != null)
            {
                return ((DataModel.uradPrace)subject).id;
            }
            else
            {
                DataModel.uradPrace newsubject = new DataModel.uradPrace()
                {
                    kodUP = kod,
                    name = name
                };
                context.uradPraces.InsertOnSubmit(newsubject);
                context.SubmitChanges();
                return newsubject.id;
            }
        }

        public static int saveObor(string kod, string name)
        {
            dataClassWorkDataContext context = new dataClassWorkDataContext();
            var subject = context.obors.Where(x => x.kodUp == kod).FirstOrDefault();
            if (subject != null)
            {
                return ((DataModel.obor)subject).id;
            }
            else
            {
                DataModel.obor newsubject = new DataModel.obor()
                {
                    kodUp = kod,
                    name = name
                };
                context.obors.InsertOnSubmit(newsubject);
                context.SubmitChanges();
                return newsubject.id;
            }
        }

        public static int saveProf(string kod, string name, int idObor)
        {
            dataClassWorkDataContext context = new dataClassWorkDataContext();
            var subject = context.profs.Where(x => x.kodUP == kod).FirstOrDefault();
            if (subject != null)
            {
                return ((DataModel.prof)subject).id;
            }
            else
            {
                if (idObor==0)
                {
                    idObor = context.obors.Where(x => x.kodUp == "0").FirstOrDefault().id;
                }
                DataModel.prof newsubject = new DataModel.prof()
                {
                    kodUP = kod,
                    name = name,
                    idObor = idObor
                };
                context.profs.InsertOnSubmit(newsubject);
                context.SubmitChanges();
                return newsubject.id;
            }
        }

        public static string saveCoObce(string coObce, string obce, string okres, string psc, string kodOkres)
        {
            dataClassWorkDataContext context = new dataClassWorkDataContext();
            var subject = context.coobecs.Where(x => x.name == coObce && x.obec.name == obce).FirstOrDefault();
            if(subject!=null)
            {
                return subject.id+","+subject.obec.id+","+subject.obec.okre.id;
            }
            else
            {
                int idOkres = 0;
                var okresSubject = context.okres.Where(x => x.name == okres).FirstOrDefault();
                if(okresSubject!=null)
                {
                    idOkres = okresSubject.id;
                }
                else
                {
                    okre newOkres = new okre()
                    {
                        name = okres,
                        kodUP = kodOkres
                    };
                    context.okres.InsertOnSubmit(newOkres);
                    context.SubmitChanges();
                    idOkres = newOkres.id;
                }

                int idObec = 0;
                var obecSubject = context.obecs.Where(x=>x.name==obce && x.idOkres == idOkres).FirstOrDefault();
                if(obecSubject!=null)
                {
                    idObec = obecSubject.id;
                }
                else
                {
                    obec newObec = new obec()
                    {
                        name = obce,
                        idOkres = idOkres
                    };
                    context.obecs.InsertOnSubmit(newObec);
                    context.SubmitChanges();
                    idObec = newObec.id;
                }

                if (coObce != "")
                {
                    coobec newCoObec = new coobec()
                    {
                        name = coObce,
                        idObec = idObec,
                        psc = psc
                    };
                    context.coobecs.InsertOnSubmit(newCoObec);
                    context.SubmitChanges();
                    return newCoObec.id+","+idObec+","+idOkres;
                }
                else
                {
                    return "0," + idObec + "," + idOkres;
                }
            }
        }

        public static int saveJazyk(string kodJazyka, string jazykName, string kodUroven, string uroven)
        {
            int idJazyk = 0;
            dataClassWorkDataContext context = new dataClassWorkDataContext();
            var jazykSubject = context.jazyks.Where(x=>x.name== jazykName && x.uroven==uroven).FirstOrDefault();
            if(jazykSubject!=null)
            {
                idJazyk = jazykSubject.id;
            } 
            else
            {
                jazyk newJazyk = new jazyk()
                {
                    name = jazykName,
                    uroven = uroven,
                    kodUP=kodJazyka,
                    urovenId=kodUroven
                };
                context.jazyks.InsertOnSubmit(newJazyk);
                context.SubmitChanges();
                idJazyk = newJazyk.id;
            }
            return idJazyk;
        }

        public static int getTypeZamestn(string kodPolozky)
        {
            dataClassWorkDataContext context = new dataClassWorkDataContext();
            return context.typZamests.Where(x => x.kod == kodPolozky).FirstOrDefault().id;
        }

        public static int getPracVztah(string kodPolozky)
        {
            dataClassWorkDataContext context = new dataClassWorkDataContext();
            return context.pracVztahs.Where(x => x.kod == kodPolozky).FirstOrDefault().id;
        }

        public static bool saveVM(string coobec, string jazyk, string pracVztah, int prof, int smena, string typZ,
            int uradPrace, int vzdelani, DateTime aktualDate, string firm, string kodVacancy, string kontaktFirm,
            int pocetMK, int pocetZK, int pocetMist, string poznamka, decimal mzdaOd, decimal mzdaDo, string mzdaType, DateTime praceOd, DateTime praceDo)
        {
            try
            {
                dataClassWorkDataContext context = new dataClassWorkDataContext();
                var oldVM = context.VMs.Where(x => x.kodUP == kodVacancy).FirstOrDefault();
                if(oldVM!=null)
                {
                    context.VMs.DeleteOnSubmit(oldVM);
                    context.SubmitChanges();
                }
                VM newVM = new VM
                {
                    idObce = coobec,
                    idJazyka = jazyk,
                    idPracVztah = pracVztah,
                    idProf = prof,
                    idSmena = smena,
                    idTyp = typZ,
                    idUP = uradPrace,
                    idVzdelani = vzdelani,
                    dateAktual = aktualDate,
                    firma = firm,
                    kodUP = kodVacancy,
                    kontakt = kontaktFirm,
                    modryKarty = pocetMK,
                    zamestnKarty = pocetZK,
                    volnychMist = pocetMist,
                    poznamka = poznamka,
                };
                if (mzdaOd > 0) { newVM.mzdaOd = mzdaOd; }
                if (mzdaDo > 0) { newVM.mzdaDo = mzdaDo; }
                if (mzdaType != "") { newVM.mzdaType = mzdaType; }
                if (praceOd.Year != 2015) { newVM.terminOd = praceOd; }
                if (praceDo.Year != 2015) { newVM.terminDo = praceDo; }
                context.VMs.InsertOnSubmit(newVM);
                context.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static bool isExist(string kodVacancy)
        {
            dataClassWorkDataContext context = new dataClassWorkDataContext();
            var oldVM = context.VMs.Where(x => x.kodUP == kodVacancy).FirstOrDefault();
            if (oldVM != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
