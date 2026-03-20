using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.UciteljSO
{
    public class PromeniUciteljaSO:SOBase
    {
        private readonly Ucitelj ucitelj;

        public PromeniUciteljaSO(Ucitelj ucitelj)
        {
            this.ucitelj = ucitelj;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.UpdateByCondition(ucitelj);
        }
    }
}
