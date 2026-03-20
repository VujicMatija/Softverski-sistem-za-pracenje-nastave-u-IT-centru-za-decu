using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.UciteljSO
{
    public class UbaciUciteljaSO : SOBase
    {
        private readonly Ucitelj ucitelj;

        public UbaciUciteljaSO(Ucitelj ucitelj)
        {
            this.ucitelj = ucitelj;
        }

        protected override void ExecuteConcreteOperation()
        {
           
            broker.Add(ucitelj);
        }
    }
}
