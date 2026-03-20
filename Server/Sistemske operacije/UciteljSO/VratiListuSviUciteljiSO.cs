using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.UciteljSO
{
    public class VratiListuSviUciteljiSO : SOBase
    {

        public List<Ucitelj> Result { get; set; }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetAll(new Ucitelj());
            Result = lista.Cast<Ucitelj>().ToList();
        }
    }
}
