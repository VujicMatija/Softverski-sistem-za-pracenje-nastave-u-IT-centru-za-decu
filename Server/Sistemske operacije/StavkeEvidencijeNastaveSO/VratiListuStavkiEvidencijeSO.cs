using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.StavkeEvidencijeNastaveSO
{
    public class VratiListuStavkiEvidencijeSO : SOBase
    {
        private readonly StavkaEvidencijeNastave stavka;
        public List<StavkaEvidencijeNastave> Result { get; set; }

        public VratiListuStavkiEvidencijeSO(StavkaEvidencijeNastave stavka)
        {
            this.stavka = stavka;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetByCondition(stavka);
            Result = lista.Cast<StavkaEvidencijeNastave>().ToList();
        }
    }
}
