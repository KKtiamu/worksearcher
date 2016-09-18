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


    }
}
