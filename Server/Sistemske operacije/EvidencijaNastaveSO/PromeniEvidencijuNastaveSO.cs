using BrokerBazePodataka;
using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.EvidencijaNastaveSO
{
    public class PromeniEvidencijuNastaveSO:SOBase
    {
        private readonly EvidencijaNastave evidencijaNastave;

        public PromeniEvidencijuNastaveSO(EvidencijaNastave evidencija)
        {
            this.evidencijaNastave = evidencija;
        }

        protected override void ExecuteConcreteOperation()
        {

            broker.UpdateByCondition(evidencijaNastave);
        }
    }
}
