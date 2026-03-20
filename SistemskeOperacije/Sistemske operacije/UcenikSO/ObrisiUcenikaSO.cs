using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.UcenikSO
{
    public class ObrisiUcenikaSO : SOBase
    {
        private readonly Ucenik ucenik;

        public ObrisiUcenikaSO(Ucenik ucenik)
        {
            this.ucenik = ucenik;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.DeleteEntity(ucenik);
        }
    }
}
