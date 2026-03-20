using BrokerBazePodataka;
using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.UciteljSO
{
    public class VratiListuUciteljaSO:SOBase
    {
        private readonly Ucitelj u;
        public List<Ucitelj> Result { get; set; }

        public VratiListuUciteljaSO(Ucitelj ucitelj)
        {
            this.u = ucitelj;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> list = broker.GetByCondition(u);
            Result = list.Cast<Ucitelj>().ToList();
        }
    }
}
