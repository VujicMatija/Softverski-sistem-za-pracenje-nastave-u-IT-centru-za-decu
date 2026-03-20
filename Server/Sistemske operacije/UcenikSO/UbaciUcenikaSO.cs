using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.UcenikSO
{
    public class UbaciUcenikaSO : SOBase
    {
        private readonly Ucenik ucenik;

        public UbaciUcenikaSO(Ucenik ucenik)
        {
            this.ucenik = ucenik;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Add(ucenik);
        }
    }
}
