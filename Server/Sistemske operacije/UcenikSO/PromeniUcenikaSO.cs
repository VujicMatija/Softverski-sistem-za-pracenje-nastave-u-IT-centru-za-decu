using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.UcenikSO
{
    public class PromeniUcenikaSO : SOBase
    {
        private readonly Ucenik ucenik;

        public PromeniUcenikaSO(Ucenik ucenik)
        {
            this.ucenik = ucenik;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.UpdateByCondition(ucenik);
        }
    }
}
