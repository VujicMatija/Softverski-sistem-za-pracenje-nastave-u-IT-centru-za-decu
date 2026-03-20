using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija
{
    public class UbaciUcenikGrupuSO:SOBase
    {
        private readonly UcenikGrupa ucenikGrupa;

        public UbaciUcenikGrupuSO(UcenikGrupa ucenikGrupa)
        {
            this.ucenikGrupa = ucenikGrupa;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add(ucenikGrupa);
        }
    }
}
