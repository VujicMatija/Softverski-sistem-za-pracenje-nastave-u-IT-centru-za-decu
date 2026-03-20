using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.StavkeEvidencijeNastaveSO
{
    public class UbaciStavkuEvidenceijeNastaveSO:SOBase
    {
        private readonly StavkaEvidencijeNastave stavka;
        public UbaciStavkuEvidenceijeNastaveSO(StavkaEvidencijeNastave stavkaEvidencijeNastave)
        {
            this.stavka = stavkaEvidencijeNastave;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Add(stavka);
        }
    }
}
