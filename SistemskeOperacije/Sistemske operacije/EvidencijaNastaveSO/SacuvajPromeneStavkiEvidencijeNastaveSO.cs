using Domeni;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.EvidencijaNastaveSO
{
    public class SacuvajPromeneStavkiEvidencijeNastaveSO : SOBase
    {
        private readonly EvidencijaNastave evidencija;

        public SacuvajPromeneStavkiEvidencijeNastaveSO(EvidencijaNastave evidencijaNastave)
        {
            this.evidencija = evidencijaNastave;
        }
        protected override void ExecuteConcreteOperation()
        {
            foreach(StavkaEvidencijeNastave stavka in evidencija.stavkeEvidencijeNastave)
            {
                string condition = $" idStavkaEvidencije = {stavka.idStavkeEvidencije}";
                if (stavka.ZaBrisanje)
                {
                    stavka.SelectCondition = condition;
                    broker.DeleteEntity(stavka);
                }
                else if(stavka.ZaUbacivanje)
                {
                    //stavka.UpdateCondition = condition;
                    broker.Add(stavka);
                }
                else if(stavka.ZaUpdate)
                {
                    
                    stavka.SelectCondition = $" idStavkaEvidencije = {stavka.idStavkeEvidencije}";
                    broker.UpdateByCondition(stavka);
                }
            }
        }
    }
}
