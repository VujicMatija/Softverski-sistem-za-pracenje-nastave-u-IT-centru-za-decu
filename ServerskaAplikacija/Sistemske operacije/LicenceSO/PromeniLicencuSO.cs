using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.Licence
{
    public class PromeniLicencuSO : SOBase
    {
        private readonly Licenca licenca;

        public PromeniLicencuSO(Licenca licenca)
        {
            this.licenca = licenca;
        }

        protected override void ExecuteConcreteOperation()
        {

            broker.UpdateByCondition(licenca);
        }
    }
}
