using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.UciteljSO
{
    public class ObrisiUciteljaSO : SOBase
    {
        private readonly Ucitelj ucitelj;

        public ObrisiUciteljaSO(Ucitelj ucitelj)
        {
            this.ucitelj = ucitelj;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.DeleteEntity(ucitelj);
        }
    }
}
