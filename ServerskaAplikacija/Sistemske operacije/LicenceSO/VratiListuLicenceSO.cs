using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.Licence
{
    public class VratiListuLicenceSO:SOBase
    {
        private readonly Licenca licenca;
        public List<Licenca> Result { get; set; }

        public VratiListuLicenceSO(Licenca l)
        {
            this.licenca = l;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> list = broker.GetByCondition(licenca);
            Result = list.Cast<Licenca>().ToList();
        }
    }
}
