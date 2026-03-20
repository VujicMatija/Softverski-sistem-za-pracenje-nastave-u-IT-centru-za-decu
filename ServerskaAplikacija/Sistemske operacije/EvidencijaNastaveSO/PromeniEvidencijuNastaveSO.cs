using BrokerBazePodataka;
using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.EvidencijaNastaveSO
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
            foreach (StavkaEvidencijeNastave stavka in evidencijaNastave.stavkeEvidencijeNastave)
            {
                string condition = $" idStavkaEvidencije = {stavka.idStavkeEvidencije}";
                if (stavka.ZaBrisanje)
                {
                    stavka.SelectCondition = condition;
                    broker.DeleteEntity(stavka);
                }
                else if (stavka.ZaUbacivanje)
                {
                    //stavka.UpdateCondition = condition;
                    broker.Add(stavka);
                }
                else if (stavka.ZaUpdate)
                {

                    stavka.SelectCondition = $" idStavkaEvidencije = {stavka.idStavkeEvidencije}";
                    broker.UpdateByCondition(stavka);
                }
            }
        }
    }
}
