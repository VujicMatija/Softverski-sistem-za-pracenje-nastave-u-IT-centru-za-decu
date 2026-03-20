using BrokerBazePodataka;
using Domeni;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.EvidencijaNastaveSO
{
    public class PretraziEvidencijuNastaveSO:SOBase
    {
        private readonly EvidencijaNastave evidencija;

        public EvidencijaNastave Result { get; set; }

        public PretraziEvidencijuNastaveSO(EvidencijaNastave evidencija)
        {
            this.evidencija = evidencija;
        }

        protected override void ExecuteConcreteOperation()
        {
  
            string condition = $" ev.idEvidencijaNastave = {evidencija.IdEvidencijeNastave} ";
            evidencija.SelectCondition = condition;
            List<IEntity> lista = broker.GetByCondition(evidencija);
            Result = lista.Cast<EvidencijaNastave>().FirstOrDefault();
           

            Result.stavkeEvidencijeNastave = broker.GetByCondition(new StavkaEvidencijeNastave() { SelectCondition = $" sen.idEvidencijeNastave = {Result.IdEvidencijeNastave}" }).Cast<StavkaEvidencijeNastave>().ToList();
            
         
            if (Result == null)
            {
                throw new Exception("Ne postoji ovaj korisnik");
            }
        }
    }
}
