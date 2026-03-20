using BrokerBazePodataka;
using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.EvidencijaNastaveSO
{
    public class KreirajEvidencijuNastaveSO:SOBase
    {
        private readonly EvidencijaNastave evidencijaNastave;
        public int Result { get; set; }
        

        public KreirajEvidencijuNastaveSO(EvidencijaNastave evidencijaNastave)
        {
            this.evidencijaNastave = evidencijaNastave;
        }

        protected override void ExecuteConcreteOperation()
        {

            int indeks = broker.Create(evidencijaNastave);
            Result = indeks;
            // update
            evidencijaNastave.IdEvidencijeNastave = indeks;
            evidencijaNastave.SelectCondition = $"idEvidencijaNastave = {evidencijaNastave.IdEvidencijeNastave}";
            broker.UpdateByCondition(evidencijaNastave);
            foreach (var item in evidencijaNastave.stavkeEvidencijeNastave)
            {
                item.Evidencija = evidencijaNastave;
                broker.Add(item);
            }
            
        }
    }
}
