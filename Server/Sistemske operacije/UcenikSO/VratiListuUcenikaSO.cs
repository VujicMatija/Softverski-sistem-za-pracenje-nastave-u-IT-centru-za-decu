using BrokerBazePodataka;
using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.UcenikSO
{
    public class VratiListuUcenikaSO:SOBase
    {

        private readonly Ucenik ucenik;
        public List<Ucenik> Result { get; set; }

        public VratiListuUcenikaSO(Ucenik ucenik)
        {
            this.ucenik = ucenik;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> list = broker.GetByCondition(ucenik);
            Result = list.Cast<Ucenik>().ToList();
            
        }

    }
}
