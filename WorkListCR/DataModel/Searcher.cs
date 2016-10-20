using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public static class Searcher
    {
        public static IEnumerable<SelectOkresResult> getOkres(int okresId)
        {
            dataClassWorkDataContext context = new dataClassWorkDataContext();
            return context.SelectOkres(okresId);
        }

        public static IEnumerable<SelectOborResult> getObor(int okresId)
        {
            dataClassWorkDataContext context = new dataClassWorkDataContext();
            return context.SelectObor(okresId);
        }

        public static IEnumerable<SelectJazykResult> getJazyk(int okresId)
        {
            dataClassWorkDataContext context = new dataClassWorkDataContext();
            return context.SelectJazyk(okresId);
        }

        public static IEnumerable<SelectSmenyResult> getSmeny(int okresId)
        {
            dataClassWorkDataContext context = new dataClassWorkDataContext();
            return context.SelectSmeny(okresId);
        }

        public static IEnumerable<SelectVzdelaniResult> getVzdelani(int okresId)
        {
            dataClassWorkDataContext context = new dataClassWorkDataContext();
            return context.SelectVzdelani(okresId);
        }

        public static IEnumerable<SelectVMResult> getVM(int VMid)
        {
            dataClassWorkDataContext context = new dataClassWorkDataContext();
            return context.SelectVM(VMid);
        }

        public static IEnumerable<SelectProfByOborResult> getProfByObor(int oborId)
        {
            dataClassWorkDataContext context = new dataClassWorkDataContext();
            return context.SelectProfByObor(oborId);
        }

        public static IEnumerable<SelectVMByJazykResult> getVmByJazyk(int jazykId)
        {
            dataClassWorkDataContext context = new dataClassWorkDataContext();
            return context.SelectVMByJazyk(jazykId);
        }
    }
}
