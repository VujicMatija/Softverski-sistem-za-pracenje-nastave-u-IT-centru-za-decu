using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaAplikacija.Licence
{
    public class VratiListuSveLicenceSO:SOBase
    {
        public List<Licenca> Result { get; set; }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetAll(new Licenca());
            Result = lista.Cast<Licenca>().ToList();
        }
    }
}
