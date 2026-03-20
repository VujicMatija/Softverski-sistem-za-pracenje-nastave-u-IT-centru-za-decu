using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.Licence
{
    public class UbaciLicencuSO : SOBase
    {
        private readonly Licenca licenca;
        public UbaciLicencuSO(Licenca l)
        {
            this.licenca = l;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Add(licenca);
        }
    }
}
