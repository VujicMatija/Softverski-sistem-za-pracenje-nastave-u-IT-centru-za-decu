using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.StavkeEvidencijeNastaveSO
{
    public class PromeniStavkuEvidencijeNastaveSO : SOBase
    {
        private readonly StavkaEvidencijeNastave stavka;

        public PromeniStavkuEvidencijeNastaveSO(StavkaEvidencijeNastave stavka)
        {
            this.stavka = stavka;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.UpdateByCondition(stavka);
        }
    }
}
