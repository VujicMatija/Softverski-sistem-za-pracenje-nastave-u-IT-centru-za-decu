using BrokerBazePodataka;
using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.StavkeEvidencijeNastaveSO
{
    public class PretraziStavkuEvidencijeNastaveSO:SOBase
    {
        private readonly StavkaEvidencijeNastave stavka;

        public StavkaEvidencijeNastave Result { get; set; }

        public PretraziStavkuEvidencijeNastaveSO(StavkaEvidencijeNastave stavka)
        {
            this.stavka = stavka;
        }

        protected override void ExecuteConcreteOperation()
        {
            string condition = $"sen.idStavkaEvidencije = {stavka.idStavkeEvidencije}";
            stavka.SelectCondition = condition;
            List<IEntity> lista = broker.GetByCondition(stavka);
            Result = lista.Cast<StavkaEvidencijeNastave>().FirstOrDefault();


        }
    }
}
